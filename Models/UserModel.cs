using TrensManager.Enums;

namespace TrensManager.Models
{
    public class UserModel
    {
        public required DateTime CreatedAt { get; set; }
        public int Id { get; set; }
        public required UserRoles Role { get; set; }
        public ICollection<TrainModel>? Trains { get; set; }
        public required DateTime UpdatedAt { get; set; }
        public required string UserName { get; set; }
        public required string UserPassword { get; set; }
        public ICollection<VehicleModel>? Vehicles { get; set; }

    }
}
