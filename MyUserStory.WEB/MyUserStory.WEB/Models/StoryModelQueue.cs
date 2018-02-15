using MyUserStory.BLL.Entities;
using MyUserStory.WEB.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyUserStory.WEB.Models
{
    public class StoryModelQueue
    {
        public string Name { get; set; }

        public CreateStoryModelRequest CreateStoryModelRequest{get; set;}

        public static explicit operator Story(StoryModelQueue model)
        {
            var story = new Story
            {
                Stories = model.CreateStoryModelRequest.Stories,
                Theme = model.CreateStoryModelRequest.Theme,
                UserId = model.CreateStoryModelRequest.UserId
            };
            return story;
        }
    }
}