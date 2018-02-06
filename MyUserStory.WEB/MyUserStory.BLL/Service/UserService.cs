using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using MyUserStory.BLL.Entities;
using MyUserStory.BLL.Interfaces.InterfaceFinder;
using MyUserStory.BLL.Interfaces.InterfaceRepository;
using MyUserStory.BLL.Interfaces.InterfaceService;
using MyUserStory.BLL.Interfaces;

namespace MyUserStory.BLL.Service
{
    public class UserService :  IUserService
    {
        IUnitOfWork Database { get; set; }
        private readonly IUserFinder _userFinder;
        private readonly IUserRepository _userRepository;
        private readonly Interfaces.IAuthenticationManager _authenticationManager;
        
        public UserService(IUnitOfWork uow,
            IUserFinder userFinder,
            IUserRepository userRepository,
            Interfaces.IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
            _userFinder = userFinder;
            _userRepository = userRepository;
            Database = uow;
        }

        public async Task<IdentityResult> Create(User user,string password)
        {
            if (user != null)
            {
                var userFound = _userFinder.FindByEmail(user.Email);
                if (userFound == null)
                {
                    userFound = new User { Email = user.Email, UserName = user.Email };
                    try
                    {
                        _userRepository.Create(userFound, password);
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
            User user = _userFinder.Find(userDto.Email,userDto.PasswordHash);
            if (user != null)
              claim = await _authenticationManager.CreateClaimIdentity(user,
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
            return Task.FromResult( _userFinder.FindById(id));
        }

    }

    
}
