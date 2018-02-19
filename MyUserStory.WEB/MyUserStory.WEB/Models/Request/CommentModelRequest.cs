using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyUserStory.BLL.Entities;
using MyUserStory.WEB.Models.Response;

namespace MyUserStory.WEB.Models.Request
{
    public class CommentModelRequest
    {

        public string UserId { get; set; }

        public string StoriesId { get; set; }

        public string Text { get; set; }

        public static explicit operator Comment(CommentModelRequest model)
        {
            model.UserId = "0cde9391-602d-45a2-8c3f-16444ece0df9";


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