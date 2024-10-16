namespace TrensManager.DTO.TrainDTO
{
    public class TrainRequest
    {
        public required string Destination { get; set; }
        public required int OSNumber { get; set; }
        public required string Origin { get; set; }
        public List<string>? VehicleCodes { get; set; }
    }
}
