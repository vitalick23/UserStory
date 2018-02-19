using MyUserStory.BLL.Entities;
using MyUserStory.BLL.Interfaces.InterfaceService;
using Queue.Interface;
using System.Threading.Tasks;

namespace Queue
{
    
    public class Application : IApplication
    {
        private readonly IStorySevice _storyService;


        public Application(IStorySevice storyService)
        {
            _storyService = storyService;
        }

        public async void CreateStory(Story story)
        {
            await _storyService.Create(story);
        }

        public async void Delete(Story item)
        {
            await _storyService.Remove(item);
        }

        public async Task<Story> GetStoryById(string id)
        {
            return await _storyService.GetStory(id);
        }

        public async void UpdateStory(Story story)
        {
            await _storyService.Update(story);
        }
    }
}
