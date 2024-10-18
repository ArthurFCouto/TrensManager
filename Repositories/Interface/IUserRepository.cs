using TrensManager.DTO.UserDTO;
using TrensManager.Models;

namespace TrensManager.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<UserResponseWithToken> Add(UserRequest userReques);
        Task<bool> Delete(int id);
        Task<List<UserResponse>> GetAll();
        Task<UserResponse> GetById(int id);
        Task<UserResponseWithPassword> GetByUserName(string userName);
        Task<UserResponseBase> Update(UserRequest userRequest, int id);
    }
}
