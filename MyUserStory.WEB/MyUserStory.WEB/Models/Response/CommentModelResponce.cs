using MyUserStory.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyUserStory.WEB.Models.Response
{
    public class CommentModelResponce
    {
        public string Id { get; set; }
    
        public string UserId { get; set; }

        public string StoriesId { get; set; }

        public string Text { get; set; }

        public DateTime TimePublicate { get; set; }

        public static explicit operator CommentModelResponce(Comment model)
        {
            var comment = new CommentModelResponce
            {
                Id = model.Id,
                UserId = model.UserId,
                StoriesId = model.StoriesId,
                Text = model.Text,
                TimePublicate = model.TimePublicate
            };
            return comment;
        }
    }
}