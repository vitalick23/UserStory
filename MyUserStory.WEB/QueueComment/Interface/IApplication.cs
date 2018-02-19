using System.Threading.Tasks;
using MyUserStory.BLL.Entities;

namespace QueueComment.Interface
{
    public interface IApplication
    {
        Task CreateComment(Comment story);

    }
}
