using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SportApp.Core.Dtos;
using SportApp.Core.Interfaces;

namespace SportApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : BaseApiController
    {
        private readonly ITrainingService _trainingService;

        public TrainingController(IMapper mapper, ITrainingService trainingService) : base(mapper)
        {
            this._trainingService = trainingService;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{userId}")]
        public IActionResult Get(string userId)
        {
            var training = _trainingService.GetAsync(userId);
            var trainingDto = training.Select(x => _mapper.Map<TrainingDto>(x));
            return Ok(trainingDto);
        }
    }
}