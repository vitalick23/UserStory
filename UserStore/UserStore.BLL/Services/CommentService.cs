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

        public async void CreateComment(Comment item)
        {
            if (item != null)
            {
                item.Story = storyManager.GetStories(item.Id);
                item.User = await userManager.FindAsync(item.UserId);
                commentService.CreateComment(item);
                
            } 
        }

        public List<Comment> GetCommentByIdStory(int StoryId)
        {
           return commentService.GetCommentByIdStory(StoryId);
        }
    }
}
