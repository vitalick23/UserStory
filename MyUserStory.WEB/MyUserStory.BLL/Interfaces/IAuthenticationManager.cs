using System.Security.Claims;
using System.Threading.Tasks;
using MyUserStory.BLL.Entities;

namespace MyUserStory.BLL.Interfaces
{
    public interface IAuthenticationManager
    {
        Task<ClaimsIdentity> CreateClaimIdentity(User user, string authenticationType);
        
    }
}
