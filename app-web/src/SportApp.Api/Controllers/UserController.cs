using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SportApp.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SportApp.Api.Controllers
{
    [ApiController]
    [Route("/api/users")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userService.GetAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAllAsync();
            if (!users.Any())
            {
                return NotFound();
            }
            return Ok(users);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userModel"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Models.UserModel userModel, CancellationToken token)
        {
            var userEntity = new Core.Entities.User()
            {
                Email = userModel.Email,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName
            };

            await _userService.CreateAsync(userEntity, token);

            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userModel"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPut]        
        public IActionResult Update([FromBody] Models.UserModel userModel, CancellationToken token)
        {
            var userEntity = new Core.Entities.User()
            {
                Id = userModel.Id,
                Email = userModel.Email,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName
            };

            _userService.UpdateAsync(userEntity, token);

            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id, CancellationToken token)
        {
            _userService.DeleteAsync(id, token);
            return Ok();
        }
    }
}
