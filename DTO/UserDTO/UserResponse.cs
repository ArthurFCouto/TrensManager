using TrensManager.DTO.TrainDTO;
using TrensManager.DTO.VehicleDTO;
using TrensManager.Models;

namespace TrensManager.DTO.UserDTO
{
    public class UserResponse : UserResponseBase
    {
        public UserResponse(UserModel userModel) : base(userModel)
        {
            CreatedAt = userModel.CreatedAt;
            Id = userModel.Id;
            UpdatedAt = userModel.UpdatedAt;
            UserName = userModel.UserName;
            UserPassword = "********";
            Role = userModel.Role;
            Trains = userModel.Trains?.Select((data) => new TrainResponse(data)).ToList();
            Vehicles = userModel.Vehicles?.Select((data) => new VehicleResponse(data)).ToList();
            
        }
        public List<TrainResponse> Trains { get; set; }
        public List<VehicleResponse> Vehicles { get; set; }
    }
}
