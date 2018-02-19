using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using MyUserStory.BLL.Entities;
using MyUserStory.BLL.Interfaces.InterfaceService;
using MyUserStory.BLL.Interfaces.Queue;
using MyUserStory.BLL.ModelQueue;
using MyUserStory.WEB.Models.Request;
using MyUserStory.WEB.Models.Response;
using Newtonsoft.Json;

namespace MyUserStory.WEB.Controllers
{
    public class StoryController : ApiController
    {
        private readonly IQueueStoryWrite _queueWrite;
        private readonly IStorySevice _storySevice;
        public StoryController(IStorySevice storySevice, IQueueStoryWrite queueWrite)
        {
            _queueWrite = queueWrite;
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
        public async Task<StoryModelResponce> Get(string id)
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
            item.UserId = "0cde9391-602d-45a2-8c3f-16444ece0df9";
            item.Id = Guid.NewGuid().ToString(); 
            var storyQueue = (StoryQueueModel)item;
             var content = storyQueue.Serialize();
            await _queueWrite.AddMessage(content);
            var story = (Story)item;
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
            var storyQueue = (StoryQueueModel)value;
            var content = storyQueue.Serialize();
            await _queueWrite.AddMessage(content);
            var result = new StoryModelResponce
            {
                Id = story.Id,
                Stories = value.Stories,
                Theme = story.Theme,
                TimePublicate = story.TimePublicate,
                UserId = story.UserId
            };
            return result;
        }

        // DELETE api/<controller>/5
        public async Task<string> Delete(string id)
        {
            var storyQueue = new StoryQueueModel
            {
                Method = "delete",
                Id = id,
                UserId = "",
                Theme = "",
                Stories = ""
            };
            var content = storyQueue.Serialize();
            await _queueWrite.AddMessage(content);
            return id;
        }
    }
}