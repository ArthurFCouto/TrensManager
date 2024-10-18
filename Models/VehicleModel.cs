using TrensManager.Enums;

namespace TrensManager.Models
{
    public class VehicleModel
    {
        public required string Code { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required int CreatedByUserID { get; set; }
        public int Id { get; set; }
        public ICollection<TrainModel>? Trains { get; set; }
        public required VehicleType Type { get; set; }
        public required DateTime UpdatedAt { get; set; }
        public required int UpdatedByUserID { get; set; }
        public virtual UserModel User { get; set; }
        public required int UserID { get; set; }
    }
}
