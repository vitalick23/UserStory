using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using UserStore.BLL.Interfaces;
using UserStore.BLL.Entities;

namespace UserStore.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }
        private IUserManager userManager;
        
        public UserService(IUnitOfWork uow, IUserManager _userManager)
        {
            userManager = _userManager;
            Database = uow;
        }

        public async Task<IdentityResult> Create(User user,string password)
        {
            if (user != null)
            {
                var userFound = await userManager.FindByEmailAsync(user.Email);
                if (userFound == null)
                {
                    userFound = new User{Email = user.Email,UserName = user.Email};
                    await userManager.CreateAsync(userFound, password);
                    await Database.SaveAsync();
                    return IdentityResult.Success;
                }
            }
            return IdentityResult.Failed("Null user");
        }

        public async Task<ClaimsIdentity> Authenticate(User userDto)
        {
            
            ClaimsIdentity claim = null;
            if (userDto == null) return await Task.FromResult(claim);
            User user = await userManager.FindAsync(userDto.Email, userDto.PasswordHash);
            if(user!=null)
                claim= await userManager.CreateIdentityAsync(user,
                                                             DefaultAuthenticationTypes.ApplicationCookie
                                                             );
            return claim;
        }

      
        public void Dispose()
        {
            Database.Dispose();
        }

        public Task<User> FindById(string id)
        {
            if (String.IsNullOrWhiteSpace(id)) return Task.FromResult((User)null);
            return userManager.FindAsync(id);
        }
    }

    
}
