using System.ComponentModel;

namespace TrensManager.Enums
{
    public enum UserRoles
    {
        [Description("User Admin")]
        Admin = 1,
        [Description("User Default")]
        User = 2,
    }
}
