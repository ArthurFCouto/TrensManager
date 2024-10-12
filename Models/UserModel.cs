using TrensManager.Enums;

namespace TrensManager.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public required string UserName { get; set; }
        public required string UserPassword { get; set; }
        public required UserRoles Role { get; set; }
    }
}
