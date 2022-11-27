using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SportApp.Api.Models;
using SportApp.Core.Entities;
using SportApp.Core.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SportApp.Api.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class AuthenticationController : ControllerBase
    //{
    //    [HttpPost("login")]
    //    public IActionResult Login([FromBody] Login user)
    //    {
    //        if (user is null)
    //        {
    //            return BadRequest("Invalid user request!!!");
    //        }
    //        if (user.UserName == "SportApp" && user.Password == "Pass@*")
    //        {
    //            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSetting["JWT:Secret"]));
    //            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
    //            var tokeOptions = new JwtSecurityToken(
    //                issuer: ConfigurationManager.AppSetting["JWT:ValidIssuer"],
    //                audience: ConfigurationManager.AppSetting["JWT:ValidAudience"],
    //                claims: new List<Claim>(),
    //                expires: DateTime.Now.AddMinutes(6),
    //                signingCredentials: signinCredentials
    //            );
    //            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
    //            return Ok(new JWTTokenResponse { Token = tokenString });
    //        }
    //        return Unauthorized();
    //    }
    //}

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IMembershipPlanService _membershipService;

        public AccountController()
        {
        }

        public AccountController(
            //ILoggerManager logger,
            IMembershipPlanService membership,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            //_logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _membershipService = membership;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);
                var refreshToken = GenerateRefreshToken();

                _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);

                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

                await _userManager.UpdateAsync(user);
                var plan = await _membershipService.GetAsync(user.Id);

                return Ok(new
                {
                    id = user.Id,
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    RefreshToken = refreshToken,
                    fullName = $"{user.FirstName} {user.LastName}",
                    email = user.Email,
                    firstName = user.FirstName,
                    lastName = user.LastName,
                    rol = userRoles.FirstOrDefault(),
                    plan = plan?.Type.ToString()
                }); ;
            }
            return Unauthorized();
        }

        //[HttpPost]
        //[Route("refresh-token")]
        //public async Task<IActionResult> RefreshToken(TokenModel tokenModel)
        //{
        //    if (tokenModel is null)
        //    {
        //        return BadRequest("Invalid client request");
        //    }

        //    string? accessToken = tokenModel.AccessToken;
        //    string? refreshToken = tokenModel.RefreshToken;

        //    var principal = GetPrincipalFromExpiredToken(accessToken);
        //    if (principal == null)
        //    {
        //        return BadRequest("Invalid access token or refresh token");
        //    }

        //    string? username = principal.Identity.Name;
        //    var user = await _userManager.FindByNameAsync(username);

        //    if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
        //    {
        //        return BadRequest("Invalid access token or refresh token");
        //    }

        //    var newAccessToken = GetToken(principal.Claims.ToList());
        //    var newRefreshToken = GenerateRefreshToken();

        //    user.RefreshToken = newRefreshToken;
        //    await _userManager.UpdateAsync(user);

        //    return new ObjectResult(new
        //    {
        //        accessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
        //        refreshToken = newRefreshToken
        //    });

        //}

        //[Authorize]
        //[HttpPost]
        //[Route("logout/{username}")]
        //public async Task<IActionResult> Revoke(string username)
        //{
        //    var rs = User.Identity;

        //    var user = await _userManager.FindByNameAsync(username);
        //    if (user == null) return BadRequest("Invalid user name");

        //    user.RefreshToken = null;
        //    await _userManager.UpdateAsync(user);
        //    //_logger.LogInfo($"User {username} logged out the system.");
        //    return NoContent();
        //}

        //[Authorize]
        //[HttpPost]
        //[Route("logout-all")]
        //public async Task<IActionResult> RevokeAll()
        //{
        //    var users = _userManager.Users.ToList();
        //    foreach (var user in users)
        //    {
        //        user.RefreshToken = null;
        //        await _userManager.UpdateAsync(user);
        //    }

        //    return NoContent();
        //}

        //[HttpPost]
        //[Route("register")]
        //public async Task<IActionResult> Register([FromBody] RegisterModel model)
        //{
        //    var userExists = await _userManager.FindByNameAsync(model.Username);
        //    if (userExists != null)
        //        return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel { Status = "Error", Message = "User already exists!" });

        //    IdentityUser user = new()
        //    {
        //        Email = model.Email,
        //        SecurityStamp = Guid.NewGuid().ToString(),
        //        UserName = model.Username
        //    };
        //    var result = await _userManager.CreateAsync(user, model.Password);
        //    if (!result.Succeeded)
        //        return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel { Status = "Error", Message = "User creation failed! Please check user details and try again." });

        //    return Ok(new ResponseModel { Status = "Success", Message = "User created successfully!" });
        //}

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status200OK, new ResponseModel { Status = "Error", Message = "User already exists!" });

            User user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status200OK, new ResponseModel { Status = "Error", Message = result.Errors.FirstOrDefault()?.Description });

            if (!string.IsNullOrEmpty(model.Rol))
                await _userManager.AddToRoleAsync(user, model.Rol);

            return Ok(new ResponseModel { Status = "Success", Message = "User created successfully!" });
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            _ = int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(24), //DateTime.Now.AddMinutes(tokenValidityInMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        //private ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
        //{
        //    var tokenValidationParameters = new TokenValidationParameters
        //    {
        //        ValidateAudience = false,
        //        ValidateIssuer = false,
        //        ValidateIssuerSigningKey = true,
        //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])),
        //        ValidateLifetime = false
        //    };

        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
        //    if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        //        throw new SecurityTokenException("Invalid token");

        //    return principal;

        //}
    }
}