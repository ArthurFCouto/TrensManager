using Microsoft.EntityFrameworkCore;
using TrensManager.Data;
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
        public async Task<VehicleModel> Add(VehicleModel vehicle)
        {
            await _dbContext.AddAsync(vehicle);
            await _dbContext.SaveChangesAsync();
            return vehicle;
        }
        public async Task<List<VehicleModel>> GetAll()
        {
            return await _dbContext.Vehicle.Include((data) => data.Train).ToListAsync();
        }

        public async Task<VehicleModel> GetByCode(string code)
        {
            return await _dbContext.Vehicle.Include((data) => data.Train).FirstOrDefaultAsync((data)=> data.Code == code) ?? throw new Exception($"The Vehicle with Code {code} isn't found in the database."); ;
        }

        public async Task<VehicleModel> GetById(int id)
        {
            return await _dbContext.Vehicle.Include((data) => data.Train).FirstOrDefaultAsync((data)=> data.Id == id) ?? throw new Exception($"The Vehicle with Id {id} isn't found in the database."); ;
        }

        public async Task<VehicleModel> Update(VehicleModel vehicle, int id)
        {

            VehicleModel vehicleById = await GetById(id);

            vehicleById.Type = vehicle.Type;
            vehicleById.Code = vehicle.Code;
            vehicleById.TrainId = vehicle.TrainId;

            _dbContext.Vehicle.Update(vehicleById);
            await _dbContext.SaveChangesAsync();

            return vehicleById;
        }

        public async Task<bool> Delete(int id)
        {
            VehicleModel vehicleById = await GetById(id);

            _dbContext.Remove(vehicleById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
