using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using UserStore.BLL.Entities;
using UserStore.BLL.Interfaces;

namespace UserStore.DAL.EF
{
    public class ApplicationContext: IdentityDbContext<ApplicationUser>, IContext
    {
        public ApplicationContext() : base("DefaultConnection") { }
        
    }
}
