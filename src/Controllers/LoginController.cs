using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace BlogApi.src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
                private readonly ILogger<LoginController> _logger ;



        public LoginController(ILogger<LoginController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        [HttpPost]
        public ActionResult<LoginResponceDTO> Login(LoginDTO model){
            LoginResponceDTO response = new();
            if(!ModelState.IsValid)
            return BadRequest("please provide username and password");
            if(model.username == "ram" & model.Password == "ram123")
            {
                var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JWTSecret"));
                var tokenHandller = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor(){
                    Subject = new ClaimsIdentity(new Claim[]{
                        new Claim(ClaimTypes.Role , "admin"),
                        new Claim(ClaimTypes.Name , model.username)
                    }),
                    Expires = DateTime.Now.AddHours(4),
                    SigningCredentials = new (new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha512Signature)
                };
                var token = tokenHandller.CreateToken(tokenDescriptor);
                var tokenGenerated = tokenHandller.WriteToken(token);
                response.token = tokenGenerated;
                response.username = model.username;
            }else{
            return BadRequest("please provide valid username and password");
            }
            return Ok(response);


        }


    }

}