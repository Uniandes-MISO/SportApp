using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SportApp.Core.Dtos;
using SportApp.Core.Interfaces;

namespace SportApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EatingRoutineUserController : BaseApiController
    {
        private readonly IEatingRoutineService _eatingRoutine;
        private readonly ISportActivityService _activityService;

        public EatingRoutineUserController(IMapper mapper, IEatingRoutineService eatingRoutine, ISportActivityService activityService) : base(mapper)
        {
            _eatingRoutine = eatingRoutine;
            _activityService = activityService;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetBy(string userId)
        {
            var exist = _activityService.ExistActivitiesDay(userId, DateTime.Now);

            List<EatingRoutineUserDto> result = new();

            if (exist > 0)
            {
                result = _eatingRoutine.GetByUser(userId, exist).ToList();
            }

            return Ok(result);
        }
    }
}