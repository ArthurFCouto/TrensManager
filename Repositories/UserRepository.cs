﻿using Microsoft.EntityFrameworkCore;
using TrensManager.Data;
using TrensManager.DTO.UserDTO;
using TrensManager.Models;
using TrensManager.Repositories.Interface;
using TrensManager.Services;

namespace TrensManager.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TrainSystemDBContext _dbContext;
        public UserRepository(TrainSystemDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserResponseWithToken> Add(UserRequest userRequest)
        {
            UserModel userModel = new UserModel
            {
                CreatedAt = DateTime.Now,
                Role = Enums.UserRoles.User,
                UpdatedAt = DateTime.Now,
                UserName = userRequest.UserName,
                UserPassword = userRequest.UserPassword,
            };

            await _dbContext.User.AddAsync(userModel);
            await _dbContext.SaveChangesAsync();

            string token = ServiceToken.GenerateToken(userModel);

            return new UserResponseWithToken(userModel, token);
        }

        public async Task<List<UserResponse>> GetAll()
        {
            List<UserModel> userModelList = await _dbContext.User.Include((data) => data.Trains).Include((data) => data.Vehicles).ToListAsync();
            return userModelList.Select((userModel) => new UserResponse(userModel)).ToList();
        }

        public async Task<UserResponse> GetById(int id)
        {
            UserModel userModel = await _dbContext.User.Include((data) => data.Trains).Include((data) => data.Vehicles).FirstOrDefaultAsync((data) => data.Id == id);
            if (userModel == null)
                throw new Exception($"The user with Id {id} isn't found in the database.");

            return new UserResponse(userModel);
        }

        public async Task<UserResponseWithPassword> GetByUserName(string userName)
        {
            UserModel userModel = await _dbContext.User.Include((data) => data.Trains).Include((data) => data.Vehicles).FirstOrDefaultAsync((data) => data.UserName == userName);
            if (userModel == null)
                throw new Exception($"The user with UserName {userName} isn't found in the database.");

            return new UserResponseWithPassword(userModel);
        }

        public async Task<UserResponseBase> Update(UserRequest userRequest, int id)
        {
            UserModel userModel = await _dbContext.User.FirstOrDefaultAsync((data) => data.Id == id);
            if (userModel == null)
                throw new Exception($"The user with Id {id} isn't found in the database.");

            userModel.UpdatedAt = DateTime.UtcNow;
            userModel.UserName = userRequest.UserName;
            userModel.UserPassword = userRequest.UserPassword;

            _dbContext.User.Update(userModel);
            await _dbContext.SaveChangesAsync();

            return new UserResponseBase(userModel);
        }

        public async Task<bool> Delete(int id)
        {
            UserModel userModel = await _dbContext.User.FirstOrDefaultAsync((data) => data.Id == id);
            if (userModel == null)
                throw new Exception($"The user with Id {id} isn't found in the database.");

            _dbContext.User.Remove(userModel);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
