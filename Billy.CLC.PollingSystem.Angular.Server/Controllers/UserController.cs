using Billy.CLC.PollingSystem.Angular.Server.Data;
using Billy.CLC.PollingSystem.Angular.Server.Helpers;
using Billy.CLC.PollingSystem.Angular.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Billy.CLC.PollingSystem.Angular.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IConfiguration _configuration;
        public UserController(AppDbContext appDbContext, IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _configuration = configuration;
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult> GetUser([FromBody] UserLogin _user)
        {
            var user = await _appDbContext.Users.SingleOrDefaultAsync(u => u.Username == _user.Username);           

            if (user == null || !PasswordHashing.VerifyPasswordHash(_user.Password!, user.PasswordHash!, user.PasswordSalt!))
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }
            var userId = user.Id;
            var token = GetUserToken(user);
            return Ok(new { token ,userId});
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser([FromBody] UserRegister userRegister)
        {
            //User exists....
            var _user = await _appDbContext.Users.SingleOrDefaultAsync(u => u.Username == userRegister.Username);
            if (_user != null)
            {
                return BadRequest(new { Massage = "User already exists" });
            }

            PasswordHashing.CreatePasswordHash(userRegister.Password!, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new User
            {   
                Id = Guid.NewGuid(),
                Firstname = userRegister.Firstname,
                Lastname = userRegister.Lastname,
                Username = userRegister.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };
            await _appDbContext.Users.AddAsync(user);
            await _appDbContext.SaveChangesAsync();
            return Ok(new { user.Firstname, user.Lastname, user.Username });
        }

        //JWT.......
        private string GetUserToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,user.Username!),
                new Claim(ClaimTypes.Role,"Admin"),//Role added manually
                new Claim(ClaimTypes.Role,"Super user"),//Role added manually
                new Claim(ClaimTypes.Name,user.Firstname!),
                new Claim(ClaimTypes.Surname,user.Lastname!),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(5),
                signingCredentials: creds
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
