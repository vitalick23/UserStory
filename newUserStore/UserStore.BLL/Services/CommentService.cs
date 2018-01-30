using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserStore.BLL.Entities;
using UserStore.BLL.Interfaces;
using UserStore.BLL.Interfaces.InterfaceFinder;
using UserStore.BLL.Interfaces.InterfaceRepositoru;

namespace UserStore.BLL.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommentFinder _commentFinder;
        private readonly ICommentRepositoru _commentRepositoru;
        private readonly IUserFinder _userFinder;

        public CommentService(IUnitOfWork uow,
            ICommentFinder commentFinder,
            IUserFinder userFinder,
            ICommentRepositoru commentRepositoru)
        {
            _userFinder = userFinder;
            _commentFinder = commentFinder;
            _commentRepositoru = commentRepositoru;
            _unitOfWork = uow;

        }

        public async Task CreateComment(Comment item)
        {
            if (item != null)
            {
                item.TimePublicate = DateTime.Now;
                _commentRepositoru.CreateComment(item);
                await _unitOfWork.SaveAsync();

            } 
        }

        public async Task<List<Comment>> GetCommentByIdStory(int StoryId)
        {
           var resylt = _commentFinder.GetCommentByIdStory(StoryId);
            foreach (var item in resylt)
            {
                if (item.User == null) item.User = _userFinder.FindById(item.UserId);
            }
            return resylt;
        }
    }
}
