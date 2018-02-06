using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using MyUserStory.BLL.Entities;
using MyUserStory.BLL.Interfaces.InterfaceService;
using MyUserStory.WEB.Models.Request;
using MyUserStory.WEB.Models.Response;

namespace MyUserStory.WEB.Controllers
{
    public class StoryController : ApiController
    {
        private readonly IStorySevice _storySevice;
        public StoryController(IStorySevice storySevice)
        {
            _storySevice = storySevice;
        }
        // GET api/<controller>
        public async Task<List<StoryModelResponce>> Get()
        {
            var result = new List<StoryModelResponce>();
            var story = await _storySevice.GetStories();
            foreach (var item in story)
            {
                result.Add(new StoryModelResponce
                {
                    Id = item.Id,
                    Stories = item.Stories,
                    Theme = item.Theme,
                    TimePublicate = item.TimePublicate,
                    UserId = item.UserId
                      
                });
            }
            return result;
        }

        // GET api/<controller>/5
        public async Task<StoryModelResponce> Get(int id)
        {
            var item = await _storySevice.GetStory(id);

            if (item == null) return null;
            var result = new StoryModelResponce
            {
                Id = item.Id,
                Stories = item.Stories,
                Theme = item.Theme,
                TimePublicate = item.TimePublicate,
                UserId = item.UserId
            };
            return result;
        }

        // POST api/<controller>
        public async Task<StoryModelResponce> Post([FromBody]CreateStoryModelRequest item)
        {
            item.UserId = "13da69d5-b908-46a1-9212-728632a92a23";

            var story = (Story) item;
            await _storySevice.Create(story);
            var result = new StoryModelResponce
            {
                Id = story.Id,
                Stories = story.Stories,
                Theme = story.Theme,
                TimePublicate = story.TimePublicate,
                UserId = story.UserId
            };
            return result;
        }

        // PUT api/<controller>/5
        public async Task<StoryModelResponce> Put([FromBody]UpdateStoryModelRequest value)
        {
            var story = await _storySevice.GetStory(value.Id);
            story = (Story) value;
            await  _storySevice.Update(story);
            var result = new StoryModelResponce
            {
                Id = story.Id,
                Stories = story.Stories,
                Theme = story.Theme,
                TimePublicate = story.TimePublicate,
                UserId = story.UserId
            };
            return result;
        }

        // DELETE api/<controller>/5
        public async Task<int> Delete(int id)
        {
            var item = await _storySevice.GetStory(id);
            await _storySevice.Remove(item);
            return id;
        }
    }
}