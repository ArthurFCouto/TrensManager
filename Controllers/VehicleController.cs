using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrensManager.DTO.VehicleDTO;
using TrensManager.Repositories.Interface;

namespace TrensManager.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepository _vehicleRepository;
        public VehicleController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        [HttpPost]
        public async Task<ActionResult<VehicleResponse>> Add([FromBody] VehicleRequest vehicleRequest)
        {
            string userNameToken = HttpContext.User.Claims.FirstOrDefault((data) => data.Type == "UserName")?.Value;
            VehicleResponse vehicleResponse = await _vehicleRepository.Add(vehicleRequest, userNameToken);
            return Ok(vehicleResponse);
        }

        [HttpGet]
        public async Task<ActionResult<List<VehicleResponse>>> GetAll()
        {
            List<VehicleResponse> vehicleResponseList = await _vehicleRepository.GetAll();
            return Ok(vehicleResponseList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleResponse>> GetById([FromRoute] int id)
        {
            VehicleResponse vehicleResponse = await _vehicleRepository.GetById(id);
            return Ok(vehicleResponse);
        }

        [HttpGet("code/{code}")]
        public async Task<ActionResult<VehicleResponse>> GetByCode([FromRoute] string code)
        {
            VehicleResponse vehicleResponse = await _vehicleRepository.GetByCode(code);
            return Ok(vehicleResponse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VehicleResponse>> Update([FromBody] VehicleRequest vehicleRequest, [FromRoute] int id)
        {
            string userNameToken = HttpContext.User.Claims.FirstOrDefault((data) => data.Type == "UserName")?.Value;
            VehicleResponse vehicleResponse = await _vehicleRepository.Update(vehicleRequest, id, userNameToken);
            return Ok(vehicleResponse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            bool response = await _vehicleRepository.Delete(id);
            return Ok(response);
        }
    }
}
