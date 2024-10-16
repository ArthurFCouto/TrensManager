using System.ComponentModel.DataAnnotations;
using TrensManager.Enums;

namespace TrensManager.DTO.VehicleDTO
{
    public class VehicleRequest
    {
        [MaxLength(64)]
        [Required]
        public required string Code { get; set; }
        public List<int>? TrainOSNumber { get; set; }
        [Required]
        public required VehicleType Type { get; set; }
    }
}
