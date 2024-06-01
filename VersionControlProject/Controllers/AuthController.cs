namespace VersionControlProject.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Core.Models.Auth;
    using Responses;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    [Route("api/auth")]
    [ApiController]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        public AuthController(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                List<string> errors = ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage).ToList();
                return BadRequest(new AuthResponseModel(false, string.Join(" ", errors)));
            }
            if (await _userManager.FindByEmailAsync(model.Email) != null)
            {
                return BadRequest(new AuthResponseModel(false, "User with this email already exist's"));
            }
            if (await _userManager.FindByNameAsync(model.UserName) != null)
            {
                return BadRequest(new AuthResponseModel(false, "User with this username already exist's"));
            }
            User user = new User()
            {
                Email = model.Email,
                UserName = model.UserName,
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new AuthResponseModel(false, string.Join(" ", errors)));
            }
            var token = await GenerateJwtTokenAsync(user);
            HttpContext.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "https://localhost:44440");
            HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "Set-Cookie");

            HttpContext.Response.Cookies.Append("token", token, new CookieOptions()
            {
                HttpOnly = true,
                IsEssential = true,
                SameSite = SameSiteMode.None,
                Secure = true,
                Expires = DateTimeOffset.UtcNow.AddMinutes(15),
            });
            return Ok(new LoginResponseModel(true) { Token = token});
        }
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            User user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return NotFound(new LoginResponseModel(false, null, "User not found"));
            }
            if (!await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return BadRequest(new LoginResponseModel(false, null, "Wrong Password!"));
            }

            var token = await GenerateJwtTokenAsync(user);

            return Ok(new LoginResponseModel(true, token));
        }
        private async Task<string> GenerateJwtTokenAsync(User user)
        {
            JwtSecurityTokenHandler jwtTokenHandler = new JwtSecurityTokenHandler();

            var secret = _configuration["JwtConfig:Secret"];

            byte[] key = Encoding.ASCII.GetBytes(secret);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(await GetAllClaims(user)),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = jwtTokenHandler.CreateToken(tokenDescriptor);
            string jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
        private async Task<List<Claim>> GetAllClaims(User user)
        {
            var claims = new List<Claim>()
            {
                  new Claim("Id", user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var userRoles = await _userManager.GetRolesAsync(user);
            var userClaims = await _userManager.GetClaimsAsync(user);

            claims.AddRange(userClaims);

            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            return claims;
        }
    }
}
