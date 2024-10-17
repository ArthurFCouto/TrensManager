using TrensManager.DTO.VehicleDTO;

namespace TrensManager.Repositories.Interface
{
    public interface IVehicleRepository
    {
        Task<VehicleResponse> Add(VehicleRequest vehicleRequest, int userID);
        Task<bool> Delete(int id);
        Task<List<VehicleResponse>> GetAll();
        Task<VehicleResponse> GetByCode(string code);
        Task<VehicleResponse> GetById(int id);
        Task<VehicleResponse> Update(VehicleRequest vehicleRequest, int id, int userID);
    }
}
