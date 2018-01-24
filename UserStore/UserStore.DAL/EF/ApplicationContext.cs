using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using UserStore.BLL.Entities;
using UserStore.BLL.Interfaces;

namespace UserStore.DAL.EF
{
    public class ApplicationContext: IdentityDbContext<User>, IContext
    {
        public ApplicationContext() : base("DefaultConnection") { }

        public DbSet<Story> Stories { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
