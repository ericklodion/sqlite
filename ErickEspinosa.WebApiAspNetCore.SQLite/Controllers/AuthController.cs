using ErickEspinosa.SQLite.Application.Services.Interfaces;
using ErickEspinosa.WebApiAspNetCore.SQLite.RequestBody;
using ErickEspinosa.WebApiAspNetCore.SQLite.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErickEspinosa.WebApiAspNetCore.SQLite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JWTHelper _jwtHelper;
        private readonly IUserService _userService;
        public AuthController(JWTHelper jwtHelper, IUserService userService)
        {
            _jwtHelper = jwtHelper;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get() => Ok(new { message = "API em funcionamento." });

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AuthRequest requestBody)
        {
            var user = await _userService.Auth(requestBody.Email, requestBody.Password);

            return Ok(new
            {
                Token = _jwtHelper.GenerateToken(user),
                User = new { 
                    email= user.Email,
                    role = user.Role,
                    id = user.Guid
                }
            });
        }
    }
}
