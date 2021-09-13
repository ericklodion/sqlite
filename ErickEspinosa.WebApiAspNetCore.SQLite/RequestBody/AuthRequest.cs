using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErickEspinosa.WebApiAspNetCore.SQLite.RequestBody
{
    public class AuthRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
