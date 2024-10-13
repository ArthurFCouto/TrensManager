using TrensManager.DTO.VehicleDTO;

namespace TrensManager.Repositories.Interface
{
    public interface IVehicleRepository
    {
        Task<List<VehicleResponse>> GetAll();
        Task<VehicleResponse> GetByCode(string code);
        Task<VehicleResponse> GetById(int id);
        Task<VehicleResponse> Add(VehicleRequest vehicleRequest);
        Task<VehicleResponse> Update(VehicleRequest vehicleRequest, int id);
        Task<bool> Delete(int id);
    }
}
