using System.Text.Json.Serialization;
using TrensManager.Enums;

namespace TrensManager.Models
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public required VehicleType Type { get; set; }
        public required string Code { get; set; }
        public int? TrainId { get; set; }
        [JsonIgnore]
        public TrainModel? Train { get; set; }
    }
}
