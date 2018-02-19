using MyUserStory.BLL.Entities;
using System.Threading.Tasks;

namespace Queue.Interface
{
    public interface IApplication
    {
        void CreateStory(Story story);

        Task<Story> GetStoryById(string id);

        void UpdateStory(Story story);

        void Delete(Story id);
    }
}
