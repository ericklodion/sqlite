using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ErickEspinosa.SQLite.Data.Tables
{
    public class User
    {
        public string Guid { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
    }
}
