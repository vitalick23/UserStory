using System.Collections.Generic;
using System.Threading.Tasks;
using MyUserStory.BLL.Entities;

namespace MyUserStory.BLL.Interfaces.InterfaceFinder
{
    public interface ICommentFinder : IFinder
    {
        List<Comment> GetCommentByIdStory(string storyId);
    }
}
