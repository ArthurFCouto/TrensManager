namespace TrensManager.Models
{
    public class TrainModel
    {
        public int Id { get; set; }
        public required int NumberOS { get; set; }
        public required string Origin { get; set; }
        public required string Destination { get; set; }
        public List<string>? VehicleCodes { get; set; }
        public  ICollection<VehicleModel>? Vehicles { get; set; }
    }
}
