using EmploMetrica.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploMetrica.Application.UseCases.Users
{
    public interface IUserService
    {
        public User? GetUserById(int id);
        public User? GetUserByEmail(string email);
        public User RegisterUser(RegisterDto registerDto);
    }
}
