using System.ComponentModel.DataAnnotations;

namespace TrensManager.DTO.TrainDTO
{
    public class TrainRequest
    {
        [MaxLength(255)]
        [Required]
        public string Destination { get; set; }
        [MaxLength(64)]
        [Required]
        public int OSNumber { get; set; }
        [MaxLength(255)]
        [Required]
        public required string Origin { get; set; }
        public List<string>? VehicleCodes { get; set; }
    }
}
