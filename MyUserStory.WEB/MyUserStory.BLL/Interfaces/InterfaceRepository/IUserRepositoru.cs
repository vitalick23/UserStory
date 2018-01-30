using MyUserStory.BLL.Entities;

namespace MyUserStory.BLL.Interfaces.InterfaceRepository
{
    public interface IUserRepositoru : IRepositoru
    {
        void Create(User user, string password);

    }
}
