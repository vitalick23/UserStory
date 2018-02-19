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

        public async Task CreateStory(Story story)
        {
             await _storyService.Create(story);
        }

        public async Task Delete(Story item)
        {
            var story = await _storyService.GetStory(item.Id);
            await _storyService.Remove(story);
        }

        public async Task UpdateStory(string id, Story item)
        {
            var story = await _storyService.GetStory(id);
            story.Stories = item.Stories;
            await _storyService.Update(story);
        }
    }
}
