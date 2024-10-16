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
        public async Task<VehicleResponse> Add(VehicleRequest vehicleRequest, string userName)
        {
            List<TrainModel> trainModelList = new List<TrainModel>();

            if (vehicleRequest.TrainOSNumber != null && vehicleRequest.TrainOSNumber.Count > 0)
            {
                foreach (int OSNumber in vehicleRequest.TrainOSNumber)
                {
                    TrainModel trainModel = await _dbContext.Train.FirstOrDefaultAsync((data) => data.OSNumber == OSNumber);
                    if (trainModel != null)
                        trainModelList.Add(trainModel);
                }
            }

            VehicleModel vehicleModel = new VehicleModel
            {
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Code = vehicleRequest.Code,
                Trains = trainModelList,
                Type = vehicleRequest.Type,
                CreatedByUser = userName,
                UpdatedByUser = userName
            };
            await _dbContext.AddAsync(vehicleModel);
            await _dbContext.SaveChangesAsync();
            return new VehicleResponse(vehicleModel);
        }
        public async Task<List<VehicleResponse>> GetAll()
        {
            List<VehicleModel> vehicleModelList = await _dbContext.Vehicle.Include((data) => data.Trains).ToListAsync();
            return vehicleModelList.Select((vehicleModel) => new VehicleResponse(vehicleModel)).ToList();
        }

        public async Task<VehicleResponse> GetByCode(string code)
        {
            VehicleModel vehicleModel = await _dbContext.Vehicle.Include((data) => data.Trains).FirstOrDefaultAsync((data) => data.Code == code);
            if (vehicleModel == null) throw new Exception($"The Vehicle with Code {code} isn't found in the database.");
            return new VehicleResponse(vehicleModel);
        }

        public async Task<VehicleResponse> GetById(int id)
        {
            VehicleModel vehicleModel = await _dbContext.Vehicle.Include((data) => data.Trains).FirstOrDefaultAsync((data) => data.Id == id);
            if (vehicleModel == null) throw new Exception($"The Vehicle with Id {id} isn't found in the database.");
            return new VehicleResponse(vehicleModel);
        }

        public async Task<VehicleResponse> Update(VehicleRequest vehicleRequest, int id, string userName)
        {
            VehicleModel vehicleModel = await _dbContext.Vehicle.Include((data) => data.Trains).FirstOrDefaultAsync((data) => data.Id == id);
            if (vehicleModel == null) throw new Exception($"The Vehicle with Id {id} isn't found in the database.");

            List<TrainModel> trainModelList = new List<TrainModel>();

            if (vehicleRequest.TrainOSNumber != null && vehicleRequest.TrainOSNumber.Count > 0)
            {
                foreach (int OSNumber in vehicleRequest.TrainOSNumber)
                {
                    TrainModel trainModel = await _dbContext.Train.FirstOrDefaultAsync((data) => data.OSNumber == OSNumber);
                    if (trainModel != null)
                        trainModelList.Add(trainModel);
                }
            }

            vehicleModel.UpdatedByUser = userName;
            vehicleModel.Code = vehicleRequest.Code;
            vehicleModel.Trains = trainModelList;
            vehicleModel.Type = vehicleRequest.Type;
            vehicleModel.UpdatedAt = DateTime.Now;

            _dbContext.Vehicle.Update(vehicleModel);
            await _dbContext.SaveChangesAsync();

            return new VehicleResponse(vehicleModel);
        }

        public async Task<bool> Delete(int id)
        {
            VehicleModel vehicleModel = await _dbContext.Vehicle.Include((data) => data.Trains).FirstOrDefaultAsync((data) => data.Id == id);
            if (vehicleModel == null) throw new Exception($"The Vehicle with Id {id} isn't found in the database.");

            _dbContext.Remove(vehicleModel);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
