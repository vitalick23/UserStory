using System.Collections.Generic;
using MyUserStory.BLL.Entities;

namespace MyUserStory.BLL.Interfaces.InterfaceFinder
{
    public interface IStoryFinder : IFinder
    {
        List<Story> GetStories();

        Story GetStories(int idStory);

        List<Story> GetStoriesByUserId(string id);
    }
}
