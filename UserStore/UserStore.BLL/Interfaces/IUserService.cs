using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using UserStore.BLL.Entities;

namespace UserStore.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task Create(User userDto, string password);
        Task<ClaimsIdentity> Authenticate(User userDto);

        Task<User> FindById(string id);
    } 
}
