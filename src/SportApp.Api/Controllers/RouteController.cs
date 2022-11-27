using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SportApp.Core.Dtos;
using SportApp.Core.Interfaces;

namespace SportApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : BaseApiController
    {
        private readonly IRouteService _routeService;

        public RouteController(IMapper mapper, IRouteService routeService) : base(mapper)
        {
            this._routeService = routeService;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{site}")]
        public IActionResult Get(string site)
        {
            var routes = _routeService.GetAsync("", site);
            var routesDto = routes.Select(x => _mapper.Map<RouteDto>(x));
            return Ok(routesDto);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var routes = _routeService.GetAllAsync("");
            var routesDto = routes.Select(x => _mapper.Map<RouteDto>(x));
            return Ok(routesDto);
        }
    }
}