using Microsoft.EntityFrameworkCore;
using TrensManager.Data;
using TrensManager.Models;
using TrensManager.Repositories.Interface;

namespace TrensManager.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TrainSystemDBContext _dbContext;
        public UserRepository(TrainSystemDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserModel> Add(UserModel user)
        {
            user.Roles = Enums.UserRoles.User;
            await _dbContext.User.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<List<UserModel>> GetAll()
        {
            List<UserModel> users = await _dbContext.User.ToListAsync();
            users.Select((user) => new { user.Id, user.UserName, UserPassword = "********", user.Roles }).ToList();
            return users;
        }

        public async Task<UserModel> GetById(int id)
        {
            UserModel user = await _dbContext.User.FirstOrDefaultAsync((data) => data.Id == id);
            if (user == null) throw new Exception($"The user with Id {id} isn't found in the database.");
            user.UserPassword = "********";
            return user;
        }

        public async Task<UserModel> GetByUserName(string userName)
        {
            return await _dbContext.User.FirstOrDefaultAsync((data) => data.UserName == userName) ?? throw new Exception($"The user with UserName {userName} isn't found in the database.");
        }

        public async Task<UserModel> Update(UserModel user, int id)
        {
            UserModel userById = await GetById(id);

            userById.UserName = user.UserName;
            userById.UserPassword = user.UserPassword;
            userById.Roles = user.Roles;

            _dbContext.User.Update(userById);
            await _dbContext.SaveChangesAsync();

            return userById;
        }

        public async Task<bool> Delete(int id)
        {
            UserModel userById = await GetById(id);

            _dbContext.User.Remove(userById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
