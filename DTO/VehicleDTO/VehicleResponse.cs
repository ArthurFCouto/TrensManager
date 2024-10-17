using TrensManager.DTO.TrainDTO;
using TrensManager.DTO.UserDTO;
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
            CreatedByUserID = vehicleModel.CreatedByUserID;
            Id = vehicleModel.Id;
            Trains = vehicleModel.Trains?.Select((trainModel) => new TrainResponseWithoutVehicles(trainModel)).ToList();
            Type = vehicleModel.Type;
            UpdatedAt = vehicleModel.UpdatedAt;
            UpdatedByUserID = vehicleModel.UpdatedByUserID;
            User = new UserResponseBase(vehicleModel.User);
        }
        public string Code { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedByUserID { get; set; }
        public int Id { get; set; }
        public List<TrainResponseWithoutVehicles>? Trains { get; set; }
        public VehicleType Type { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedByUserID { get; set; }
        public UserResponseBase User { get; set; }
    }
}
