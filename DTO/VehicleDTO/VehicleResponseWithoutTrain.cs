using TrensManager.DTO.UserDTO;
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
            CreatedByUserID = vehicleModel.CreatedByUserID;
            Id = vehicleModel.Id;
            Type = vehicleModel.Type;
            UpdatedAt = vehicleModel.UpdatedAt;
            UpdatedByUserID = vehicleModel.UpdatedByUserID;
            User = new UserResponseBase(vehicleModel.User);
        }
        public string Code { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedByUserID { get; set; }
        public int Id { get; set; }
        public VehicleType Type { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedByUserID { get; set; }
        public UserResponseBase User { get; set; }
    }
}
