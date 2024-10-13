using TrensManager.Enums;
using TrensManager.Models;

namespace TrensManager.DTO.VehicleDTO
{
    public class VehicleResponse
    {
        public VehicleResponse(VehicleModel vehicleModel)
        {
            CreatedAt = vehicleModel.CreatedAt;
            UpdatedAt = vehicleModel.UpdatedAt;
            Id = vehicleModel.Id;
            Type = vehicleModel.Type;
            Code = vehicleModel.Code;
            TrainId = vehicleModel.TrainId;
            CreatedByUser = vehicleModel.CreatedByUser;
            UpdatedByUser = vehicleModel.UpdatedByUser;
        }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Code { get; set; }
        public int Id { get; set; }
        public int? TrainId { get; set; }
        public VehicleType Type { get; set; }
        public string CreatedByUser { get; set; }
        public string UpdatedByUser { get; set; }
    }
}
