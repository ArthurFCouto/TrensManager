// Task é o indicativo que o método é assíncrono.

using TrensManager.DTO.TrainDTO;
using TrensManager.Models;

namespace TrensManager.Repositories.Interface
{
    public interface ITrainRepository
    {
        Task<TrainResponse> Add(TrainRequest trainRequest, string userName);
        Task<bool> Delete(int id);
        Task<List<TrainResponse>> GetAll();
        Task<TrainResponse> GetById(int id);
        Task<TrainResponse> Update(TrainRequest trainRequest, int id, string userName);
    }
}
