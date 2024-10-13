using TrensManager.Models;

namespace TrensManager.DTO.UserDTO
{
    public class UserResponseWithPassword : UserResponse
    {
        public UserResponseWithPassword(UserModel userModel) : base(userModel)
        {
            Id = userModel.Id;
            Role = userModel.Role;
            UserName = userModel.UserName;
            UserPassword = userModel.UserPassword;
        }
    }
}
