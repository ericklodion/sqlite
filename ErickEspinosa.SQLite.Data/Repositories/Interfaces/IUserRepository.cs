using ErickEspinosa.SQLite.Data.Tables;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErickEspinosa.SQLite.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByEmail(string email);
        Task Create(User user);
    }
}
