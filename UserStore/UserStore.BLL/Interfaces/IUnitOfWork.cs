using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using UserStore.BLL.Entities;

namespace UserStore.BLL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        RoleManager<ApplicationRole> RoleManager { get; }

        Task SaveAsync();
    }
}
