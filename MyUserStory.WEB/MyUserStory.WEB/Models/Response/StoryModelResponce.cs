using System;

namespace MyUserStory.WEB.Models.Response
{
    public class StoryModelResponce
    {
        public string Id { get; set; }
      
        public string UserId { get; set; }

        public string Theme { get; set; }

        public string Stories { get; set; }

        public DateTime TimePublicate { get; set; }
 
    }
}