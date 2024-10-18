using TrensManager.DTO.TrainDTO;
using TrensManager.DTO.UserDTO;
using TrensManager.Enums;
using TrensManager.Models;

namespace TrensManager.DTO.VehicleDTO
{
    public class VehicleResponse : VehicleResponseBase
    {
        public VehicleResponse(VehicleModel vehicleModel) : base(vehicleModel)
        {
            Code = vehicleModel.Code;
            CreatedAt = vehicleModel.CreatedAt;
            CreatedByUserID = vehicleModel.CreatedByUserID;
            Id = vehicleModel.Id;
            Trains = vehicleModel.Trains?.Select((trainModel) => new TrainResponseBase(trainModel)).ToList();
            Type = vehicleModel.Type;
            UpdatedAt = vehicleModel.UpdatedAt;
            UpdatedByUserID = vehicleModel.UpdatedByUserID;
            User = new UserResponseBase(vehicleModel.User);
        }
        public List<TrainResponseBase>? Trains { get; set; }
    }
}
