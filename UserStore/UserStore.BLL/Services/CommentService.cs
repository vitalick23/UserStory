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
        private IUnitOfWork unitOfWork { get; set; }
        
        private ICommentManager commentService;

        public CommentService(IUnitOfWork uow,ICommentManager commentService)
        {
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

        public List<Comment> GetCommentByIdStory(int StoryId)
        {
           return commentService.GetCommentByIdStory(StoryId);
        }
    }
}
