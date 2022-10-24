using System.ComponentModel.DataAnnotations;

namespace NatureListService.Models {
    public class NatureListDTO {
        [Required(ErrorMessage = "TrainNumber cannot be empty.")]
        public uint? TrainNumber { get; init; }
        [Required(ErrorMessage = "TrainIndex cannot be empty.")]
        public uint? TrainIndex { get; init; }
        [Required(ErrorMessage = "LastOperationDateTime cannot be empty.")]
        public DateTime? LastOperationDateTime { get; internal set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "FromStationName cannot be empty.")]
        public string? FromStationName { get; init; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "ToStationName cannot be empty.")]
        public string? ToStationName { get; init; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastStationName cannot be empty.")]
        public string? LastStationName { get; init; }
        [Required(ErrorMessage = "Carriages cannot be empty.")]
        public List<NlCarriageDTO> Carriages { get; init; }
        public NatureListDTO() {
            Carriages = new List<NlCarriageDTO>();
        }
    }
    public class NlCarriageDTO {
        [Required(ErrorMessage = "PositionInTrain cannot be empty.")]
        public uint? PositionInTrain { get; init; }
        [Required(ErrorMessage = "CarNumber cannot be empty.")]
        public uint? CarNumber { get; init; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "InvoiceNum cannot be empty.")]
        public string? InvoiceNum { get; init; }
        [Required(ErrorMessage = "DepartureDate cannot be empty.")]
        public DateTime? DepartureDate { get; internal set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "FreightEtsngName cannot be empty.")]
        public string? FreightEtsngName { get; init; }
        [Required(ErrorMessage = "FreightTotalWeightKg cannot be empty.")]
        public uint? FreightTotalWeightKg { get; init; }
    }

}
