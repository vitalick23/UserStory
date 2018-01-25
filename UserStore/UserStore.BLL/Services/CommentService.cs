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
        private IUnitOfWork unitOfWork;
        
        private ICommentManager commentService;
        private IUserService userService;

        public CommentService(IUnitOfWork uow,ICommentManager commentService, IUserService userService)
        {
            this.userService = userService;
            this.commentService = commentService;
            unitOfWork = uow;

        }

        public async Task CreateComment(Comment item)
        {
            if (item != null)
            {
                item.TimePublicate = DateTime.Now;
                commentService.CreateComment(item);
                await unitOfWork.SaveAsync();

            } 
        }

        public async Task<List<Comment>> GetCommentByIdStory(int StoryId)
        {
           var resylt = commentService.GetCommentByIdStory(StoryId);
            foreach (var item in resylt)
            {
                if (item.User == null) item.User = await userService.FindById(item.UserId);
            }

            return resylt;
        }
    }
}
