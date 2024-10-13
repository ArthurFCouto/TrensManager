using TrensManager.Models;

namespace TrensManager.DTO.UserDTO
{
    public class UserResponseWithToken : UserResponse
    {
        public UserResponseWithToken(UserModel userModel, string token) : base(userModel)
        {
            Id = userModel.Id;
            Role = userModel.Role;
            Token = token;
            UserName = userModel.UserName;
            UserPassword = "********";
        }
        public string Token { get; set; }
    }
}
