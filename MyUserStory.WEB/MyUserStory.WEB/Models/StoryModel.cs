using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyUserStory.WEB.Models
{
    public class StoryModel
    {
        public int Id { get; set; }
      
        public string UserId { get; set; }

        public string Theme { get; set; }

        public string Stories { get; set; }

        public DateTime TimePublicate { get; set; }
 
    }
}