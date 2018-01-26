using System;
using System.Data.Entity;
using UserStore.BLL.Entities;
using UserStore.BLL.Interfaces.InterfaceRepositoru;

namespace UserStore.DAL.Repositories
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
