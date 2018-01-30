using UserStore.DAL.EF;
using System.Threading.Tasks;
using UserStore.BLL.Interfaces;


namespace UserStore.DAL.Repositories
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
