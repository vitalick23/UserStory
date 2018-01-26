using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UserStore.BLL.Entities;
using UserStore.BLL.Interfaces;
using UserStore.BLL.Interfaces.InterfaceFinder;
using UserStore.BLL.Interfaces.InterfaceRepositoru;
using UserStore.BLL.Services;

namespace UserStore.BLL.Tests.TestService
{
    [TestClass]
    public class CommentServiceTest
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<ICommentFinder> _commentFinderMock;
        private readonly Mock<ICommentRepositoru> _commentRepositoruMock;
        private readonly Mock<IUserFinder> _userFinderMock;
        private Comment comment;

        public CommentServiceTest()
        {
            _commentFinderMock = new Mock<ICommentFinder>();
            _commentRepositoruMock = new Mock<ICommentRepositoru>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _userFinderMock = new Mock<IUserFinder>();
            comment = new Comment();
        }

        [TestMethod]
        public void CreateifSuccess()
        {
            _commentRepositoruMock.Setup(x => x.CreateComment(It.IsAny<Comment>()));
            _unitOfWorkMock.Setup(x => x.SaveAsync());
            var commentService = new CommentService(_unitOfWorkMock.Object,
                                                    _commentFinderMock.Object,
                                                    _userFinderMock.Object,
                                                    _commentRepositoruMock.Object
                                                    );

            var result = commentService.CreateComment(comment);
        }

        [TestMethod]
        public void CreateifcommentNull()
        {
            _commentRepositoruMock.Setup(x => x.CreateComment(It.IsAny<Comment>()));
            _unitOfWorkMock.Setup(x => x.SaveAsync());
            var commentService = new CommentService(_unitOfWorkMock.Object,
                _commentFinderMock.Object,
                _userFinderMock.Object,
                _commentRepositoruMock.Object
            );

            var result = commentService.CreateComment(comment);

            
        }
    }
}
