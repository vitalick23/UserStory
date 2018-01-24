using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserStore.BLL.Entities;

namespace UserStore.Models
{
    public class StoryModel
    {
        public string Id { get; set; }
       
        public string UserId { get; set; }

        public string Theme { get; set; }

        public string Stories { get; set; }

        public DateTime TimePublicate { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public static explicit operator Story(StoryModel model)
        {
            var story = new Story{
            IdUser = model.UserId,
            Stories = model.Stories,
            Theme = model.Theme,
            TimePublicate = model.TimePublicate};
            
            return story;
        }
    }
}