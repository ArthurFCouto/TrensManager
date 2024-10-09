using TrensManager.Models;

namespace TrensManager.Repositories.Interface
{
    public interface IVehicleRepository
    {
        Task<List<VehicleModel>> GetAll();
        Task<VehicleModel> GetByCode(string code);
        Task<VehicleModel> GetById(int id);
        Task<VehicleModel> Add(VehicleModel vehicle);
        Task<VehicleModel> Update(VehicleModel vehicle, int id);
        Task<bool> Delete(int id);
    }
}
