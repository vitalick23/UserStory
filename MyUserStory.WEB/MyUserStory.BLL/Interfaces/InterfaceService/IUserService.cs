using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using MyUserStory.BLL.Entities;

namespace MyUserStory.BLL.Interfaces.InterfaceService
{
    public interface IUserService : IDisposable
    {
        Task<IdentityResult> Create(User userDto, string password);
        Task<ClaimsIdentity> Authenticate(User userDto);

        Task<User> FindById(string id);
    } 
}
