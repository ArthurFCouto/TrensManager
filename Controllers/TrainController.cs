﻿using Microsoft.AspNetCore.Mvc;
using TrensManager.Models;
using TrensManager.Repositories.Interface;

namespace TrensManager.Controllers
{
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
        public async Task<ActionResult<TrainModel>> Add([FromBody] TrainModel trainModel)
        {
            TrainModel train = await _trainRepository.Add(trainModel);
            return Ok(train);
        }

        [HttpGet]
        public async Task<ActionResult<List<TrainModel>>> GetAll()
        {
            List<TrainModel> trains = await _trainRepository.GetAll();
            return Ok(trains);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrainModel>> GetById(int id)
        {
            TrainModel train = await _trainRepository.GetById(id);
            return Ok(train);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TrainModel>> Update([FromBody] TrainModel trainModel, int id)
        {
            trainModel.Id = id;
            TrainModel train = await _trainRepository.Update(trainModel, id);
            return Ok(train);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool response = await _trainRepository.Delete(id);
            return Ok(response);
        }
    }
}
