// Task é o indicativo que o método é assíncrono.

using TrensManager.Models;

namespace TrensManager.Repositories.Interface
{
    public interface ITrainRepository
    {
        Task<List<TrainModel>> GetAll();
        Task<TrainModel> GetById(int id);
        Task<TrainModel> Add(TrainModel train);
        Task<TrainModel> Update(TrainModel train, int id);
        Task<bool> Delete(int id);
    }
}
