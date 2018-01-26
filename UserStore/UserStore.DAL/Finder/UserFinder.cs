using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using UserStore.BLL.Entities;
using UserStore.BLL.Interfaces.InterfaceFinder;

namespace UserStore.DAL.Finder
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
