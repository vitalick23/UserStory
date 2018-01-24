﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using UserStore.BLL.Entities;
using UserStore.BLL.Interfaces;
using UserStore.DAL.EF;

namespace UserStore.DAL.Identity
{
    public class CommentManager : ICommentService
    {
        public ApplicationContext Database { get; set; }
        public CommentManager(ApplicationContext db)
        {
            Database = db;
        }
        public void CreateComment(Comment item)
        {
                Database.Comments.Add(item);
            
        }

        public List<Comment> GetCommentByIdStory(int IdStory)
        {
            return Database.Comments.Where(x => x.StoriesId == IdStory).ToList();
        }
    }
}