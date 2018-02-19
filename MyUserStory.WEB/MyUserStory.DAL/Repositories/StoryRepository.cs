using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using MyUserStory.BLL.Entities;
using MyUserStory.BLL.Interfaces.InterfaceRepository;

namespace MyUserStory.DAL.Repositories
{
    public class StoryRepository : IStoryRepository
    {
        private readonly DbSet<Story> _stories;

        public StoryRepository(DbSet<Story> db)
        {
            _stories = db;
        }
        public  void Create(Story item)
        {
           _stories.Add(item);
        }

        public void Remove(Story item)
        {
            _stories.Remove(item);
            
        }

        public void Update(Story item)
        {
            _stories.AddOrUpdate(item);
        }
    }
}
