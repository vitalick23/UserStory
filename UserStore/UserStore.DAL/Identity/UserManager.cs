using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using UserStore.BLL.Entities;
using UserStore.BLL.Interfaces;

namespace UserStore.DAL.Identity
{
    public class UserManager :  IUserManager
    {
        private UserManager<User> userManager;

        public UserManager(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
       
        public Task<IdentityResult> CreateAsync(User user, string password)
        {
            return  userManager.CreateAsync(user, password);
        }

        public  Task<ClaimsIdentity> CreateIdentityAsync(User user, string authenticationTypes)
        {
            return  userManager.CreateIdentityAsync(user, authenticationTypes);
        }

        public  Task<User> FindAsync(string email, string password)
        {
            return  userManager.FindAsync(email,password);
        }

        public Task<User> FindAsync(string id)
        {
            return userManager.FindByIdAsync(id);
        }

        public  Task<User> FindByEmailAsync(string email)
        {
            return  userManager.FindByEmailAsync(email);
        }
    }
}
