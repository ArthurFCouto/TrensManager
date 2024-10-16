using TrensManager.Models;

namespace TrensManager.DTO.TrainDTO
{
    public class TrainResponseWithoutVehicles
    {
        public TrainResponseWithoutVehicles(TrainModel trainModel) { 
            CreatedAt = trainModel.CreatedAt;
            CreatedByUser = trainModel.CreatedByUser;
            Destination = trainModel.Destination;
            Id = trainModel.Id;
            OSNumber = trainModel.OSNumber;
            Origin = trainModel.Origin;
            UpdatedAt = trainModel.UpdatedAt;
            UpdatedByUser = trainModel.UpdatedByUser;
        }
        public DateTime CreatedAt { get; set; }
        public string CreatedByUser { get; set; }
        public string Destination { get; set; }
        public int Id { get; set; }
        public int OSNumber { get; set; }
        public string Origin { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedByUser { get; set; }
    }
}
