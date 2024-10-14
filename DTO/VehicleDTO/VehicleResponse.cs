using TrensManager.DTO.TrainDTO;
using TrensManager.Enums;
using TrensManager.Models;

namespace TrensManager.DTO.VehicleDTO
{
    public class VehicleResponse
    {
        public VehicleResponse(VehicleModel vehicleModel)
        {
            Code = vehicleModel.Code;
            CreatedAt = vehicleModel.CreatedAt;
            CreatedByUser = vehicleModel.CreatedByUser;
            Id = vehicleModel.Id;
            Train = new TrainResponseWithoutVehicles(vehicleModel.Train);
            TrainId = vehicleModel.TrainId;
            Type = vehicleModel.Type;
            UpdatedAt = vehicleModel.UpdatedAt;
            UpdatedByUser = vehicleModel.UpdatedByUser;
        }
        public string Code { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedByUser { get; set; }
        public int Id { get; set; }
        public TrainResponseWithoutVehicles? Train { get; set; }
        public int? TrainId { get; set; }
        public VehicleType Type { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedByUser { get; set; }
    }
}
