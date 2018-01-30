using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyUserStory.BLL.Entities;
using MyUserStory.BLL.Interfaces;

namespace MyUserStory.DAL.EF
{
    public class ApplicationContext: IdentityDbContext<User>, IContext
    {
        public ApplicationContext() : base("DefaultConnection")
        {
        }

        public DbSet<Story> Stories { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
