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
            Trains = vehicleModel.Trains?.Select((trainModel) => new TrainResponseWithoutVehicles(trainModel)).ToList();
            Type = vehicleModel.Type;
            UpdatedAt = vehicleModel.UpdatedAt;
            UpdatedByUser = vehicleModel.UpdatedByUser;
        }
        public string Code { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedByUser { get; set; }
        public int Id { get; set; }
        public List<TrainResponseWithoutVehicles>? Trains { get; set; }
        public VehicleType Type { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedByUser { get; set; }
    }
}
