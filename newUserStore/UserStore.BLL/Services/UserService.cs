using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using UserStore.BLL.Interfaces;
using UserStore.BLL.Entities;
using UserStore.BLL.Interfaces.InterfaceFinder;

namespace UserStore.BLL.Services
{
    public class UserService :  IUserService
    {
        IUnitOfWork Database { get; set; }
        private readonly IUserFinder userFinder;
        private readonly IUserRepositoru userRepositoru;
        private readonly IAuthenticationManager authenticationManager;
        
        public UserService(IUnitOfWork uow,
            IUserFinder userFinder,
            IUserRepositoru userRepositoru,
            IAuthenticationManager authenticationManager)
        {
            this.authenticationManager = authenticationManager;
            this.userFinder = userFinder;
            this.userRepositoru = userRepositoru;
            Database = uow;
        }

        public async Task<IdentityResult> Create(User user,string password)
        {
            if (user != null)
            {
                var userFound = userFinder.FindByEmail(user.Email);
                if (userFound == null)
                {
                    userFound = new User { Email = user.Email, UserName = user.Email };
                    try
                    {
                        userRepositoru.Create(userFound, password);
                        await Database.SaveAsync();
                    }
                    catch (Exception ex)
                    {
                        return IdentityResult.Failed(ex.Message);
                    }
                    return IdentityResult.Success;
                }
            }
            return IdentityResult.Failed("Found user");
        }

        public async Task<ClaimsIdentity> Authenticate(User userDto)
        {
            
            ClaimsIdentity claim = null;
            if (userDto == null) return await Task.FromResult(claim);
            User user = userFinder.Find(userDto.Email,userDto.PasswordHash);
            if (user != null)
              claim = await authenticationManager.CreateClaimIdentity(user,
                    DefaultAuthenticationTypes.ApplicationCookie);
               
          return claim;
        }

      
        public void Dispose()
        {
            Database.Dispose();
        }

        public Task<User> FindById(string id)
        {
            if (String.IsNullOrWhiteSpace(id)) return Task.FromResult((User)null);
            return Task.FromResult( userFinder.FindById(id));
        }

    }

    
}
