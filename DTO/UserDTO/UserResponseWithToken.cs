using TrensManager.Models;

namespace TrensManager.DTO.UserDTO
{
    public class UserResponseWithToken : UserResponse
    {
        public UserResponseWithToken(UserModel userModel, string token) : base(userModel)
        {
            Id = userModel.Id;
            UserName = userModel.UserName;
            UserPassword = "********";
            Role = userModel.Role;
            Token = token;
        }
        public string Token { get; set; }
    }
}
