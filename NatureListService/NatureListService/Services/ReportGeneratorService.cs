using DevExpress.XtraPrinting;
using NatureListService.Models;

namespace NatureListService.Services {
    public interface IReportGeneratorService {
        public abstract Task<byte[]> GetNatureListReportByTrain(IEnumerable<CarriageDTO> carriageDTOs);
    }
    public static class XtraReportGeneratorExtensions {
        public static void XtraReportGeneratorService(this IServiceCollection services) {
            services.AddTransient<IReportGeneratorService, XtraReportGeneratorService>();
        }
    }
    public class XtraReportGeneratorService: IReportGeneratorService {
        public async Task<byte[]> GetNatureListReportByTrain(IEnumerable<CarriageDTO> carriageDTOs) {
            using(MemoryStream stream = new MemoryStream()) {
                NatureListReport report = new NatureListReport();
                report.DataSource = carriageDTOs;
                XlsxExportOptions options = new XlsxExportOptions();
                await report.ExportToXlsxAsync(stream, options);
                return stream.ToArray();
            }
                
        }
    }
}
