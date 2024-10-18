using TrensManager.Models;

namespace TrensManager.DTO.UserDTO
{
    public class UserResponseWithPassword : UserResponseBase
    {
        public UserResponseWithPassword(UserModel userModel) : base(userModel)
        {
            CreatedAt = userModel.CreatedAt;
            Id = userModel.Id;
            Role = userModel.Role;
            UpdatedAt = userModel.UpdatedAt;
            UserName = userModel.UserName;
            UserPassword = userModel.UserPassword;
        }
    }
}
