using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using UserStore.BLL.Entities;
using UserStore.BLL.Interfaces;

namespace UserStore.DAL.Find
{
    public class UserFinder : IUserFinder
    {
        private readonly IDbSet<User> _users;


        public UserFinder(IDbSet<User> users)
        {
            _users = users;
        }

        public User Find(string email, string password)
        {
            var user = FindByEmail(email);
            if (user != null)
            {
                if (new UserManager<User>(new UserStore<User>()).CheckPassword(user, password)) return user;
            }

            return null;
        }

        public User FindByEmail(string email)
        {
            return _users.AsQueryable().FirstOrDefault(x => x.Email == email);
        }


        public User FindById(string id)
        {
            return _users.AsQueryable().FirstOrDefault(x => x.Id == id);
        }

    }
}
