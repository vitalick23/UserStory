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
        public Task<IdentityResult> Create(Story item)
        {
            try
            {
                Database.Story.Add(item);
                return Task.FromResult(IdentityResult.Success);
            }
            catch (Exception ex)
            {
                return Task.FromResult(IdentityResult.Failed(ex.Message));
            }
        }

        public List<Story> GetStories()
        {
            return Database.Story.ToList();
        }

        public Story GetStories(int idStory)
        {
            var story = Database.Story.First(x => x.Id == idStory);
            if (story == null) return null;
            return story;
        }

        public List<Story> GetStoriesByUserName(string userName)
        {
            return Database.Story.Where(x => x.IdUser == 
                                             Database.Users.First(q => q.UserName == userName).Id)
                .ToList();
        }
    }
}
