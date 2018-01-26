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
using UserStore.BLL.Interfaces.InterfaceFinder;
using UserStore.BLL.Services;

//see Home https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs

namespace UserStore.BLL.Tests
{
    [TestClass]
    public class UserServiceTest
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IUserRepositoru> _userRepositoruMock;
        private readonly Mock<IUserFinder> _userFinderMock;
        private readonly Mock<IAuthenticationManager> _autoMock;

        private User user;

        public UserServiceTest()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _userFinderMock = new Mock<IUserFinder>();
            _userRepositoruMock = new Mock<IUserRepositoru>();
            _autoMock = new Mock<IAuthenticationManager>();
            user = new User { Email = "mail", UserName = "mail", Id = "1" };

        }

        #region TestsCreate

        [TestMethod]
        public async Task CreateIfSuccess()
        {
            _userFinderMock.Setup(x => x.FindByEmail(It.IsAny<string>()))
                .Returns((User)null);

            _userRepositoruMock.Setup(x => x.Create(It.IsAny<User>(), It.IsAny<string>()));
               
            _unitOfWorkMock.Setup(x => x.SaveAsync())
                .Returns(Task.CompletedTask);

            var newUser = new User();
            var userService = new UserService(_unitOfWorkMock.Object, 
                                                _userFinderMock.Object,
                                                _userRepositoruMock.Object,
                                                _autoMock.Object
                                                );

            var result = await userService.Create(newUser, "123");

            Assert.IsTrue(result.Succeeded);
        }

        [TestMethod]
        public async Task CreateIfFoundUser()
        {
            _userFinderMock.Setup(x => x.FindByEmail(It.IsAny<string>()))
                .Returns(new User());

            var newUser = new User();
            var userService = new UserService(_unitOfWorkMock.Object,
                                                _userFinderMock.Object,
                                                _userRepositoruMock.Object,
                                                _autoMock.Object
                                            );

            var result = await userService.Create(newUser, "123");

            Assert.IsTrue(result.Errors.First() == "Found user");
        }

        [TestMethod]
        public async Task CreateIfNotCreateUser()
        {
            _userFinderMock.Setup(x => x.FindByEmail(It.IsAny<string>()))
                .Returns(new User());

            _userRepositoruMock.Setup(x => x.Create(It.IsAny<User>(), It.IsAny<string>()))
                .Throws(new Exception());

            var newUser = new User();
            var userService = new UserService(_unitOfWorkMock.Object,
                                                _userFinderMock.Object,
                                                _userRepositoruMock.Object,
                                                _autoMock.Object
                                            );

            var result = await userService.Create(newUser, "123");

            Assert.IsTrue(!result.Succeeded);
        }

        [TestMethod]
        public async Task CreateIfNotSaveUser()
        {
            _userFinderMock.Setup(x => x.FindByEmail(It.IsAny<string>()))
                .Returns(new User());

            _userRepositoruMock.Setup(x => x.Create(It.IsAny<User>(), It.IsAny<string>()));

            _unitOfWorkMock.Setup(x => x.SaveAsync())
                .Throws(new SystemException());

            var newUser = new User();
            var userService = new UserService(_unitOfWorkMock.Object,
                                                _userFinderMock.Object,
                                                _userRepositoruMock.Object,
                                                _autoMock.Object
                                            );

            var result = await userService.Create(newUser, "123");

            Assert.IsFalse(result.Succeeded);
        }

        [TestMethod]
        public async Task CreateIfUserNull()
        {
            var userService = new UserService(_unitOfWorkMock.Object,
                                                _userFinderMock.Object,
                                                _userRepositoruMock.Object,
                                                _autoMock.Object
                                            );

            var result = await userService.Create(null, "123");

            Assert.IsFalse(result.Succeeded);
        }

        [TestMethod]
        public async Task CreateIfUserNameNameEmpty()
        {
            _userFinderMock.Setup(x => x.FindByEmail(It.IsAny<string>()))
                .Returns(new User());

            _userRepositoruMock.Setup(x => x.Create(It.IsAny<User>(), It.IsAny<string>()));

            _userRepositoruMock.Setup(x => x.Create(
                    It.Is<User>(u => String.IsNullOrWhiteSpace(u.UserName)),
                    It.Is<string>(s => s == String.Empty)))
                .Throws(new Exception());

            _unitOfWorkMock.Setup(x => x.SaveAsync())
                .Returns(Task.CompletedTask);
            var newUser = new User();
            var userService = new UserService(_unitOfWorkMock.Object,
                                                _userFinderMock.Object,
                                                _userRepositoruMock.Object,
                                                _autoMock.Object
                                            );

            var result = await userService.Create(newUser, "123");

            Assert.IsFalse(result.Succeeded);
        }

        #endregion

        #region TestsAuthenticate

        [TestMethod]
        public async Task AuthenticateIfSuccess()
        {
            _userFinderMock.Setup(x => x.Find(It.IsAny<string>(),It.IsAny<string>()))
                .Returns(new User());

            _autoMock.Setup(x => x.CreateClaimIdentity(It.IsAny<User>(), It.IsAny<String>()))
                .Returns(Task.FromResult(new ClaimsIdentity()));

            var userService = new UserService(_unitOfWorkMock.Object,
                                                _userFinderMock.Object,
                                                _userRepositoruMock.Object,
                                                _autoMock.Object
                                            );

            var result = await userService.Authenticate(user);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task AuthenticateIfUserNull()
        {

            var userService = new UserService(_unitOfWorkMock.Object,
                                                _userFinderMock.Object,
                                                _userRepositoruMock.Object,
                                                _autoMock.Object
                                            );

            var result = await userService.Authenticate(null);

            Assert.IsNull(result);
        }


        [TestMethod]
        public async Task AuthenticateIfNotFound()
        {
            _userFinderMock.Setup(x => x.Find(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((User)null);

            var userService = new UserService(_unitOfWorkMock.Object,
                                                _userFinderMock.Object,
                                                _userRepositoruMock.Object,
                                                _autoMock.Object
                                            );

            var result = await userService.Authenticate(user);

            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task AuthenticateIfNotCreateIdentity()
        {
            _userFinderMock.Setup(x => x.Find(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new User());

            _autoMock.Setup(x => x.CreateClaimIdentity(It.IsAny<User>(), It.IsAny<String>()))
                .Returns(Task.FromResult((ClaimsIdentity)null));

            var userService = new UserService(_unitOfWorkMock.Object,
                                                _userFinderMock.Object,
                                                _userRepositoruMock.Object,
                                                _autoMock.Object
                                            );

            var result = await userService.Authenticate(user);

            Assert.IsNull(result);
        }

        #endregion

        #region TestFindById

        [TestMethod]
        public async Task FindByIdIfSaccess()
        {
            _userFinderMock.Setup(x => x.FindById(It.IsAny<string>()))
                .Returns(new User());

            var userService = new UserService(_unitOfWorkMock.Object,
                _userFinderMock.Object,
                _userRepositoruMock.Object,
                _autoMock.Object
            );

            var result = await userService.FindById("1");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task FindByIdIfIdNull()
        {
            _userFinderMock.Setup(x => x.FindById(It.IsAny<string>()))
                .Returns(new User());

            var userService = new UserService(_unitOfWorkMock.Object,
                                                _userFinderMock.Object,
                                                _userRepositoruMock.Object,
                                                _autoMock.Object
                                            );

            var result = await userService.FindById(null);

            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task FindByIdIfIdEmpty()
        {
            _userFinderMock.Setup(x => x.FindById(It.IsAny<string>()))
                .Returns(new User());

            var userService = new UserService(_unitOfWorkMock.Object,
                                                _userFinderMock.Object,
                                                _userRepositoruMock.Object,
                                                _autoMock.Object
                                            );

            var result = await userService.FindById(String.Empty);

            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task FindByIdIfNotFoundUser()
        {
            _userFinderMock.Setup(x => x.Find(It.IsAny<string>(),It.IsAny<string>()))
                .Returns((User)null);

            var userService = new UserService(_unitOfWorkMock.Object,
                _userFinderMock.Object,
                _userRepositoruMock.Object,
                _autoMock.Object
            );

            var result = await userService.FindById("2");

            Assert.IsNull(result);
        }

        #endregion
    }
}




