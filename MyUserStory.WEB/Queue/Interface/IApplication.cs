using MyUserStory.BLL.Entities;
using System.Threading.Tasks;

namespace Queue.Interface
{
    public interface IApplication
    {
        Task CreateStory(Story story);

        Task<Story> GetStoryById(string id);

        Task UpdateStory(string id, Story item);

        Task Delete(Story id);
    }
}
