﻿using TrensManager.DTO.VehicleDTO;
using TrensManager.Models;

namespace TrensManager.DTO.TrainDTO
{
    public class TrainResponse
    {
        public TrainResponse(TrainModel trainModel) { 
            CreatedAt = trainModel.CreatedAt;
            CreatedByUser = trainModel.CreatedByUser;
            Destination = trainModel.Destination;
            Id = trainModel.Id;
            NumberOS = trainModel.NumberOS;
            Origin = trainModel.Origin;
            UpdatedAt = trainModel.UpdatedAt;
            UpdatedByUser = trainModel.UpdatedByUser;
            Vehicles = trainModel.Vehicles?.Select((vehicle) => new VehicleResponseWithoutTrain(vehicle)).ToList();
        }
        public DateTime CreatedAt { get; set; }
        public string CreatedByUser { get; set; }
        public string Destination { get; set; }
        public int Id { get; set; }
        public int NumberOS { get; set; }
        public string Origin { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedByUser { get; set; }
        public List<VehicleResponseWithoutTrain>? Vehicles { get; set; }
    }
}
