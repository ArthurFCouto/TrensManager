using TrensManager.DTO.UserDTO;
using TrensManager.DTO.VehicleDTO;
using TrensManager.Models;

namespace TrensManager.DTO.TrainDTO
{
    public class TrainResponseBase
    {
        public TrainResponseBase(TrainModel trainModel) { 
            CreatedAt = trainModel.CreatedAt;
            CreatedByUserID = trainModel.CreatedByUserID;
            Destination = trainModel.Destination;
            Id = trainModel.Id;
            OSNumber = trainModel.OSNumber;
            Origin = trainModel.Origin;
            UpdatedAt = trainModel.UpdatedAt;
            UpdatedByUserID = trainModel.UpdatedByUserID;
            User = new UserResponseBase(trainModel.User);
        }
        public DateTime CreatedAt { get; set; }
        public int CreatedByUserID { get; set; }
        public string Destination { get; set; }
        public int Id { get; set; }
        public int OSNumber { get; set; }
        public string Origin { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedByUserID { get; set; }
        public UserResponseBase User { get; set; }
    }
}
