using TrensManager.Enums;
using TrensManager.Models;

namespace TrensManager.DTO.VehicleDTO
{
    public class VehicleResponseWithoutTrain
    {
        public VehicleResponseWithoutTrain(VehicleModel vehicleModel)
        {
            Code = vehicleModel.Code;
            CreatedAt = vehicleModel.CreatedAt;
            CreatedByUser = vehicleModel.CreatedByUser;
            Id = vehicleModel.Id;
            Type = vehicleModel.Type;
            UpdatedAt = vehicleModel.UpdatedAt;
            UpdatedByUser = vehicleModel.UpdatedByUser;
        }
        public string Code { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedByUser { get; set; }
        public int Id { get; set; }
        public VehicleType Type { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedByUser { get; set; }
    }
}
