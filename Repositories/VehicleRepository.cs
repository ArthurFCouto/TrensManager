﻿using Microsoft.EntityFrameworkCore;
using TrensManager.Data;
using TrensManager.DTO.VehicleDTO;
using TrensManager.Models;
using TrensManager.Repositories.Interface;

namespace TrensManager.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly TrainSystemDBContext _dbContext;
        public VehicleRepository(TrainSystemDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<VehicleResponse> Add(VehicleRequest vehicleRequest)
        {
            VehicleModel vehicleModel = new VehicleModel
            {
                Code = vehicleRequest.Code,
                Type = vehicleRequest.Type,
                TrainId = vehicleRequest.TrainId
            };
            await _dbContext.AddAsync(vehicleModel);
            await _dbContext.SaveChangesAsync();
            return new VehicleResponse(vehicleModel);
        }
        public async Task<List<VehicleResponse>> GetAll()
        {
            List<VehicleModel> vehicleModelList = await _dbContext.Vehicle.Include((data) => data.Train).ToListAsync();
            return vehicleModelList.Select((vehicleModel) => new VehicleResponse(vehicleModel)).ToList();
        }

        public async Task<VehicleResponse> GetByCode(string code)
        {
            VehicleModel vehicleModel = await _dbContext.Vehicle.Include((data) => data.Train).FirstOrDefaultAsync((data) => data.Code == code);
            if (vehicleModel == null) throw new Exception($"The Vehicle with Code {code} isn't found in the database.");
            return new VehicleResponse(vehicleModel);
        }

        public async Task<VehicleResponse> GetById(int id)
        {
            VehicleModel vehicleModel = await _dbContext.Vehicle.Include((data) => data.Train).FirstOrDefaultAsync((data) => data.Id == id);
            if (vehicleModel == null) throw new Exception($"The Vehicle with Id {id} isn't found in the database.");
            return new VehicleResponse(vehicleModel);
        }

        public async Task<VehicleResponse> Update(VehicleRequest vehicleRequest, int id)
        {
            VehicleModel vehicleModel = await _dbContext.Vehicle.Include((data) => data.Train).FirstOrDefaultAsync((data) => data.Id == id);
            if (vehicleModel == null) throw new Exception($"The Vehicle with Id {id} isn't found in the database.");

            vehicleModel.Code = vehicleRequest.Code;
            vehicleModel.Id = id;
            vehicleModel.TrainId = vehicleRequest.TrainId;
            vehicleModel.Type = vehicleRequest.Type;

            _dbContext.Vehicle.Update(vehicleModel);
            await _dbContext.SaveChangesAsync();

            return new VehicleResponse(vehicleModel);
        }

        public async Task<bool> Delete(int id)
        {
            VehicleModel vehicleModel = await _dbContext.Vehicle.Include((data) => data.Train).FirstOrDefaultAsync((data) => data.Id == id);
            if (vehicleModel == null) throw new Exception($"The Vehicle with Id {id} isn't found in the database.");

            _dbContext.Remove(vehicleModel);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
