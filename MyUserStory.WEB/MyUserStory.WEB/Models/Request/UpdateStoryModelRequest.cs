using System;
using MyUserStory.BLL.Entities;
using MyUserStory.BLL.ModelQueue;

namespace MyUserStory.WEB.Models.Request
{
    public class UpdateStoryModelRequest
    {
        public string Id { get; set; }
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
            };
            return story;
        }

        public static explicit operator StoryQueueModel(UpdateStoryModelRequest model)
        {
            var story = new StoryQueueModel
            {
                Method = "put",
                Id = model.Id,
                Stories = model.Stories,
                Theme = model.Theme,
                UserId = model.UserId
            };
            return story;
        }
    }
}