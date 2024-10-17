using Microsoft.EntityFrameworkCore;
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

        public async Task<TrainResponse> Add(TrainRequest trainRequest, int userID)
        {
            UserModel userModel = await _dbContext.User.FirstOrDefaultAsync((data) => data.Id == userID);
            if (userModel == null)
                throw new Exception($"Chack your token! The user with Id {userID} isn't found in the database.");

            TrainModel trainModel = new TrainModel
            {
                CreatedAt = DateTime.Now,
                CreatedByUserID = userID,
                Destination = trainRequest.Destination,
                OSNumber = trainRequest.OSNumber,
                Origin = trainRequest.Origin,
                UpdatedAt = DateTime.Now,
                UpdatedByUserID = userID,
                User = userModel,
                UserID = userID
            };

            if (trainRequest.VehicleCodes != null && trainRequest.VehicleCodes.Count > 0)
            {
                List<VehicleModel> vehicleModelList = new List<VehicleModel>();

                foreach (string code in trainRequest.VehicleCodes)
                {
                    VehicleModel vehicleModel = await _dbContext.Vehicle.FirstOrDefaultAsync((data) => data.Code == code);
                    if (vehicleModel != null)
                        vehicleModelList.Add(vehicleModel);
                }

                if (vehicleModelList.Count > 0)
                    trainModel.Vehicles = vehicleModelList;
            }

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
            if (trainModel == null)
                throw new Exception($"The Train with Id {id} isn't found in the database.");

            return new TrainResponse(trainModel);
        }

        public async Task<TrainResponse> GetByOS(int os)
        {
            TrainModel trainModel = await _dbContext.Train.Include((data) => data.Vehicles).FirstOrDefaultAsync((data) => data.OSNumber == os);
            if (trainModel == null)
                throw new Exception($"The Train with OS number {os} isn't found in the database.");

            return new TrainResponse(trainModel);
        }

        public async Task<TrainResponse> Update(TrainRequest trainRequest, int id, int userID)
        {
            UserModel userModel = await _dbContext.User.FirstOrDefaultAsync((data) => data.Id == userID);
            if (userModel == null)
                throw new Exception($"Chack your token! The user with Id {userID} isn't found in the database.");

            TrainModel trainModel = await _dbContext.Train.Include((data) => data.Vehicles).FirstOrDefaultAsync((data) => data.Id == id);
            if (trainModel == null)
                throw new Exception($"The Train with Id {id} isn't found in the database.");

            trainModel.Destination = trainRequest.Destination;
            trainModel.OSNumber = trainRequest.OSNumber;
            trainModel.Origin = trainRequest.Origin;
            trainModel.UpdatedAt = DateTime.Now;
            trainModel.UpdatedByUserID = userID;
            trainModel.User = userModel;
            trainModel.UserID = userID;

            if (trainRequest.VehicleCodes != null && trainRequest.VehicleCodes.Count > 0)
            {
                List<VehicleModel> vehicleModelList = new List<VehicleModel>();

                foreach (string code in trainRequest.VehicleCodes)
                {
                    VehicleModel vehicleModel = await _dbContext.Vehicle.FirstOrDefaultAsync((data) => data.Code == code);
                    if (vehicleModel != null)
                        vehicleModelList.Add(vehicleModel);
                }

                if (vehicleModelList.Count > 0)
                    trainModel.Vehicles = vehicleModelList;
            }

            _dbContext.Train.Update(trainModel);
            await _dbContext.SaveChangesAsync();

            return new TrainResponse(trainModel);
        }

        public async Task<bool> Delete(int id)
        {
            TrainModel trainModel = await _dbContext.Train.Include((data) => data.Vehicles).FirstOrDefaultAsync((data) => data.Id == id);
            if (trainModel == null)
                throw new Exception($"The Train with Id {id} isn't found in the database.");

            _dbContext.Train.Remove(trainModel);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
