using System.Threading.Tasks;
using MyUserStory.BLL.Interfaces.InterfaceService;
using MyUserStory.DAL.EF;

namespace MyUserStory.DAL.Repositories
{
    public class IdentityUnitOfWork : IUnitOfWork
    {
        private ApplicationContext db;
       
        public IdentityUnitOfWork(ApplicationContext applicationContext)
        {
            db = applicationContext;        
        }

     
        public Task SaveAsync()
        {
             return db.SaveChangesAsync();
        }

        public void Dispose()
        {            
            db.Dispose();
        }
    }
}
