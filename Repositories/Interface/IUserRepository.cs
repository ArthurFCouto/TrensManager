using TrensManager.DTO.UserDTO;
using TrensManager.Models;

namespace TrensManager.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<List<UserResponse>> GetAll();
        Task<UserResponse> GetById(int id);
        Task<UserResponseWithPassword> GetByUserName(string userName);
        Task<UserResponseWithToken> Add(UserRequest userReques);
        Task<UserResponse> Update(UserRequest userRequest, int id);
        Task<bool> Delete(int id);
    }
}
