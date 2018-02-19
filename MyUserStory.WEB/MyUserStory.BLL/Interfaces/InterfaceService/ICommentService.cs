using System.Collections.Generic;
using System.Threading.Tasks;
using MyUserStory.BLL.Entities;

namespace MyUserStory.BLL.Interfaces.InterfaceService
{
    public interface ICommentService
    {
        Task CreateComment(Comment item);

        Task<List<Comment>> GetCommentByIdStory(string StoryId);
    }
}
