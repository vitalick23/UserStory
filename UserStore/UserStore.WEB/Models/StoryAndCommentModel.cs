using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserStore.BLL.Entities;

namespace UserStore.Models
{
    public class StoryAndCommentModel
    {
        public Story Story { get; set; }

        public List<Comment> CommentList { get; set; }

    }
}