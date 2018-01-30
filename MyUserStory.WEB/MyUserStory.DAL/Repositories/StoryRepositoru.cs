using System.Data.Entity;
using MyUserStory.BLL.Entities;
using MyUserStory.BLL.Interfaces.InterfaceRepository;

namespace MyUserStory.DAL.Repositories
{
    public class StoryRepositoru : IStoryRepositoru
    {
        private readonly DbSet<Story> _database;

        public StoryRepositoru(DbSet<Story> db)
        {
            _database = db;
        }
        public void Create(Story item)
        {
            _database.Add(item);
        }
    }
}
