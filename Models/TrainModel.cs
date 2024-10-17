namespace TrensManager.Models
{
    public class TrainModel
    {
        public required DateTime CreatedAt { get; set; }
        public required int CreatedByUserID { get; set; }
        public required string Destination { get; set; }
        public int Id { get; set; }
        public required int OSNumber { get; set; }
        public required string Origin { get; set; }
        public required DateTime UpdatedAt { get; set; }
        public required int UpdatedByUserID { get; set; }
        public required UserModel User { get; set; }
        public required int UserID { get; set; }
        public ICollection<VehicleModel>? Vehicles { get; set; }
    }
}
