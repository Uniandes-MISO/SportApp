using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SportApp.Core.Dtos;
using SportApp.Core.Entities;
using SportApp.Core.Interfaces;
using System.Globalization;

namespace SportApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VirtualSessionController : BaseApiController
    {
        private readonly IVirtualSessionService _virtualSessionService;

        public VirtualSessionController(IVirtualSessionService virtualSessionService, IMapper mapper) : base(mapper)
        {
            _virtualSessionService = virtualSessionService;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="activityDto"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VirtualSessionDto virtualSessionDto, CancellationToken token)
        {
            var result = await _virtualSessionService.InsertOrUpdateAsync(virtualSessionDto, token);
            return Ok(result.Id);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{sport}/{date}")]
        public IActionResult GetAll(string sport, string date)
        {
            DateOnly dt = DateOnly.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            var result = _virtualSessionService.GetCoachAsync(sport, dt).ToList();
            return Ok(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("test/{date}")]
        public IActionResult GetAllTest(string date)
        {
            DateOnly dt = DateOnly.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None);
            return Ok(new { V = dt.ToLongDateString(), V1 = DateTime.Now.ToLongDateString(), V2 = DateTime.Now.ToLongTimeString() });
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetByUser(string userId)
        {
            var result = _virtualSessionService.GetAllAsync(userId).ToList();
            return Ok(result);
        }
    }
}