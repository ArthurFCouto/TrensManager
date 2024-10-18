using TrensManager.DTO.UserDTO;
using TrensManager.DTO.VehicleDTO;
using TrensManager.Models;

namespace TrensManager.DTO.TrainDTO
{
    public class TrainResponse : TrainResponseBase
    {
        public TrainResponse(TrainModel trainModel) : base(trainModel) { 
            CreatedAt = trainModel.CreatedAt;
            CreatedByUserID = trainModel.CreatedByUserID;
            Destination = trainModel.Destination;
            Id = trainModel.Id;
            OSNumber = trainModel.OSNumber;
            Origin = trainModel.Origin;
            UpdatedAt = trainModel.UpdatedAt;
            UpdatedByUserID = trainModel.UpdatedByUserID;
            Vehicles = trainModel.Vehicles?.Select((vehicle) => new VehicleResponseBase(vehicle)).ToList();
            User = new UserResponseBase(trainModel.User);
        }
        public List<VehicleResponseBase>? Vehicles { get; set; }
    }
}
