
using MyUserStory.BLL.Entities;

namespace MyUserStory.BLL.Interfaces.InterfaceRepository
{
    public interface IStoryRepositoru : IRepositoru
    {
        void Create(Story item);

        void Remove(Story item);

        void Update(Story item);
    }
}
