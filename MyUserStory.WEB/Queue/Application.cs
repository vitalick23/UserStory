using MyUserStory.BLL.Entities;
using MyUserStory.BLL.Interfaces.InterfaceService;
using Queue.Interface;

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
    }
}
