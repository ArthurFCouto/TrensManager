namespace TrensManager.Models
{
    public class TrainModel
    {
        public required DateTime CreatedAt { get; set; }
        public required string CreatedByUser { get; set; }
        public required string Destination { get; set; }
        public int Id { get; set; }
        public required int NumberOS { get; set; }
        public required string Origin { get; set; }
        public required DateTime UpdatedAt { get; set; }
        public required string UpdatedByUser { get; set; }
        public ICollection<VehicleModel>? Vehicles { get; set; }
    }
}
