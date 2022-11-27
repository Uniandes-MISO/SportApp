using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SportApp.Api.Models;
using SportApp.Core.Dtos;
using SportApp.Core.Interfaces;

namespace SportApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : BaseApiController
    {
        private readonly IEventService _eventService;

        public EventController(IMapper mapper, IEventService eventService) : base(mapper)
        {
            this._eventService = eventService;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{userId}/{date}/{site}")]
        public IActionResult Get(string userId, string date, string site)
        {
            var events = _eventService.GetAsync(userId, date, site);
            var eventsDto = events.Select(x => _mapper.Map<EventDto>(x));
            return Ok(eventsDto);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{userId}")]
        public IActionResult GetBy(string userId, [FromBody] EventModel even)
        {
            var events = _eventService.GetAsync(userId, even.Date, even.Site);
            var eventsDto = events.Select(x => _mapper.Map<EventDto>(x));
            return Ok(eventsDto);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{userId}/all")]
        public IActionResult GetAll(string userId)
        {
            var events = _eventService.GetAllAsync(userId);
            var eventsDto = events.Select(x => _mapper.Map<EventDto>(x));
            return Ok(eventsDto);
        }
    }
}