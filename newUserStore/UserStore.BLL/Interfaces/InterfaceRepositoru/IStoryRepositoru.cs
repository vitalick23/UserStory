
using UserStore.BLL.Entities;

namespace UserStore.BLL.Interfaces.InterfaceRepositoru
{
    public interface IStoryRepositoru : IRepositoru
    {
        void Create(Story item);
    }
}
