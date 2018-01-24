using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UserStore.BLL.Entities;

namespace UserStore.Models
{
    public class StoryModel
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Theme { get; set; }
        [Required]
        public string Stories { get; set; }
        [Required]
        public DateTime TimePublicate { get; set; }
        public virtual User User { get; set; }

        public static explicit operator Story(StoryModel model)
        {
            var story = new Story{
            UserId = model.UserId,
            Stories = model.Stories,
            Theme = model.Theme,
            TimePublicate = model.TimePublicate};
            
            return story;
        }
    }
}