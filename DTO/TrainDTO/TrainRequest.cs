using System.ComponentModel.DataAnnotations;

namespace TrensManager.DTO.TrainDTO
{
    public class TrainRequest
    {
        [MaxLength(255)]
        [Required]
        public required string Destination { get; set; }
        [Range(10000000, 99999999, ErrorMessage = "The value of the OSNumber field needs to be between 10,000,000 and 99,999,999.")]
        [Required]
        public required int OSNumber { get; set; }
        [MaxLength(255)]
        [Required]
        public required string Origin { get; set; }
        public List<string>? VehicleCodes { get; set; }
    }
}
