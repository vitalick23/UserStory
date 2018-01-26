using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using UserStore.BLL.Entities;

namespace UserStore.BLL.Interfaces
{
    public interface IUserFinder : IFinder
    {
        User FindById(string id);

        User FindByEmail(string email);

        User Find(string email,string password);

    }
}
