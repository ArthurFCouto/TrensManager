using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrensManager.DTO.UserDTO;
using TrensManager.Models;
using TrensManager.Repositories.Interface;
using TrensManager.Services;

namespace TrensManager.Controllers
{
    // Anotação que informa que a classe necessita do token para ser acesada
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Anotação que informa que esse método não necessita de token para ser acessado, apesar de estar dentro de uma classe que necessita
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<UserResponseWithToken>> Add([FromBody] UserRequest userRequest)
        {
            UserResponseWithToken userResponse = await _userRepository.Add(userRequest);
            return Ok(userResponse);
        }

        [HttpGet]
        public async Task<ActionResult<List<UserResponse>>> GetAll()
        {
            List<UserResponse> userResponseList = await _userRepository.GetAll();
            return Ok(userResponseList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetById([FromRoute] int id)
        {
            try
            {
                UserResponse userResponse = await _userRepository.GetById(id);
                return Ok(userResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("token")]
        public async Task<ActionResult<object>> GetToken([FromQuery] string userName, [FromQuery] string userPassword)
        {
            try
            {
                UserResponseWithPassword userResponse = await _userRepository.GetByUserName(userName);
                if (userResponse.UserPassword != userPassword)
                    throw new Exception("UserName or Password incorrect!");
                UserModel userModel = new UserModel
                {
                    CreatedAt = DateTime.Now,
                    Id = userResponse.Id,
                    Role = userResponse.Role,
                    UpdatedAt = userResponse.UpdatedAt,
                    UserName = userResponse.UserName,
                    UserPassword = userResponse.UserPassword
                };
                return Ok(ServiceToken.GenerateToken(userModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserResponse>> Update([FromBody] UserRequest userRequest, [FromRoute] int id)
        {
            try
            {
                UserResponse userResponse = await _userRepository.Update(userRequest, id);
                return Ok(userResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            try
            {
                bool response = await _userRepository.Delete(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
