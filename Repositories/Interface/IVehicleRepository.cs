using TrensManager.DTO.VehicleDTO;

namespace TrensManager.Repositories.Interface
{
    public interface IVehicleRepository
    {
        Task<List<VehicleResponse>> GetAll();
        Task<VehicleResponse> GetByCode(string code);
        Task<VehicleResponse> GetById(int id);
        Task<VehicleResponse> Add(VehicleRequest vehicleRequest, string UserName);
        Task<VehicleResponse> Update(VehicleRequest vehicleRequest, int id, string UserName);
        Task<bool> Delete(int id);
    }
}
