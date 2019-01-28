using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApp.Models;
using WebApp.Repository;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository repository;
        public AuthController(IUserRepository repository)
        {
            this.repository = repository;
        }


        [HttpPost]
        public IActionResult Token([FromBody] Credential credential)
        {
            {
                var user = repository.GetUserByCredential(credential).Result;
                if (user == null)
                {
                    return new NotFoundResult();
                }

                var claimsdata = new[]
                {
                    new Claim("username", user.Username),
                    new Claim("role", user.Role),
                    new Claim("approved", user.Approved.ToString()),
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ahbasshfbsahjfbshajbfhjasbfashjbfsajhfvashjfashfbsahfbsahfksdjf"));

                var signInCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

                var token = new JwtSecurityToken(
                     issuer: "https://localhost:5000",
                     audience: "http://localhost:4200",
                     expires: DateTime.Now.AddMinutes(1440),
                     claims: claimsdata,
                     signingCredentials: signInCred
                    );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                return new OkObjectResult(new { Token = tokenString });
            }
        }
    }

}