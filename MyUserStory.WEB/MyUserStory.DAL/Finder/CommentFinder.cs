using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MyUserStory.BLL.Entities;
using MyUserStory.BLL.Interfaces.InterfaceFinder;

namespace MyUserStory.DAL.Finder
{
    public class CommentFinder : ICommentFinder
    {
        private readonly DbSet<Comment> _database;

        public CommentFinder(DbSet<Comment> db)
        {
            _database = db;
        }
        public List<Comment> GetCommentByIdStory(int storyId)
        {
            return _database.AsQueryable().Where(x => x.StoriesId == storyId).ToList();
        }
    }
}
