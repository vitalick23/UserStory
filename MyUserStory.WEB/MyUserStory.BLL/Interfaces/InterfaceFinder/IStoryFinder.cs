using System.Collections.Generic;
using System.Threading.Tasks;
using MyUserStory.BLL.Entities;

namespace MyUserStory.BLL.Interfaces.InterfaceFinder
{
    public interface IStoryFinder : IFinder
    {
        List<Story> GetStories();

        Task<Story> GetStory(string idStory);

        List<Story> GetStoriesByUserId(string id);
    }
}
