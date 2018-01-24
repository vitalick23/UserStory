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
    public class CommentService : ICommentService
    {
        private IUnitOfWork database { get; set; }
        private IStoryManager storyManager;
        private IUserManager userManager;
        private ICommentService commentService;

        public CommentService(IUnitOfWork uow,ICommentService commentService ,IStoryManager storiesManager, IUserManager userManager)
        {
            this.storyManager = storiesManager;
            this.userManager = userManager;
            this.commentService = commentService;
            database = uow;

        }

        public async Task<IdentityResult> CreateComment(Comment item)
        {
            if (item != null)
            {
                item.Story = storyManager.GetStories(item.Id);
                item.ApplicationUser = await userManager.FindAsync(item.UserId);
                var result  = await commentService.CreateComment(item);
                if (result.Succeeded) await database.SaveAsync();
                return result;
            }
            return IdentityResult.Failed("Null Comment");
        }

        public List<Comment> GetCommentByIdStory(int StoryId)
        {
            throw new NotImplementedException();
        }
    }
}
