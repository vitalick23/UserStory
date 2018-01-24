using System;
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
    public class StoryManager : IStoryManager
    {
        public ApplicationContext Database { get; set; }
        public StoryManager(ApplicationContext db)
        {
            Database = db;
        }
        public void Create(Story item)
        {
            Database.Stories.Add(item);
            //Database.SaveChanges();
        }

        public List<Story> GetStories()
        {
            return Database.Stories.ToList();
        }

        public Story GetStories(int idStory)
        {
            var story = Database.Stories.First(x => x.Id == idStory);
            if (story == null) return null;
            return story;
        }

        public List<Story> GetStoriesByUserName(string userName)
        {
            return Database.Stories.Where(x => x.UserId == 
                                             Database.Users.First(q => q.UserName == userName).Id)
                .ToList();
        }
    }
}
