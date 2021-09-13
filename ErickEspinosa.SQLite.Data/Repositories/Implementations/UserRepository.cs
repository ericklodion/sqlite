using Dapper;
using ErickEspinosa.SQLite.Data.Repositories.Interfaces;
using ErickEspinosa.SQLite.Data.Tables;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErickEspinosa.SQLite.Data.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly DbSession _session;
        public UserRepository(DbSession session)
        {
            _session = session;
        }

        public async Task Create(User user)
        {
            var sql = @"INSERT INTO USER (
                            GUID,
                            EMAIL,
                            ROLE,
                            PASSWORD
                        ) VALUES (
                            @GUID,
                            @EMAIL,
                            @ROLE,
                            @PASSWORD
                        )";

            await _session.Connection.ExecuteAsync(sql, user, _session.Transaction);
        }

        public async Task<User> GetByEmail(string email)
        {
            var sql = "SELECT * FROM USER WHERE EMAIL = @EMAIL";

            return await _session.Connection.QueryFirstOrDefaultAsync<User>(sql, new { email }, _session.Transaction);
        }
    }
}
