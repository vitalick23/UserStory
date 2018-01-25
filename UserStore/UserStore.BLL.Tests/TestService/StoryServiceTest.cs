using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserStore.BLL.Entities;
using UserStore.BLL.Interfaces;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using Moq;
using UserStore.BLL.Services;

namespace UserStore.BLL.Tests.TestService
{
    
    [TestClass]
    public class StoryServiceTest
    {
        private readonly Mock<IUnitOfWork> UnitOfWorkMock;
        private readonly Mock<IStoryManager> storyManagerMock;
        private readonly Mock<IUserManager> userManagerMock;
        
        private Story story;
        private User user;

        public StoryServiceTest()
        {
            userManagerMock = new Mock<IUserManager>();
            UnitOfWorkMock = new Mock<IUnitOfWork>();
            storyManagerMock = new Mock<IStoryManager>();
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
            storyManagerMock.Setup(x => x.Create(story));

            UnitOfWorkMock.Setup(x => x.SaveAsync()).Returns(Task.CompletedTask);
            var userStories = new StoryService(UnitOfWorkMock.Object,storyManagerMock.Object,userManagerMock.Object);

            var result = await userStories.Create(story);

            Assert.IsTrue(result.Succeeded);
        }

        [TestMethod]
        public async Task CreateIfStoryNull()
        {
            
            var userStories = new StoryService(UnitOfWorkMock.Object, storyManagerMock.Object, userManagerMock.Object);

            var result = await userStories.Create(null);

            Assert.IsTrue(result.Errors.First() == "Null Story");
        }
        
        [TestMethod]
        public async Task CreateIfNotCreate()
        {
            storyManagerMock.Setup(x => x.Create(It.IsAny<Story>())).Throws<System.ArgumentOutOfRangeException>();
            var userStories = new StoryService(UnitOfWorkMock.Object, storyManagerMock.Object, userManagerMock.Object);

            var result = await userStories.Create(story);

            
            Assert.IsTrue(!result.Succeeded);
        }

        [TestMethod]
        public async Task CreateIfNotSave()
        {
            UnitOfWorkMock.Setup(x => x.SaveAsync()).Returns(Task.FromException(new Exception()));
            var userStories = new StoryService(UnitOfWorkMock.Object, storyManagerMock.Object, userManagerMock.Object);

            var result = await userStories.Create(story);
            
            Assert.IsFalse(result.Succeeded);
        }
        #endregion

        #region TestGetStories

        [TestMethod]
        public void GetStoriesAllIfSuccess()
        {
            storyManagerMock.Setup(x => x.GetStories())
                .Returns(new List<Story>
                {
                    new Story(),
                    new Story()
                });
            var userStories = new 
                StoryService( UnitOfWorkMock.Object,
                                storyManagerMock.Object, 
                                userManagerMock.Object
                            );

            var result = userStories.GetStories();

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void GetStoriesAllIfNull()
        {
            storyManagerMock.Setup(x => x.GetStories())
                .Returns((List<Story>)null);
               
            var userStories = new StoryService(UnitOfWorkMock.Object,
                storyManagerMock.Object, userManagerMock.Object);

            var result = userStories.GetStories();

            Assert.IsTrue(result == null);
        }

        [TestMethod]
        public void GetStoriesOneIfIdNegative()
        {
            
            var userStories = new StoryService(UnitOfWorkMock.Object, 
                storyManagerMock.Object, userManagerMock.Object);

            var result = userStories.GetStories(-2);

            Assert.IsTrue(result == null);
        }

        [TestMethod]
        public void GetStoriesOneIfSuccess()
        {
            storyManagerMock.Setup(x => x.GetStories(It.IsAny<int>()))
                .Returns(new Story());

            var userStories = new StoryService(UnitOfWorkMock.Object, storyManagerMock.Object, userManagerMock.Object);

            var result = userStories.GetStories(1);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetStoriesOneIfNotFound()
        {
            storyManagerMock.Setup(x => x.GetStories(It.Is<int>(i => i > 10)))
                .Returns(new Story());
            storyManagerMock.Setup(x => x.GetStories(It.Is<int>(i => i < 10)))
                .Returns((Story)null);
            var userStories = new StoryService(UnitOfWorkMock.Object, storyManagerMock.Object, userManagerMock.Object);

            var result = userStories.GetStories(10);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetStoriesByIDNameUserIfSuccess()
        {
            userManagerMock.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(new User()));
            storyManagerMock.Setup(x => x.GetStoriesByUserName(It.IsAny<string>()))
                .Returns(new List<Story>
                {
                    new Story()
                });
            var userStories = new StoryService(UnitOfWorkMock.Object, 
                storyManagerMock.Object, userManagerMock.Object);

            var result = userStories.GetStoriesByUserName("1");

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void GetStoriesByIDNameUserIfEmailNull()
        {
            var userStories = new StoryService(UnitOfWorkMock.Object, 
                storyManagerMock.Object, userManagerMock.Object);

            var result = userStories.GetStoriesByUserName(null);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetStoriesByIDNameUserIfNotFaundUser()
        {
            userManagerMock.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
                .Returns(Task.FromResult((User) null));
            var userStories = new StoryService(UnitOfWorkMock.Object, 
                storyManagerMock.Object, userManagerMock.Object);

            var result = userStories.GetStoriesByUserName("1");

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetStoriesByIDNameUserIfNotFaundStory()
        {
            userManagerMock.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(new User()));
            storyManagerMock.Setup(x => x.GetStoriesByUserName(It.IsAny<string>()))
                .Returns((List<Story>) null);
            var userStories = new StoryService(UnitOfWorkMock.Object,
                storyManagerMock.Object, userManagerMock.Object);

            var result = userStories.GetStoriesByUserName("1");

            Assert.IsNull(result);
        }

        #endregion
    }
}
