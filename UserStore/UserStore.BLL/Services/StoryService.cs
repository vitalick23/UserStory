using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using UserStore.BLL.Entities;
using UserStore.BLL.Interfaces;

namespace UserStore.BLL.Services
{
    public class StoryService : IStorySevice
    {
        private IUnitOfWork database { get; set; }
        private IStoryManager storyManager;
        private IUserManager userManager;

        public StoryService(IUnitOfWork uow, IStoryManager storiesManager, IUserManager userManager)
        {
            this.storyManager = storiesManager;
            this.userManager = userManager;
            database = uow;

        }
        public async Task<IdentityResult> Create(Story item)
        {
            if (item != null)
            {
                item.ApplicationUser = await userManager.FindAsync(item.IdUser);
                var result  = await storyManager.Create(item);
                if (result.Succeeded) await database.SaveAsync();
                return result;
            }

            return await Task.FromResult(IdentityResult.Failed("Null Story"));
        }

        public List<Story> GetStories()
        {
            return storyManager.GetStories();
        }

        public Story GetStories(int idStory)
        {
            if (idStory < 0) return null;
            return storyManager.GetStories(idStory);
        }

        public  List<Story> GetStoriesByUserName(string email)
        {
            if (String.IsNullOrWhiteSpace(email)) return null;
            if (userManager.FindByEmailAsync(email) == null) return null;
            return storyManager.GetStoriesByUserName(email);
        }
    }
}
