using AutoMapper;
using EmploMetrica.Domain.Users;
using EmploMetrica.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploMetrica.Application.UseCases.Users
{
    public class UserService(AppDbContext _db,
        IMapper _mapper) : IUserService
    {
        public List<User> GetAllUser()
        {
            using (_db)
            {
                return _db.UserDbSet.ToList();
            }
        }
        public User? GetUserByEmail(string email)
        {
            using (_db)
            {
                return _db.UserDbSet.Where(x => x.Email == email).FirstOrDefault();
            }
        }

        public User? GetUserById(int id)
        {
            using (_db)
            {
                return _db.UserDbSet.Find(id);
            }
        }
        public User RegisterUser(RegisterDto registerDto)
        {
            var user = _mapper.Map<User>(registerDto);
            using(_db)
            {
                var createdUser = _db.UserDbSet.Add(user);
                _db.SaveChanges();
                return createdUser.Entity;
            }
        }
    }
}
