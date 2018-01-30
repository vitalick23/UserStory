using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using UserStore.BLL.Entities;
using IAuthenticationManager = UserStore.BLL.Interfaces.IAuthenticationManager;

namespace UserStore.DAL.Identity
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly UserManager<User> userManager;
        public AuthenticationManager(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        public Task<ClaimsIdentity> CreateClaimIdentity(User user, string authenticationType)
        {
            return userManager.CreateIdentityAsync(user,authenticationType);
        }
    }
}
