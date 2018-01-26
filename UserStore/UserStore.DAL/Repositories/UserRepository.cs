using System.Data.Entity;
using Microsoft.AspNet.Identity;
using UserStore.BLL.Entities;
using UserStore.BLL.Interfaces;

namespace UserStore.DAL.Repositories
{
    public class UserRepository : IUserRepositoru
    {
        private readonly UserManager<User> userManager;

        public UserRepository(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public void Create(User user, string password)
        {
            userManager.Create(user, password);
        }

       
    }
}
