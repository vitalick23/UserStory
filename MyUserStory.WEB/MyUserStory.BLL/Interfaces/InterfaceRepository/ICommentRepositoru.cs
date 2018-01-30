using MyUserStory.BLL.Entities;

namespace MyUserStory.BLL.Interfaces.InterfaceRepository
{
    public interface ICommentRepositoru : IRepositoru
    {
        void CreateComment(Comment item);
    }
}
