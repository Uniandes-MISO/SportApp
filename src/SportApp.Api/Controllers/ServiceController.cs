using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SportApp.Core.Dtos;
using SportApp.Core.Entities;
using SportApp.Core.Interfaces;

namespace SportApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : BaseApiController
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IMapper mapper, IServiceService serviceService) : base(mapper)
        {
            this._serviceService = serviceService;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{userId}/{serviceId}")]
        public IActionResult Get(string userId, long serviceId)
        {
            var service = _serviceService.GetAsync(userId, serviceId);
            if (service == null)
            {
                return NotFound();
            }
            var serviceDto = _mapper.Map<ServiceDto>(service);

            return Ok(serviceDto);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetAll(string userId)
        {
            var services = _serviceService.GetAllAsync(userId);
            var servicesDto = services.Select(x => _mapper.Map<ServiceDto>(x));
            return Ok(servicesDto);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceDto"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ServiceDto serviceDto, CancellationToken token)
        {
            var serviceEntity = _mapper.Map<Service>(serviceDto);
            await _serviceService.CreateAsync(serviceEntity, token);
            return Ok();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceDto"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update([FromBody] ServiceDto serviceDto, CancellationToken token)
        {
            var serviceEntity = _mapper.Map<Service>(serviceDto);
            _serviceService.UpdateAsync(serviceEntity, token);
            return Ok();
        }
    }
}