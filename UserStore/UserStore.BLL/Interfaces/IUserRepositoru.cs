using System.Data.Entity;
using UserStore.BLL.Entities;

namespace UserStore.BLL.Interfaces
{
    public interface IUserRepositoru : IRepositoru<DbSet>
    {
        void Create(User user, string password);
    }
}
