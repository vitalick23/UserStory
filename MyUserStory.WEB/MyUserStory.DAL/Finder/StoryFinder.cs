using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MyUserStory.BLL.Entities;
using MyUserStory.BLL.Interfaces.InterfaceFinder;

namespace MyUserStory.DAL.Finder
{
    public class StoryFinder : IStoryFinder
    {
        private readonly DbSet<Story> _database;

        public StoryFinder(DbSet<Story> db)
        {
            _database = db;
        }
        public List<Story> GetStories()
        {
            return _database.AsQueryable().ToList();
        }

        public Story GetStories(int idStory)
        {
           return _database.AsQueryable().First(x => x.Id == idStory);
        }

        public List<Story> GetStoriesByUserId(string id)
        {
            return _database.AsQueryable().Where(x => x.UserId == id).ToList();
        }
    }
}
