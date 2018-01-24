
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using UserStore.BLL.Entities;

namespace UserStore.BLL.Interfaces
{
    public interface IUserManager 
    {
        Task<User> FindByEmailAsync(string email);

        Task<IdentityResult> CreateAsync(User user, string password);

        Task<ClaimsIdentity> CreateIdentityAsync(User user, string authenticationTypes);

        Task<User> FindAsync(string email, string password);

        Task<User> FindAsync(string id);

    }
}
