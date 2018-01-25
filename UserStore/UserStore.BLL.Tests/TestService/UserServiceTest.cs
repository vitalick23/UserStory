using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UserStore.BLL.Entities;
using UserStore.BLL.Interfaces;
using UserStore.BLL.Services;

//see Home https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs

namespace UserStore.BLL.Tests
{
    [TestClass]
    public class UserServiceTest
    {
        private readonly Mock<IUnitOfWork> unitOfWorkMock;
        private readonly Mock<IUserManager> userserviceMock;
   
        private User user;

        public UserServiceTest()
        {
            unitOfWorkMock = new Mock<IUnitOfWork>();
            userserviceMock = new Mock<IUserManager>();
            user = new User {Email = "mail", UserName = "mail", Id = "1"};

        }

        #region TestsCreate

        [TestMethod]
        public async Task CreateIfSuccess()
        {
            userserviceMock.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
                .Returns(Task.FromResult((User) null));

            userserviceMock.Setup(x => x.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(Task.FromResult(IdentityResult.Success));

            unitOfWorkMock.Setup(x => x.SaveAsync())
                .Returns(Task.CompletedTask);

            var newUser = new User();
            var userService = new UserService(unitOfWorkMock.Object, userserviceMock.Object);

            var result = await userService.Create(newUser, "123");

            Assert.IsTrue(result.Succeeded);
        }

        [TestMethod]
        public async Task CreateIfFoundUser()
        {
            userserviceMock.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(new User()));

            var newUser = new User();
            var userService = new UserService(unitOfWorkMock.Object, userserviceMock.Object);

            var result = await userService.Create(newUser, "123");

            Assert.IsTrue(result.Errors.First() == "Found user");
        }

        [TestMethod]
        public async Task CreateIfNotCreateUser()
        {
            userserviceMock.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(new User()));

            userserviceMock.Setup(x => x.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(Task.FromResult(IdentityResult.Failed("error")));

            var newUser = new User();
            var userService = new UserService(unitOfWorkMock.Object, userserviceMock.Object);

            var result = await userService.Create(newUser, "123");

            Assert.IsTrue(!result.Succeeded);
        }

        [TestMethod]
        public async Task CreateIfNotSaveUser()
        {
            userserviceMock.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(new User()));

            userserviceMock.Setup(x => x.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(Task.FromResult(IdentityResult.Success));

            unitOfWorkMock.Setup(x => x.SaveAsync())
                .Throws(new SystemException());

            var newUser = new User();
            var userService = new UserService(unitOfWorkMock.Object, userserviceMock.Object);

            var result = await userService.Create(newUser, "123");

            Assert.IsFalse(result.Succeeded);
        }

        [TestMethod]
        public async Task CreateIfUserNull()
        {
            var userService = new UserService(unitOfWorkMock.Object, userserviceMock.Object);

            var result = await userService.Create(null, "123");

            Assert.IsFalse(result.Succeeded);
        }

        [TestMethod]
        public async Task CreateIfUserNameNameEmpty()
        {
            userserviceMock.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(new User()));

            userserviceMock.Setup(x => x.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(Task.FromResult(IdentityResult.Success));

            userserviceMock.Setup(x => x.CreateAsync(
                    It.Is<User>(u => String.IsNullOrWhiteSpace(u.UserName)),
                    It.Is<string>(s => s == String.Empty)))
                .Returns(Task.FromResult(IdentityResult.Failed("Erorr")));

            unitOfWorkMock.Setup(x => x.SaveAsync())
                .Returns(Task.CompletedTask);
            var newUser = new User();
            var userService = new UserService(unitOfWorkMock.Object, userserviceMock.Object);

            var result = await userService.Create(newUser, "123");

            Assert.IsFalse(result.Succeeded);
        }

        #endregion

        #region TestsAuthenticate

        [TestMethod]
        public async Task AuthenticateIfSuccess()
        {
            userserviceMock.Setup(x => x.FindAsync(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult(new User()));

            userserviceMock.Setup(x => x.CreateIdentityAsync(It.IsAny<User>(), It.IsAny<String>()))
                .Returns(Task.FromResult(new ClaimsIdentity()));

            var userService = new UserService(unitOfWorkMock.Object, userserviceMock.Object);

            var result = await userService.Authenticate(user);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task AuthenticateIfUserNull()
        {

            var userService = new UserService(unitOfWorkMock.Object, userserviceMock.Object);

            var result = await userService.Authenticate(null);

            Assert.IsNull(result);
        }


        [TestMethod]
        public async Task AuthenticateIfNotFound()
        {
            userserviceMock.Setup(x => x.FindAsync(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult((User) null));

            var userService = new UserService(unitOfWorkMock.Object, userserviceMock.Object);

            var result = await userService.Authenticate(user);

            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task AuthenticateIfNotCreateIdentity()
        {
            userserviceMock.Setup(x => x.FindAsync(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult(new User()));

            userserviceMock.Setup(x => x.CreateIdentityAsync(It.IsAny<User>(), It.IsAny<String>()))
                .Returns(Task.FromResult((ClaimsIdentity) null));

            var userService = new UserService(unitOfWorkMock.Object, userserviceMock.Object);

            var result = await userService.Authenticate(user);

            Assert.IsNull(result);
        }

        #endregion

        #region TestFindById

        [TestMethod]
        public async Task FindByIdIfSaccess()
        {
            userserviceMock.Setup(x => x.FindAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(new User()));

            var userService = new UserService(unitOfWorkMock.Object, userserviceMock.Object);

            var result = await userService.FindById("1");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task FindByIdIfIdNull()
        {
            userserviceMock.Setup(x => x.FindAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(new User()));

            var userService = new UserService(unitOfWorkMock.Object, userserviceMock.Object);

            var result = await userService.FindById(null);

            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task FindByIdIfIdEmpty()
        {
            userserviceMock.Setup(x => x.FindAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(new User()));

            var userService = new UserService(unitOfWorkMock.Object, userserviceMock.Object);

            var result = await userService.FindById(String.Empty);

            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task FindByIdIfNotFoundUser()
        {
            userserviceMock.Setup(x => x.FindAsync(It.IsAny<string>()))
                .Returns(Task.FromResult((User) null));

            var userService = new UserService(unitOfWorkMock.Object, userserviceMock.Object);

            var result = await userService.FindById("2");

            Assert.IsNull(result);
        }

        #endregion
    }
}


    

