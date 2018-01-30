using System.Security.Claims;
using System.Threading.Tasks;
using UserStore.BLL.Entities;

namespace UserStore.BLL.Interfaces
{
    public interface IAuthenticationManager
    {
        Task<ClaimsIdentity> CreateClaimIdentity(User user, string authenticationType);
        
    }
}
