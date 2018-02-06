using MyUserStory.BLL.Entities;

namespace MyUserStory.BLL.Interfaces.InterfaceRepository
{
    public interface IUserRepository : IRepository
    {
        void Create(User user, string password);

    }
}
