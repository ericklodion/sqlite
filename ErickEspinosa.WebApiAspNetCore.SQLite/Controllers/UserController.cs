using ErickEspinosa.SQLite.Application.Services.Interfaces;
using ErickEspinosa.SQLite.Data.Tables;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]User requestBody)
        {
            await _userService.CreateUser(requestBody);
            return Ok();
        }
    }
}
