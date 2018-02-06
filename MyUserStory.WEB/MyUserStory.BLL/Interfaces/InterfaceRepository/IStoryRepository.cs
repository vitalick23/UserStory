
using MyUserStory.BLL.Entities;

namespace MyUserStory.BLL.Interfaces.InterfaceRepository
{
    public interface IStoryRepository : IRepository
    {
        void Create(Story item);

        void Remove(Story item);

        void Update(Story item);
    }
}
