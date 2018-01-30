using System;
using System.Threading.Tasks;

namespace UserStore.BLL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
     
        Task SaveAsync();
    }
}
