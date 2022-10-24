using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace NatureListService.Models {
    [XmlRoot("Root")]
    public class CarriageList {
        [XmlElement("row")]
        [Required]
        public List<CarriageDTO> Carriages { get; private set;}
        public CarriageList() {
            Carriages = new List<CarriageDTO>(); 
        }
    }
    public class CarriageDTO {
        [XmlElement]
        [Required(ErrorMessage = "TrainNumber cannot be empty.")]
        public uint? TrainNumber { get; init; }
        [XmlElement]
        [Required(AllowEmptyStrings = false, ErrorMessage = "TrainIndex cannot be empty.")]
        public string? TrainIndexCombined { get; init; }
        [XmlElement]
        [Required(AllowEmptyStrings = false, ErrorMessage = "FromStationName cannot be empty.")]
        public string? FromStationName { get; init; }
        [XmlElement]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ToStationName cannot be empty.")]
        public string? ToStationName { get; init; }
        [XmlElement]
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastStationName cannot be empty.")]
        public string? LastStationName { get; init; }
        [XmlElement(ElementName = "WhenLastOperation")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "WhenLastOperation cannot be empty.")]
        public string? WhenLastOperationString { get {
                if (WhenLastOperationDate == null) 
                    return null;
                return WhenLastOperationDate.Value.ToString("dd.MM.yyyy H:mm:ss");
            }
            init {
                if(value == null) 
                    WhenLastOperationDate = null;
                else
                    WhenLastOperationDate = DateTime.ParseExact(value, "dd.MM.yyyy H:mm:ss", null);
            }
        }
        [XmlIgnore]
        public DateTime? WhenLastOperationDate { get; internal set; }
        [XmlElement]
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastOperationName cannot be empty.")]
        public string? LastOperationName { get; init; }
        [XmlElement]
        [Required(AllowEmptyStrings = false, ErrorMessage = "InvoiceNum cannot be empty.")]
        public string? InvoiceNum { get; init; }
        [XmlElement]
        [Required(ErrorMessage = "PositionInTrain cannot be empty.")]
        public uint? PositionInTrain { get; init; }
        [XmlElement]
        [Required(ErrorMessage = "CarNumber cannot be empty.")]
        public uint? CarNumber { get; init; }
        [XmlElement]
        [Required(AllowEmptyStrings = false, ErrorMessage = "FreightEtsngName cannot be empty.")]
        public string? FreightEtsngName { get; init; }
        [XmlElement]
        [Required(ErrorMessage = "FreightTotalWeightKg cannot be empty.")]
        public uint? FreightTotalWeightKg { get; init; }
    }
}
