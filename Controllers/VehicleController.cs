using Microsoft.AspNetCore.Mvc;
using TrensManager.Models;
using TrensManager.Repositories.Interface;

namespace TrensManager.Controllers
{
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
        public async Task<ActionResult<VehicleModel>> Add([FromBody] VehicleModel vehicleModel)
        {
            VehicleModel vehicle = await _vehicleRepository.Add(vehicleModel);
            return Ok(vehicle);
        }

        [HttpGet]
        public async Task<ActionResult<List<VehicleModel>>> GetAll()
        {
            List<VehicleModel> vehicles = await _vehicleRepository.GetAll();
            return Ok(vehicles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleModel>> GetById(int id)
        {
            VehicleModel vehicle = await _vehicleRepository.GetById(id);
            return Ok(vehicle);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VehicleModel>> Update([FromBody] VehicleModel vehicleModel, int id)
        {
            vehicleModel.Id = id;
            VehicleModel vehicle = await _vehicleRepository.Update(vehicleModel, id);
            return Ok(vehicle);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool response = await _vehicleRepository.Delete(id);
            return Ok(response);
        }
    }
}
