using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using UserStore.BLL.Entities;
using UserStore.BLL.Interfaces;
using UserStore.DAL.EF;

namespace UserStore.DAL.Identity
{
    public class UserManager :  IUserManager
    {
        private UserManager<ApplicationUser> userManager;

        public UserManager(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
       
        public Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
        {
            return  userManager.CreateAsync(user, password);
        }

        public  Task<ClaimsIdentity> CreateIdentityAsync(ApplicationUser user, string authenticationTypes)
        {
            return  userManager.CreateIdentityAsync(user, authenticationTypes);
        }

        public  Task<ApplicationUser> FindAsync(string email, string password)
        {
            return  userManager.FindAsync(email,password);
        }

        public  Task<ApplicationUser> FindByEmailAsync(string email)
        {
            return  userManager.FindByEmailAsync(email);
        }
    }
}
