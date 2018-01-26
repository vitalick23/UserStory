using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserStore.BLL.Entities;
using UserStore.BLL.Interfaces;
using Microsoft.AspNet.Identity;
using Moq;
using UserStore.BLL.Interfaces.InterfaceFinder;
using UserStore.BLL.Interfaces.InterfaceRepositoru;
using UserStore.BLL.Services;

namespace UserStore.BLL.Tests.TestService
{
    
    [TestClass]
    public class StoryServiceTest
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IStoryFinder> _storfinderMock;
        private readonly Mock<IStoryRepositoru> _storyRepositoryMock;
        private readonly Mock<IUserFinder> _userFinderMock;
        
        private Story story;
        private User user;

        public StoryServiceTest()
        {
            _storyRepositoryMock = new Mock<IStoryRepositoru>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _storfinderMock = new Mock<IStoryFinder>();
            _userFinderMock = new Mock<IUserFinder>();
            user = new User {UserName = "1", Email = "1"};
            story = new Story
            {
                Id = 1,
                User = user
            };
        }

        #region TestCreate

        [TestMethod]
        public async Task CreateIfSuccess()
        {
            _storyRepositoryMock.Setup(x => x.Create(story));

            _unitOfWorkMock.Setup(x => x.SaveAsync()).Returns(Task.CompletedTask);
            var userStories = new StoryService(_unitOfWorkMock.Object,
                                                _storyRepositoryMock.Object,
                                                _storfinderMock.Object,
                                                _userFinderMock.Object
                                              );

            var result = await userStories.Create(story);

            Assert.IsTrue(result.Succeeded);
        }

        [TestMethod]
        public async Task CreateIfStoryNull()
        {

            var userStories = new StoryService(_unitOfWorkMock.Object,
                                                _storyRepositoryMock.Object,
                                                _storfinderMock.Object,
                                                _userFinderMock.Object
                                              );

            var result = await userStories.Create(null);

            Assert.IsTrue(result.Errors.First() == "Null Story");
        }
        
        [TestMethod]
        public async Task CreateIfNotCreate()
        {
            _storyRepositoryMock.Setup(x => x.Create(It.IsAny<Story>()))
                .Throws<System.ArgumentOutOfRangeException>();

            var userStories = new StoryService(_unitOfWorkMock.Object,
                                                _storyRepositoryMock.Object,
                                                _storfinderMock.Object,
                                                _userFinderMock.Object
                                              );

            var result = await userStories.Create(story);

            
            Assert.IsTrue(!result.Succeeded);
        }

        [TestMethod]
        public async Task CreateIfNotSave()
        {
            _storyRepositoryMock.Setup(x => x.Create(It.IsAny<Story>()))
                .Throws<System.ArgumentOutOfRangeException>();
            _unitOfWorkMock.Setup(x => x.SaveAsync())
                .Returns(Task.FromException(new Exception()));
            var userStories = new StoryService(_unitOfWorkMock.Object,
                                                _storyRepositoryMock.Object,
                                                _storfinderMock.Object,
                                                _userFinderMock.Object
                                              );
            var result = await userStories.Create(story);
            
            Assert.IsFalse(result.Succeeded);
        }
        #endregion

        #region TestGetStories

        [TestMethod]
        public void GetStoriesAllIfSuccess()
        {
            _storfinderMock.Setup(x => x.GetStories())
                .Returns(new List<Story>
                {
                    new Story(),
                    new Story()
                });
            var userStories = new StoryService(_unitOfWorkMock.Object,
                                                _storyRepositoryMock.Object,
                                                _storfinderMock.Object,
                                                _userFinderMock.Object
                                            );

            var result = userStories.GetStories();

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void GetStoriesAllIfNull()
        {
            _storfinderMock.Setup(x => x.GetStories())
                .Returns((List<Story>)null);

            var userStories = new StoryService(_unitOfWorkMock.Object,
                                                _storyRepositoryMock.Object,
                                                _storfinderMock.Object,
                                                _userFinderMock.Object
                                            );

            var result = userStories.GetStories();

            Assert.IsTrue(result == null);
        }

        [TestMethod]
        public void GetStoriesOneIfIdNegative()
        {

            var userStories = new StoryService(_unitOfWorkMock.Object,
                                                _storyRepositoryMock.Object,
                                                _storfinderMock.Object,
                                                _userFinderMock.Object
                                            );

            var result = userStories.GetStories(-2);

            Assert.IsTrue(result == null);
        }

        [TestMethod]
        public void GetStoriesOneIfSuccess()
        {
            _storfinderMock.Setup(x => x.GetStories(It.IsAny<int>()))
                .Returns(new Story());
            var userStories = new StoryService(_unitOfWorkMock.Object,
                                                    _storyRepositoryMock.Object,
                                                    _storfinderMock.Object,
                                                    _userFinderMock.Object
                                                );

            var result = userStories.GetStories(1);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetStoriesOneIfNotFound()
        {
            _storfinderMock.Setup(x => x.GetStories(It.Is<int>(i => i > 10)))
                .Returns(new Story());
            _storfinderMock.Setup(x => x.GetStories(It.Is<int>(i => i < 10)))
                .Returns((Story)null);
            var userStories = new StoryService(_unitOfWorkMock.Object,
                                                _storyRepositoryMock.Object,
                                                _storfinderMock.Object,
                                                _userFinderMock.Object
                                            );

            var result = userStories.GetStories(10);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetStoriesByUserIdIfSuccess()
        {
            _userFinderMock.Setup(x => x.FindById(It.IsAny<string>()))
                .Returns(new User());
            _storfinderMock.Setup(x => x.GetStoriesByUserId(It.IsAny<string>()))
                .Returns(new List<Story>
                {
                    new Story()
                });
            var userStories = new StoryService(_unitOfWorkMock.Object,
                                                _storyRepositoryMock.Object,
                                                _storfinderMock.Object,
                                                _userFinderMock.Object
                                            );

            var result = userStories.GetStoriesByUserName("1");

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void GetStoriesByUserIDIfIdNull()
        {
            var userStories = new StoryService(_unitOfWorkMock.Object,
                _storyRepositoryMock.Object,
                _storfinderMock.Object,
                _userFinderMock.Object
            ); 

            var result = userStories.GetStoriesByUserName(null);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetStoriesByIDNameUserIfNotFaundUser()
        {
            _userFinderMock.Setup(x => x.FindByEmail(It.IsAny<string>()))
                .Returns((User)null);
            var userStories = new StoryService(_unitOfWorkMock.Object,
                                                _storyRepositoryMock.Object,
                                                _storfinderMock.Object,
                                                _userFinderMock.Object
                                            );

            var result = userStories.GetStoriesByUserName("1");

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetStoriesByUserIdIfNotFaundStory()
        {
            _userFinderMock.Setup(x => x.FindByEmail(It.IsAny<string>()))
                .Returns(new User());
            _storfinderMock.Setup(x => x.GetStoriesByUserId(It.IsAny<string>()))
                .Returns((List<Story>)null);
            var userStories = new StoryService(_unitOfWorkMock.Object,
                                                _storyRepositoryMock.Object,
                                                _storfinderMock.Object,
                                                _userFinderMock.Object
                                            );

            var result = userStories.GetStoriesByUserName("1");

            Assert.IsNull(result);
        }

        #endregion
    }
}
