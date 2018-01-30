using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using MyUserStory.BLL.Entities;
using IAuthenticationManager = MyUserStory.BLL.Interfaces.IAuthenticationManager;

namespace MyUserStory.DAL
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly UserManager<User> _userManager;
        public AuthenticationManager(UserManager<User> userManager)
        {
            this._userManager = userManager;
        }
        public Task<ClaimsIdentity> CreateClaimIdentity(User user, string authenticationType)
        {
            return _userManager.CreateIdentityAsync(user,authenticationType);
        }
    }
}
