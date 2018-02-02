using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyUserStory.BLL.Entities;
using MyUserStory.BLL.Interfaces.InterfaceService;
using MyUserStory.WEB.Models;

namespace MyUserStory.WEB.Controllers
{
    public class StoryController : ApiController
    {
        private IStorySevice _storySevice;
        public StoryController(IStorySevice storySevice)
        {
            _storySevice = storySevice;
        }
        // GET api/<controller>
        public List<StoryModel> Get()
        {
            var result = new List<StoryModel>();
            var story = _storySevice.GetStories();
            foreach (var item in story)
            {
                result.Add(new StoryModel
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
        public StoryModel Get(int id)
        {
            var item = _storySevice.GetStories(id);

            if (item != null)
            {
                var result = new StoryModel
                {
                    Id = item.Id,
                    Stories = item.Stories,
                    Theme = item.Theme,
                    TimePublicate = item.TimePublicate,
                    UserId = item.UserId
                };
                return result;
            }

            return null;
        }

        // POST api/<controller>
        public void Post([FromBody]StoryModel value)
        {
            //when take user id;
        }

        // PUT api/<controller>/5
        public void Put([FromBody]StoryModel item)
        {

        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            _storySevice.Remove(id);
        }
    }
}