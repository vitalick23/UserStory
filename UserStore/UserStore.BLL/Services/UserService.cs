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

        public async Task Create(ApplicationUser user)
        {
            if (user != null)
            {
                var userFound = await userManager.FindByEmailAsync(user.Email);
                if (userFound == null)
                {
                    userFound = new ApplicationUser{Email = user.Email,UserName = user.UserName};
                    var result = await userManager.CreateAsync(userFound, user.PasswordHash);
                    if (result.Succeeded) await Database.SaveAsync();
                }
            }
        }

        public async Task<ClaimsIdentity> Authenticate(ApplicationUser userDto)
        {
            
            ClaimsIdentity claim = null;
            if (userDto == null) return await Task.FromResult(claim);
            ApplicationUser user = await userManager.FindAsync(userDto.Email, userDto.PasswordHash);
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
    }

    
}
