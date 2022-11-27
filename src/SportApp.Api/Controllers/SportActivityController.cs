using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SportApp.Core.Dtos;
using SportApp.Core.Entities;
using SportApp.Core.Interfaces;

namespace SportApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportActivityController : BaseApiController
    {
        private readonly ISportActivityService _activityService;

        public SportActivityController(ISportActivityService activityService, IMapper mapper) : base(mapper)
        {
            _activityService = activityService;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{userId}/{activityId}")]
        public IActionResult Get(string userId, long activityId)
        {
            var activities = _activityService.GetAsync(userId, activityId);
            if (activities == null)
            {
                return NotFound();
            }
            var activitiesDto = activities.Select(x => _mapper.Map<SportActivityDto>(x));
            return Ok(activitiesDto);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetAll(string userId)
        {
            var activities = _activityService.GetAllAsync(userId);
            var activitiesDto = activities.Select(x => _mapper.Map<SportActivityDto>(x));
            return Ok(activitiesDto);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="activityDto"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SportActivityDto activityDto, CancellationToken token)
        {
            var activityEntity = _mapper.Map<SportActivity>(activityDto);
            await _activityService.CreateAsync(activityEntity, token);
            return Ok();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="activityDto"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update([FromBody] SportActivityDto activityDto, CancellationToken token)
        {
            var activityEntity = _mapper.Map<SportActivity>(activityDto);
            _activityService.UpdateAsync(activityEntity, token);
            return Ok();
        }
    }
}