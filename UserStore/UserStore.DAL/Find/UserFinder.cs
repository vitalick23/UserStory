using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using UserStore.BLL.Entities;
using UserStore.BLL.Interfaces;

namespace UserStore.DAL.Find
{
    public class UserFinder : IUserFinder
    {
        private readonly DbSet<User> _users;


        public UserFinder(DbSet<User> users)
        {
            _users = users;
        }

        public User FindByEmail(string email)
        {
            return _users.AsQueryable().FirstOrDefault(x => x.Email == email);
        }

        public User FindById(string id)
        {
            return _users.AsQueryable().FirstOrDefault(x => x.Id == id);
        }

        public ClaimsIdentity FindClaimsIdentityByUser(User user)
        {
            return null;
        }
    }
}
