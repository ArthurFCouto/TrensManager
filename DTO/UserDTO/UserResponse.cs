using TrensManager.Enums;
using TrensManager.Models;

namespace TrensManager.DTO.UserDTO
{
    public class UserResponse
    {
        public UserResponse(UserModel userModel)
        {
            CreatedAt = userModel.CreatedAt;
            Id = userModel.Id;
            UpdatedAt = userModel.UpdatedAt;
            UserName = userModel.UserName;
            UserPassword = "********";
            Role = userModel.Role;
        }
        public DateTime CreatedAt { get; set; }
        public int Id { get; set; }
        public UserRoles Role { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
}
