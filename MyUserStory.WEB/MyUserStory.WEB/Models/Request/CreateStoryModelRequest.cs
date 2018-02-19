using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using MyUserStory.BLL.Entities;
using MyUserStory.BLL.ModelQueue;

namespace MyUserStory.WEB.Models.Request
{
    public class CreateStoryModelRequest
    {
        public string Id { get; set; }
        public string UserId { get; set; }

        public string Theme { get; set; }

        public string Stories { get; set; }

        public static explicit operator Story(CreateStoryModelRequest model)
        {
            var story = new Story
            {
                Stories = model.Stories,
                Theme =  model.Theme,
                UserId = model.UserId
            };
            return story;
        }
        public static explicit operator StoryQueueModel(CreateStoryModelRequest model)
        {
            var story = new StoryQueueModel
            {
                Method = "post",
                Id = model.Id,
                Stories = model.Stories,
                Theme = model.Theme,
                UserId = model.UserId
            };
            return story;
        }
    }
}