

using System.Collections.Generic;
using UserStore.BLL.Entities;

namespace UserStore.BLL.Interfaces.InterfaceFinder
{
    public interface IStoryFinder : IFinder
    {
        List<Story> GetStories();

        Story GetStories(int idStory);

        List<Story> GetStoriesByUserId(string id);
    }
}
