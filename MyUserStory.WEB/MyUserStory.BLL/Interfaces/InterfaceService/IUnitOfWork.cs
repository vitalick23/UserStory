using System;
using System.Threading.Tasks;

namespace MyUserStory.BLL.Interfaces.InterfaceService
{
    public interface IUnitOfWork : IDisposable
    {
     
        Task SaveAsync();
    }
}
