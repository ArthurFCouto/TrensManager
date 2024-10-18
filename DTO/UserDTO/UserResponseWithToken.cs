using TrensManager.Models;

namespace TrensManager.DTO.UserDTO
{
    public class UserResponseWithToken : UserResponseBase
    {
        public UserResponseWithToken(UserModel userModel, string token) : base(userModel)
        {
            CreatedAt = userModel.CreatedAt;
            Id = userModel.Id;
            Role = userModel.Role;
            Token = token;
            UpdatedAt = userModel.UpdatedAt;
            UserName = userModel.UserName;
            UserPassword = "********";
        }
        public string Token { get; set; }
    }
}
