using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrensManager.DTO.TrainDTO;
using TrensManager.Repositories.Interface;

namespace TrensManager.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        private readonly ITrainRepository _trainRepository;
        public TrainController(ITrainRepository trainRepository)
        {
            _trainRepository = trainRepository;
        }

        [HttpPost]
        public async Task<ActionResult<TrainResponse>> Add([FromBody] TrainRequest trainRequest)
        {
            string userID = HttpContext.User.Claims.FirstOrDefault((data) => data.Type == "Id")?.Value;
            TrainResponse trainResponse = await _trainRepository.Add(trainRequest, int.Parse(userID));
            return Ok(trainResponse);
        }

        [HttpGet]
        public async Task<ActionResult<List<TrainResponse>>> GetAll()
        {
            List<TrainResponse> trainResponseList = await _trainRepository.GetAll();
            return Ok(trainResponseList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrainResponse>> GetById([FromRoute] int id)
        {
            TrainResponse trainResponse = await _trainRepository.GetById(id);
            return Ok(trainResponse);
        }

        [HttpGet("numberOS/{os}")]
        public async Task<ActionResult<TrainResponse>> GetByOS([FromRoute] int os)
        {
            TrainResponse trainResponse = await _trainRepository.GetByOS(os);
            return Ok(trainResponse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TrainResponse>> Update([FromBody] TrainRequest trainRequest, [FromRoute] int id)
        {
            string userID = HttpContext.User.Claims.FirstOrDefault((data) => data.Type == "Id")?.Value;
            TrainResponse trainResponse = await _trainRepository.Update(trainRequest, id, int.Parse(userID));
            return Ok(trainResponse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            bool response = await _trainRepository.Delete(id);
            return Ok(response);
        }
    }
}
