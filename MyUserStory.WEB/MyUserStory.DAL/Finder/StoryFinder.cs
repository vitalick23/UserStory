using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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

        public Task<Story> GetStory(string idStory)
        {
           return _database.AsQueryable().FirstOrDefaultAsync(x => x.Id == idStory);
        }

        public List<Story> GetStoriesByUserId(string id)
        {
            return _database.AsQueryable().Where(x => x.UserId == id).ToList();
        }
    }
}
