using ErickEspinosa.SQLite.Data.Tables;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErickEspinosa.SQLite.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> Auth(string email, string password);
        Task CreateUser(User user);
    }
}
