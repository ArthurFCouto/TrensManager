using Microsoft.EntityFrameworkCore;
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
        public async Task<VehicleResponse> Add(VehicleRequest vehicleRequest, int userID)
        {
            UserModel userModel = await _dbContext.User.FirstOrDefaultAsync((data) => data.Id == userID);
            if (userModel == null)
                throw new Exception($"Check your token. Cannot recover information about the user.");

            VehicleModel vehicleModel = new VehicleModel
            {
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Code = vehicleRequest.Code,
                Type = vehicleRequest.Type,
                CreatedByUserID = userID,
                UpdatedByUserID = userID,
                User = userModel,
                UserID = userID
            };

            if (vehicleRequest.TrainOSNumberList != null && vehicleRequest.TrainOSNumberList.Count > 0)
            {
                List<TrainModel> trainModelList = new List<TrainModel>();
                foreach (int OSNumber in vehicleRequest.TrainOSNumberList)
                {
                    TrainModel trainModel = await _dbContext.Train.Include((data) => data.User).FirstOrDefaultAsync((data) => data.OSNumber == OSNumber);
                    if (trainModel != null)
                        trainModelList.Add(trainModel);
                }
                if (trainModelList.Count > 0)
                    vehicleModel.Trains = trainModelList;
            }

            await _dbContext.AddAsync(vehicleModel);
            await _dbContext.SaveChangesAsync();

            return new VehicleResponse(vehicleModel);
        }
        public async Task<List<VehicleResponse>> GetAll()
        {
            List<VehicleModel> vehicleModelList = await _dbContext.Vehicle.Include((data) => data.Trains).Include((data) => data.User).ToListAsync();
            return vehicleModelList.Select((vehicleModel) => new VehicleResponse(vehicleModel)).ToList();
        }

        public async Task<VehicleResponse> GetByCode(string code)
        {
            VehicleModel vehicleModel = await _dbContext.Vehicle.Include((data) => data.Trains).Include((data) => data.User).FirstOrDefaultAsync((data) => data.Code == code);
            if (vehicleModel == null)
                throw new Exception($"The Vehicle with Code {code} isn't found in the database.");

            return new VehicleResponse(vehicleModel);
        }

        public async Task<VehicleResponse> GetById(int id)
        {
            VehicleModel vehicleModel = await _dbContext.Vehicle.Include((data) => data.Trains).Include((data) => data.User).FirstOrDefaultAsync((data) => data.Id == id);
            if (vehicleModel == null)
                throw new Exception($"The Vehicle with Id {id} isn't found in the database.");

            return new VehicleResponse(vehicleModel);
        }

        public async Task<VehicleResponse> Update(VehicleRequest vehicleRequest, int id, int userID)
        {
            UserModel userModel = await _dbContext.User.FirstOrDefaultAsync((data) => data.Id == userID);
            if (userModel == null)
                throw new Exception($"Check your token. Cannot recover information about the user.");

            VehicleModel vehicleModel = await _dbContext.Vehicle.Include((data) => data.Trains).Include((data) => data.User).FirstOrDefaultAsync((data) => data.Id == id);
            if (vehicleModel == null)
                throw new Exception($"The Vehicle with Id {id} isn't found in the database.");

            vehicleModel.UpdatedByUserID = userID;
            vehicleModel.Code = vehicleRequest.Code;
            vehicleModel.Type = vehicleRequest.Type;
            vehicleModel.UpdatedAt = DateTime.Now;
            vehicleModel.User = userModel;
            vehicleModel.UserID = userID;

            if (vehicleRequest.TrainOSNumberList != null && vehicleRequest.TrainOSNumberList.Count > 0)
            {
                List<TrainModel> trainModelList = new List<TrainModel>();
                foreach (int OSNumber in vehicleRequest.TrainOSNumberList)
                {
                    TrainModel trainModel = await _dbContext.Train.Include((data) => data.User).FirstOrDefaultAsync((data) => data.OSNumber == OSNumber);
                    if (trainModel != null)
                        trainModelList.Add(trainModel);
                }
                if (trainModelList.Count > 0)
                    vehicleModel.Trains = trainModelList;
            }

            _dbContext.Vehicle.Update(vehicleModel);
            await _dbContext.SaveChangesAsync();

            return new VehicleResponse(vehicleModel);
        }

        public async Task<bool> Delete(int id)
        {
            VehicleModel vehicleModel = await _dbContext.Vehicle.FirstOrDefaultAsync((data) => data.Id == id);
            if (vehicleModel == null)
                throw new Exception($"The Vehicle with Id {id} isn't found in the database.");

            _dbContext.Remove(vehicleModel);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
