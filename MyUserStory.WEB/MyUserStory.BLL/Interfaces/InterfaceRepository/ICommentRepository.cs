using MyUserStory.BLL.Entities;

namespace MyUserStory.BLL.Interfaces.InterfaceRepository
{
    public interface ICommentRepository : IRepository
    {
        void CreateComment(Comment item);
    }
}
