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
        private IUnitOfWork unitOfWork;
        private IStoryManager storyManager;
        private IUserManager userManager;

        public StoryService(IUnitOfWork uow, IStoryManager storiesManager, IUserManager userManager)
        {
            this.storyManager = storiesManager;
            this.userManager = userManager;
            unitOfWork = uow;

        }
        public async Task<IdentityResult> Create(Story item)
        {
            if (item != null)
            {
               // item.User = await userManager.FindAsync(item.UserId);
                storyManager.Create(item);
                await unitOfWork.SaveAsync();
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
