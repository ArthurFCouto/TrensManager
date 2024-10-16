﻿using Microsoft.EntityFrameworkCore;
using TrensManager.Data;
using TrensManager.DTO.TrainDTO;
using TrensManager.Models;
using TrensManager.Repositories.Interface;

namespace TrensManager.Repositories
{
    public class TrainRepository : ITrainRepository
    {
        private readonly TrainSystemDBContext _dbContext;
        public TrainRepository(TrainSystemDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TrainResponse> Add(TrainRequest trainRequest, string userName)
        {
            List<VehicleModel> vehicleModelList = new List<VehicleModel>();

            if (trainRequest.VehicleCodes != null && trainRequest.VehicleCodes.Count > 0)
            {
                foreach (string code in trainRequest.VehicleCodes)
                {
                    VehicleModel vehicleModel = await _dbContext.Vehicle.FirstOrDefaultAsync((data) => data.Code == code);
                    if (vehicleModel != null)
                        vehicleModelList.Add(vehicleModel);
                }
            }

            TrainModel trainModel = new TrainModel
            {
                CreatedAt = DateTime.Now,
                CreatedByUser = userName,
                Destination = trainRequest.Destination,
                OSNumber = trainRequest.OSNumber,
                Origin = trainRequest.Origin,
                UpdatedAt = DateTime.Now,
                UpdatedByUser = userName,
                Vehicles = vehicleModelList
            };

            await _dbContext.Train.AddAsync(trainModel);
            await _dbContext.SaveChangesAsync();

            return new TrainResponse(trainModel);
        }

        public async Task<List<TrainResponse>> GetAll()
        {
            List<TrainModel> trainModelList = await _dbContext.Train
                .Include((data) => data.Vehicles)
                .ToListAsync();
            return trainModelList.Select((trainModel) => new TrainResponse(trainModel)).ToList();
        }

        public async Task<TrainResponse> GetById(int id)
        {
            TrainModel trainModel = await _dbContext.Train.Include((data) => data.Vehicles).FirstOrDefaultAsync((data) => data.Id == id);
            if (trainModel == null) throw new Exception($"The Train with Id {id} isn't found in the database.");
            return new TrainResponse(trainModel);
        }

        public async Task<TrainResponse> GetByOS(int os)
        {
            TrainModel trainModel = await _dbContext.Train.Include((data) => data.Vehicles).FirstOrDefaultAsync((data) => data.NumberOS == os);
            if (trainModel == null) throw new Exception($"The Train with OS number {os} isn't found in the database.");
            return new TrainResponse(trainModel);
        }

        public async Task<TrainResponse> Update(TrainRequest trainRequest, int id, string userName)
        {
            TrainModel trainModel = await _dbContext.Train.Include((data) => data.Vehicles).FirstOrDefaultAsync((data) => data.Id == id);
            if (trainModel == null) throw new Exception($"The Train with Id {id} isn't found in the database.");

            List<VehicleModel> vehicleModelList = new List<VehicleModel>();

            if (trainRequest.VehicleCodes != null && trainRequest.VehicleCodes.Count > 0)
            {
                foreach (string code in trainRequest.VehicleCodes)
                {
                    VehicleModel vehicleModel = await _dbContext.Vehicle.FirstOrDefaultAsync((data) => data.Code == code);
                    if (vehicleModel != null)
                        vehicleModelList.Add(vehicleModel);
                }
            }

            trainModel.Destination = trainRequest.Destination;
            trainModel.OSNumber = trainRequest.OSNumber;
            trainModel.Origin = trainRequest.Origin;
            trainModel.UpdatedAt = DateTime.Now;
            trainModel.UpdatedByUser = userName;
            trainModel.Vehicles = vehicleModelList;

            _dbContext.Train.Update(trainModel);
            await _dbContext.SaveChangesAsync();

            return new TrainResponse(trainModel);
        }

        public async Task<bool> Delete(int id)
        {
            TrainModel trainModel = await _dbContext.Train.Include((data) => data.Vehicles).FirstOrDefaultAsync((data) => data.Id == id);
            if (trainModel == null) throw new Exception($"The Train with Id {id} isn't found in the database.");

            _dbContext.Train.Remove(trainModel);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
