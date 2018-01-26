
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using UserStore.BLL.Entities;
using UserStore.BLL.Interfaces.InterfaceFinder;

namespace UserStore.DAL.Finder
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
            return _database.Where(x => x.StoriesId == storyId).ToList();
        }
    }
}
