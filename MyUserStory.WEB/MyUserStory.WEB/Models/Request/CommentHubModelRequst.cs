using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyUserStory.BLL.Entities;
using MyUserStory.BLL.Interfaces.InterfaceService;

namespace MyUserStory.WEB.Models.Request
{
    public class CommentHubModelRequst
    {

        public string StoryId { get; set; }
        public string Mes { get; set; }

        public string Name { get; set; }


    }
}