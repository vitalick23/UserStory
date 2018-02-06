using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyUserStory.BLL.Entities;

namespace MyUserStory.WEB.Models.Request
{
    public class CreateStoryModelRequest
    {
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
    }
}