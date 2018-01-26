using UserStore.DAL.EF;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;
using UserStore.DAL.Identity;
using UserStore.BLL.Interfaces;
using UserStore.BLL.Entities;
using Microsoft.AspNet.Identity;

namespace UserStore.DAL.Repositories
{
    public class IdentityUnitOfWork : IUnitOfWork
    {
        private ApplicationContext db;

    
        private RoleManager<ApplicationRole> roleManager;
        
        public IdentityUnitOfWork(ApplicationContext applicationContext)
        {
            db = applicationContext;
            roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
        }

        public RoleManager<ApplicationRole> RoleManager
        {
            get { return roleManager; }
        }

        public Task SaveAsync()
        {
             return db.SaveChangesAsync();
        }

        public void Dispose()
        {
            roleManager.Dispose();
            db.Dispose();
        }
    }
}
