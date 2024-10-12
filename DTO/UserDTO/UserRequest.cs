using TrensManager.Enums;

namespace TrensManager.DTO.UserDTO
{
    public class UserRequest
    {
            public required string UserName { get; set; }
            public required string UserPassword { get; set; }
    }
}
