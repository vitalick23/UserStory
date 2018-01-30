using Microsoft.AspNet.Identity;
using MyUserStory.BLL.Entities;
using MyUserStory.BLL.Interfaces.InterfaceRepository;

namespace MyUserStory.DAL.Repositories
{
    public class UserRepositoru : IUserRepositoru
    {
        private readonly UserManager<User> _userManager;

        public UserRepositoru(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public void Create(User user, string password)
        {
            _userManager.Create(user, password);
        }

       
    }
}
