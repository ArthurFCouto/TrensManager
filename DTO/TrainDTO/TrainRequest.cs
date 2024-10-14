using TrensManager.DTO.VehicleDTO;

namespace TrensManager.DTO.TrainDTO
{
    public class TrainRequest
    {
        public required string Destination { get; set; }
        public required int NumberOS { get; set; }
        public required string Origin { get; set; }
        public List<string>? VehicleCodes { get; set; }
        public List<VehicleResponseWithoutTrain>? Vehicles { get; set; }
    }
}
