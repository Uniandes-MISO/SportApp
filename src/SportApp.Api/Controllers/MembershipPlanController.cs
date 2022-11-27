using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SportApp.Core.Dtos;
using SportApp.Core.Entities;
using SportApp.Core.Interfaces;

namespace SportApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipPlanController : BaseApiController
    {
        private readonly IMembershipPlanService _membershipService;

        public MembershipPlanController(IMembershipPlanService membership, IMapper mapper) : base(mapper)
        {
            _membershipService = membership;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> Get(string userId)
        {
            var plan = await _membershipService.GetAsync(userId);
            if (plan == null)
            {
                return NotFound();
            }
            var plaDto = _mapper.Map<MembershipPlanDto>(plan);

            return Ok(plaDto);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userModel"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MembershipPlanDto planDto, CancellationToken token)
        {
            var userPlan = _mapper.Map<MembershipPlan>(planDto);
            await _membershipService.InsertOrUpdateAsync(userPlan, token);
            return Ok();
        }
    }
}