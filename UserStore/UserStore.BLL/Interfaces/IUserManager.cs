
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using UserStore.BLL.Entities;

namespace UserStore.BLL.Interfaces
{
    public interface IUserManager 
    {
        Task<ApplicationUser> FindByEmailAsync(string email);

        Task<IdentityResult> CreateAsync(ApplicationUser user, string password);

        Task<ClaimsIdentity> CreateIdentityAsync(ApplicationUser user, string authenticationTypes);

        Task<ApplicationUser> FindAsync(string email, string password);

        Task<ApplicationUser> FindAsync(string id);

    }
}
