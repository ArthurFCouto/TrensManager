using Microsoft.EntityFrameworkCore;
using TrensManager.Data;
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

        public async Task<TrainModel> Add(TrainModel train)
        {
            List<VehicleModel> vehicles = new List<VehicleModel>();
            List<string> codes = new List<string>();

            if (train.VehicleCodes != null && train.VehicleCodes.Count > 0)
            {
                foreach (string code in train.VehicleCodes)
                {
                    VehicleModel vehicle = await _dbContext.Vehicle.FirstOrDefaultAsync((data) => data.Code == code);
                    if (vehicle != null)
                    {
                        vehicles.Add(vehicle);
                        codes.Add(code);
                    }
                }
            }

            train.VehicleCodes = codes;
            train.Vehicles = vehicles;
            await _dbContext.Train.AddAsync(train);
            await _dbContext.SaveChangesAsync();

            return train;
        }

        public async Task<List<TrainModel>> GetAll()
        {
            return await _dbContext.Train
                .Include((data) => data.Vehicles)
                .ToListAsync();
        }

        public async Task<TrainModel> GetById(int id)
        {
            return await _dbContext.Train
                .Include((data) => data.Vehicles)
                .FirstOrDefaultAsync((data) => data.Id == id) ?? throw new Exception($"The Train with Id {id} isn't found in the database."); ;
        }

        public async Task<TrainModel> Update(TrainModel train, int id)
        {
            TrainModel trainById = await GetById(id);

            trainById.NumberOS = train.NumberOS;
            trainById.Origin = train.Origin;
            trainById.Destination = train.Destination;

            List<VehicleModel> vehicles = new List<VehicleModel>();
            List<string> codes = new List<string>();

            if (train.VehicleCodes != null && train.VehicleCodes.Count > 0)
            {
                foreach (string code in train.VehicleCodes)
                {
                    VehicleModel vehicle = await _dbContext.Vehicle.FirstOrDefaultAsync((data) => data.Code == code);
                    if (vehicle != null)
                    {
                        vehicles.Add(vehicle);
                        codes.Add(code);
                    }
                }
            }

            trainById.VehicleCodes = codes;
            trainById.Vehicles = vehicles;

            _dbContext.Train.Update(trainById);
            await _dbContext.SaveChangesAsync();

            return trainById;
        }

        public async Task<bool> Delete(int id)
        {
            TrainModel trainById = await GetById(id);

            _dbContext.Train.Remove(trainById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
