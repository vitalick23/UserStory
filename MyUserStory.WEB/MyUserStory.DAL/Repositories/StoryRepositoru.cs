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

        public void Remove(Story item)
        {
            var story = _database.Find(item.Id);
            _database.Remove(story);
            
        }

        public void Update(Story item)
        {
            var story = _database.Find(item);
            if (story != null)
            {
                story.Theme = item.Theme;
                story.Stories = item.Stories;
                story.TimePublicate = item.TimePublicate;
                
            }
        }
    }
}
