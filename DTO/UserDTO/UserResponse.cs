using TrensManager.Enums;
using TrensManager.Models;

namespace TrensManager.DTO.UserDTO
{
    public class UserResponse
    {
        public UserResponse(UserModel userModel)
        {
            Id = userModel.Id;
            UserName = userModel.UserName;
            UserPassword = "********";
            Roles = userModel.Roles;
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public UserRoles Roles { get; set; }
    }
}
