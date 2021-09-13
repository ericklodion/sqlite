using ErickEspinosa.SQLite.Application.Services.Interfaces;
using ErickEspinosa.SQLite.Data.Repositories.Interfaces;
using ErickEspinosa.SQLite.Data.Tables;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErickEspinosa.SQLite.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Auth(string email, string password)
        {
            var user = await _userRepository.GetByEmail(email);

            if (user is null)
                throw new Exception("Email não encontrado");

            if (!user.Password.ToUpper().Equals(password.ToUpper()))
                throw new Exception("Senha incorreta");

            return user;
        }

        public async Task CreateUser(User user)
        {
            user.Guid = Guid.NewGuid().ToString();
            await _userRepository.Create(user);
        }
    }
}
