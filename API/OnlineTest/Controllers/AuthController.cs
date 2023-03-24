using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineTest.Services.DTO;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.UpdateDTO;
using OnlineTest.Services.Interface;
using OnlineTest.Services.Interfaces;

namespace OnlineTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region Fields
        private readonly IUserService _userService;
        private readonly IRTokenService _rTokenService;
        private readonly IUserRoleService _userRoleService;
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor
        public AuthController(IUserService userService, IRTokenService rTokenService, IUserRoleService userRoleService, IConfiguration configuration)
        {
            _userService = userService;
            _rTokenService = rTokenService;
            _userRoleService = userRoleService;
            _configuration = configuration.GetSection("JWTConfig");
        }
        #endregion

        #region Methods
        [HttpPost("login")]
        public IActionResult Login(LoginDTO user)
        {
            // check if user exists
            var result = _userService.IsUserExists(user);
            if (result == null)
            {
                return Unauthorized(new ResponseDTO
                {
                    Status = 401,
                    Message = "Unauthorized",
                    Error = "Incorrect email or password"
                });
            }

            // create and add refresh token in database
            var refreshToken = Guid.NewGuid().ToString().Replace("-", "");
            var rToken = new AddRTokenDTO
            {
                RefreshToken = refreshToken,
                IsStop = false,
                CreatedOn = DateTime.UtcNow,
                UserId = result.Id
            };
            if (!_rTokenService.AddRefreshToken(rToken))
            {
                return Unauthorized(new ResponseDTO
                {
                    Status = 401,
                    Message = "Unauthorized",
                    Error = "Failed to add refresh token"
                });
            }

            // create access token and send response
            var response = GetJwt(result.Id, refreshToken);
            return Ok(response);
        }

        [HttpPost("refresh")]
        public IActionResult RefreshToken(RefreshDTO user)
        {
            // check if refresh token exists or expired
            var rTokenOld = _rTokenService.GetRefreshToken(user);
            if (rTokenOld == null)
            {
                return Unauthorized(new ResponseDTO
                {
                    Status = 401,
                    Message = "Unauthorized",
                    Error = "Refresh token not found"
                });
            }
            if (rTokenOld.IsStop == true)
            {
                return Unauthorized(new ResponseDTO
                {
                    Status = 401,
                    Message = "Unauthorized",
                    Error = "Refresh token has expired"
                });
            }

            // expire old refresh token and create new refresh token
            var updateFlag = _rTokenService.ExpireRefreshToken(new UpdateRTokenDTO
            {
                Id = rTokenOld.Id,
                IsStop = true
            });
            var refreshToken = Guid.NewGuid().ToString().Replace("-", "");
            var rTokenNew = new AddRTokenDTO
            {
                RefreshToken = refreshToken,
                IsStop = false,
                CreatedOn = DateTime.UtcNow,
                UserId = rTokenOld.UserId
            };
            var addFlag = _rTokenService.AddRefreshToken(rTokenNew);
            if (!updateFlag || !addFlag)
            {
                return Unauthorized(new ResponseDTO
                {
                    Status = 401,
                    Message = "Unauthorized",
                    Error = "Could not refresh token"
                });
            }

            // create access token and send response
            var response = GetJwt(rTokenNew.UserId, refreshToken);
            return Ok(response);
        }

        private object GetJwt(int userId, string refreshToken)
        {
            var now = DateTime.UtcNow;

            // jwt claims
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Iat, now.ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Integer64),
                new Claim("Id", Convert.ToString(userId))
            };
            var roles = _userRoleService.GetRoles(userId);
            foreach (var role in roles)
            {
                claims.Add(new Claim("Role", role));
            }

            // signing key
            var symmetricKeyAsBase64 = _configuration["SecretKey"];
            var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            var signingKey = new SymmetricSecurityKey(keyByteArray);

            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            // token options
            var tokenOptions = new JwtSecurityToken(
                issuer: _configuration["Issuer"],
                audience: _configuration["Audience"],
                claims: claims,
                expires: now.Add(TimeSpan.FromHours(24)),
                signingCredentials: signingCredentials
            );

            // active token
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            // create and return response
            var response = new
            {
                id = userId,
                access_token = tokenString,
                refresh_token = refreshToken,
                expires_in = (int)TimeSpan.FromHours(24).TotalSeconds
            };
            return response;
        }
        #endregion
    }
}