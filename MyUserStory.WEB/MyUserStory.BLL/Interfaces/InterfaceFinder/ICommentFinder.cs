using System.Collections.Generic;
using MyUserStory.BLL.Entities;

namespace MyUserStory.BLL.Interfaces.InterfaceFinder
{
    public interface ICommentFinder : IFinder
    {
        List<Comment> GetCommentByIdStory(int storyId);
    }
}
