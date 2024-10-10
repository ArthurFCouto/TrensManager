using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrensManager.Models;
using TrensManager.Repositories.Interface;
using TrensManager.Services;

namespace TrensManager.Controllers
{
    }
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> Add([FromBody] UserModel userModel)
        {
            UserModel user = await _userRepository.Add(userModel);
            return Ok(user);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAll()
        {
            List<UserModel> users = await _userRepository.GetAll();
            return Ok(users);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetById(int id)
        {
            UserModel user = await _userRepository.GetById(id);
            return Ok(user);
        }

        [HttpGet("token")]
        public async Task<ActionResult<string>> GetToken([FromQuery] string userName, [FromQuery] string userPassword)
        {
            UserModel user = await _userRepository.GetByUserName(userName);
            if(user.UserPassword == userPassword)
                return Ok(ServiceToken.GenerateToken(user));
            return BadRequest();
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> Update([FromBody] UserModel userModel, int id)
        {
            userModel.Id = id;
            UserModel user = await _userRepository.Update(userModel, id);
            return Ok(user);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool response = await _userRepository.Delete(id);
            return Ok(response);
        }
    }
}
