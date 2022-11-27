using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SportApp.Core.Dtos;
using SportApp.Core.Entities;
using SportApp.Core.Interfaces;

namespace SportApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTrainingController : BaseApiController
    {
        private readonly IUserTrainingService _userTrainingService;

        public UserTrainingController(IMapper mapper, IUserTrainingService userTrainingService) : base(mapper)
        {
            this._userTrainingService = userTrainingService;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="activityDto"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(/*string userId,*/ [FromBody] UserTrainingDto userTraining, CancellationToken token)
        {
            var entity = _mapper.Map<UserTraining>(userTraining);
            await _userTrainingService.CreateAsync(entity, token);
            return Ok();
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
            var userTraining = _userTrainingService.GetAsync(userId);
            var userTrainingDto = userTraining.Select(x => _mapper.Map<UserTrainingDto>(x));
            return Ok(userTrainingDto);
        }
    }
}