using System;
using MyUserStory.BLL.Entities;

namespace MyUserStory.WEB.Models.Request
{
    public class UpdateStoryModelRequest
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public string Theme { get; set; }

        public string Stories { get; set; }

        public static explicit operator Story(UpdateStoryModelRequest model)
        {
            var story = new Story
            {
                Id = model.Id,
                Stories = model.Stories,
                Theme = model.Theme,
                UserId = model.UserId,
                TimePublicate = DateTime.Now
            };
            return story;
        }
    }
}