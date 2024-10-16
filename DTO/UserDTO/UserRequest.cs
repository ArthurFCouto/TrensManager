using System.ComponentModel.DataAnnotations;

namespace TrensManager.DTO.UserDTO
{
    public class UserRequest
    {
        [MaxLength(64)]
        [MinLength(8)]
        [Required]
        public required string UserName { get; set; }
        [MaxLength(32)]
        [MinLength(8)]
        [Required]
        public required string UserPassword { get; set; }
    }
}
