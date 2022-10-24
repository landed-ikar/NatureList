using DevExpress.Xpo;
using NatureListService.Models;
using NatureListService.Models.CarriageDataModel;

namespace NatureListService.Services
    {
    public interface IDataStorageService {
        abstract Task SaveDataAsync(IEnumerable<CarriageDTO> carriages);
        abstract Task<IEnumerable<CarriageDTO>> GetCarriageByTrainAsync(uint trainNumber);
        abstract Task<NatureListDTO> GetNatureListDataByTrainAsync(uint trainNumber);
    }
    public static class XpoDataStorageExtensions {
        public static void AddXpoDataStorageService(this IServiceCollection services) {
            services.AddTransient<IDataStorageService, XpoDataStorageService>();
        }
    }
    public class XpoDataStorageService : IDataStorageService {
        private readonly UnitOfWork uow;
        public XpoDataStorageService(CarriageDataModelUnitOfWork uow) {
            this.uow = uow;
        }
        public async Task SaveDataAsync(IEnumerable<CarriageDTO> carriageDTOs) {
            uow.BeginTransaction();
            try {
                IEnumerable<uint> trainNumbers = carriageDTOs.Select(car => car.TrainNumber!.Value).Distinct();
                Task<IEnumerable<Train>> trains = GetTrainsByNumbersAsync(trainNumbers);
                IEnumerable<string> trainsIndices = carriageDTOs.Select(car => car.TrainIndexCombined!).Distinct();
                Task<IEnumerable<TrainIndex>> indices = GetTrainIndicesByValuesAsync(trainsIndices);
                IEnumerable<string> invoiceNumbers = carriageDTOs.Select(car => car.InvoiceNum!).Distinct();
                Task<IEnumerable<Invoice>> invoices = GetInvoicesByNumbersAsync(invoiceNumbers);
                IEnumerable<string> stationNames = carriageDTOs.Select(car => car.FromStationName!).Distinct()
                    .Union(carriageDTOs.Select(car => car.ToStationName!).Distinct())
                    .Union(carriageDTOs.Select(car => car.LastStationName!).Distinct());
                Task<IEnumerable<Station>> stations = GetStationsByNamesAsync(stationNames);
                IEnumerable<string> freightNames = carriageDTOs.Select(car => car.FreightEtsngName!).Distinct();
                Task<IEnumerable<FreightType>> freights = GetFreightTypesByNamesAsync(freightNames);
                IEnumerable<string> operationNames = carriageDTOs.Select(car => car.LastOperationName!).Distinct();
                Task<IEnumerable<Operation>> operations = GetOperationsByNamesAsync(operationNames);
                IEnumerable<uint> carNumbers = carriageDTOs.Select(car => car.CarNumber!.Value).Distinct();
                Task<IEnumerable<Carriage>> carriages = GetCarriagesByNumbersAsync(carNumbers);
                await Task.WhenAll(trains, indices, invoices, stations, operations, carriages);

                foreach(CarriageDTO car in carriageDTOs) {
                    Carriage carriage = carriages.Result.Single(c => c.CarriageNumber == car.CarNumber);
                    if(uow.IsNewObject(carriage)) {
                        carriage.Train = trains.Result.Single(t => t.Number == car.TrainNumber);
                        carriage.TrainIndex = indices.Result.Single(t => t.Index == car.TrainIndexCombined);
                        carriage.Invoice = invoices.Result.Single(inv => inv.Number == car.InvoiceNum);
                        carriage.FromStation = stations.Result.Single(s => s.Name == car.FromStationName);
                        carriage.ToStation = stations.Result.Single(s => s.Name == car.ToStationName);
                        carriage.FreightType = freights.Result.Single(s => s.Name == car.FreightEtsngName);
                        carriage.PositionInTrain = car.PositionInTrain!.Value;
                        carriage.CarriageNumber = car.CarNumber!.Value;
                        carriage.FreightWeight = car.FreightTotalWeightKg!.Value;
                    }
                    if(!carriage.OperationStates.Any(op => op.Date == car.WhenLastOperationDate!.Value)) {
                        carriage.OperationStates.Add(new OperationState(uow) {
                            Date = car.WhenLastOperationDate!.Value,
                            Station = stations.Result.Single(s => s.Name == car.LastStationName),
                            Operation = operations.Result.Single(op => op.Name == car.LastOperationName)
                        });
                    }
                }
                await uow.CommitChangesAsync();
            }
            catch {
                uow.RollbackTransaction();
            }
        }
        private async Task<IEnumerable<TrainIndex>> GetTrainIndicesByValuesAsync(IEnumerable<string> trainsIndices) {
            XPQuery<TrainIndex> getIndexQuery = new XPQuery<TrainIndex>(uow);
            List<TrainIndex> existingIndices = await getIndexQuery
                .Where(ind => trainsIndices.Contains(ind.Index))
                .ToListAsync();
            var missingTrainIndices = trainsIndices
                .Where(tn => !existingIndices.Any(t => t.Index == tn));
            foreach(string trainIndex in missingTrainIndices)
                existingIndices.Add(new TrainIndex(uow) { Index = trainIndex });
            return existingIndices;
        }
        private async Task<IEnumerable<Train>> GetTrainsByNumbersAsync(IEnumerable<uint> trainNumbers) {
            XPQuery<Train> getTrainQuery = new XPQuery<Train>(uow);
            List<Train> existingTrains = await getTrainQuery
                .Where(t => trainNumbers.Contains(t.Number))
                .ToListAsync();
            var missingTrainNumbers = trainNumbers
                .Where(tn => !existingTrains.Any(t => t.Number == tn));
            foreach(uint trainNumber in missingTrainNumbers)
                existingTrains.Add(new Train(uow) { Number = trainNumber });
            return existingTrains;
        }
        private async Task<IEnumerable<Invoice>> GetInvoicesByNumbersAsync(IEnumerable<string> invoiceNumbers) {
            XPQuery<Invoice> getInvoicesQuery = new XPQuery<Invoice>(uow);
            List<Invoice> existingInvoices = await getInvoicesQuery
                .Where(inv => invoiceNumbers.Contains(inv.Number))
                .ToListAsync();
            var missingInvoiceNumbers = invoiceNumbers
                .Where(n => !existingInvoices.Any(inv => inv.Number == n));
            foreach(string invoiceNumber in missingInvoiceNumbers)
                existingInvoices.Add(new Invoice(uow) { Number = invoiceNumber });
            return existingInvoices;
        }
        private async Task<IEnumerable<Station>> GetStationsByNamesAsync(IEnumerable<string> stationNames) {
            XPQuery<Station> getStationQuery = new XPQuery<Station>(uow);
            List<Station> existingStations = await getStationQuery
                .Where(s => stationNames.Contains(s.Name))
                .ToListAsync();
            IEnumerable<string> missingStationNames = stationNames
                .Except(existingStations.Select(s => s.Name));
            foreach(string stationName in missingStationNames)
                existingStations.Add(new Station(uow) { Name = stationName });
            return existingStations;
        }
        private async Task<IEnumerable<FreightType>> GetFreightTypesByNamesAsync(IEnumerable<string> freightNames) {
            XPQuery<FreightType> getFreightsQuery = new XPQuery<FreightType>(uow);
            List<FreightType> existingFreightTypes = await getFreightsQuery
                .Where(ft => freightNames.Contains(ft.Name))
                .ToListAsync();
            IEnumerable<string> missingFreightNames = freightNames
                .Except(existingFreightTypes.Select(s => s.Name));
            foreach(string freightName in missingFreightNames)
                existingFreightTypes.Add(new FreightType(uow) { Name = freightName });
            return existingFreightTypes;
        }
        private async Task<IEnumerable<Operation>> GetOperationsByNamesAsync(IEnumerable<string> operationNames) {
            XPQuery<Operation> getOperationsQuery = new XPQuery<Operation>(uow);
            List<Operation> existingOperations = await getOperationsQuery
                .Where(op => operationNames.Contains(op.Name))
                .ToListAsync();
            IEnumerable<string> missingOperationNames = operationNames
                .Except(existingOperations.Select(s => s.Name));
            foreach(string operationName in missingOperationNames)
                existingOperations.Add(new Operation(uow) { Name = operationName });
            return existingOperations;
        }
        private async Task<IEnumerable<Carriage>> GetCarriagesByNumbersAsync(IEnumerable<uint> carNumbers) {
            XPQuery<Carriage> getCarriageQuery = new XPQuery<Carriage>(uow);
            List<Carriage> existingCarriages = await getCarriageQuery
                .Where(c => carNumbers.Contains(c.CarriageNumber))
                .ToListAsync();
            var missingNumbers = carNumbers
                .Where(cn => !existingCarriages.Any(c => c.CarriageNumber == cn));
            foreach(uint carNumber in missingNumbers)
                existingCarriages.Add(new Carriage(uow) { CarriageNumber = carNumber });
            return existingCarriages;
        }
        public async Task<IEnumerable<CarriageDTO>> GetCarriageByTrainAsync(uint trainNumber) {
            IQueryable<Carriage> filteredQuery = new XPQuery<Carriage>(uow)
                .Where(c => c.Train.Number == trainNumber)
                .OrderBy(c=>c.PositionInTrain);
            List<Carriage> carriages = await filteredQuery.ToListAsync();
            if(carriages.Count == 0)
                throw new ArgumentException(message: $"Train with number {trainNumber} not found.");
            List<CarriageDTO> result = new List<CarriageDTO>();
            foreach (Carriage carriage in carriages) {
                OperationState lastOperation = carriage.OperationStates.OrderBy(op => op.Date).Last();
                CarriageDTO dTO = new CarriageDTO() {
                    FreightEtsngName = carriage.FreightType.Name,
                    FreightTotalWeightKg = carriage.FreightWeight,
                    FromStationName = carriage.FromStation.Name,
                    ToStationName = carriage.ToStation.Name,
                    InvoiceNum = carriage.Invoice.Number,
                    TrainIndexCombined = carriage.TrainIndex.Index,
                    TrainNumber = carriage.Train.Number,
                    PositionInTrain = carriage.PositionInTrain,
                    CarNumber = carriage.CarriageNumber,
                    LastOperationName = lastOperation.Operation.Name,
                    LastStationName = lastOperation.Station.Name,
                    WhenLastOperationDate = lastOperation.Date,
                };
                result.Add(dTO);
            }
            return result;
        }
        public async Task<NatureListDTO> GetNatureListDataByTrainAsync(uint trainNumber) {
            IQueryable<Carriage> filteredQuery = new XPQuery<Carriage>(uow)
               .Where(c => c.Train.Number == trainNumber)
               .OrderBy(c => c.PositionInTrain);
            List<Carriage> carriages = await filteredQuery.ToListAsync();
            if(carriages.Count == 0)
                throw new ArgumentException(message: $"Train with number {trainNumber} not found.");
            NatureListDTO result = new NatureListDTO() {
                TrainNumber = carriages.First().Train.Number,
                TrainIndex = uint.Parse(carriages.First().TrainIndex.Index.Split('-')[1]),
                FromStationName = carriages.First().FromStation.Name,
                ToStationName = carriages.First().ToStation.Name,
                LastStationName = carriages.First().OperationStates.OrderBy(c=>c.Date).Last().Station.Name,
                LastOperationDateTime = carriages.First().OperationStates.OrderBy(c => c.Date).Last().Date,
            };
            foreach(Carriage carriage in carriages) {
                NlCarriageDTO dTO = new NlCarriageDTO() {
                    FreightEtsngName = carriage.FreightType.Name,
                    FreightTotalWeightKg = carriage.FreightWeight,
                    InvoiceNum = carriage.Invoice.Number,
                    PositionInTrain = carriage.PositionInTrain,
                    CarNumber = carriage.CarriageNumber,
                    DepartureDate = carriages.First().OperationStates.OrderBy(c => c.Date).First().Date
                };
                result.Carriages.Add(dTO);
            }
            return result;

        }
    }
}