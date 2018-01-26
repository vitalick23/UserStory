
using UserStore.BLL.Entities;

namespace UserStore.BLL.Interfaces.InterfaceRepositoru
{
    public interface ICommentRepositoru : IRepositoru
    {
        void CreateComment(Comment item);
    }
}
