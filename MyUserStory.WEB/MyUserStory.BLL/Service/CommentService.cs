using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyUserStory.BLL.Entities;
using MyUserStory.BLL.Interfaces.InterfaceFinder;
using MyUserStory.BLL.Interfaces.InterfaceRepository;
using MyUserStory.BLL.Interfaces.InterfaceService;

namespace MyUserStory.BLL.Service
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommentFinder _commentFinder;
        private readonly ICommentRepository _commentRepository;
        private readonly IUserFinder _userFinder;

        public CommentService(IUnitOfWork uow,
            ICommentFinder commentFinder,
            IUserFinder userFinder,
            ICommentRepository commentRepository)
        {
            _userFinder = userFinder;
            _commentFinder = commentFinder;
            _commentRepository = commentRepository;
            _unitOfWork = uow;

        }

        public async Task CreateComment(Comment item)
        {
            if (item != null)
            {
                item.TimePublicate = DateTime.Now;
                _commentRepository.CreateComment(item);
                await _unitOfWork.SaveAsync();

            } 
        }

        public async Task<List<Comment>> GetCommentByIdStory(string StoryId)
        {
           var resylt =  _commentFinder.GetCommentByIdStory(StoryId);
           return resylt;
        }
    }
}
