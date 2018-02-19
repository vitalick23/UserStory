using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyUserStory.BLL.Entities;
using MyUserStory.WEB.Models.Request;

namespace MyUserStory.WEB.Models.Response
{
    public class CommentHubModelResponce
    {
        public string UserId { get; set; }

        public string StoriesId { get; set; }

        public string Text { get; set; }

        public string UserName { get; set; }

        public static explicit operator Comment(CommentHubModelResponce model)
        {
            model.UserId = "13da69d5-b908-46a1-9212-728632a92a23";


            var comment = new Comment()
            {
                UserId = model.UserId,
                StoriesId = model.StoriesId,
                Text = model.Text,
                TimePublicate = DateTime.Now
            };
            return comment;
        }
    }
}