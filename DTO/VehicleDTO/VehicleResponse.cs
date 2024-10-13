using TrensManager.Enums;
using TrensManager.Models;

namespace TrensManager.DTO.VehicleDTO
{
    public class VehicleResponse
    {
        public VehicleResponse(VehicleModel vehicleModel) {
            Id = vehicleModel.Id;
            Type = vehicleModel.Type;
            Code = vehicleModel.Code;
            TrainId = vehicleModel.TrainId;
        }
        public string Code { get; set; }
        public int Id { get; set; }
        public int? TrainId { get; set; }
        public VehicleType Type { get; set; }
    }
}
