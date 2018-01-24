using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserStore.BLL.Entities;
using UserStore.BLL.Interfaces;
using UserStore.BLL.Services;

namespace UserStore.BLL.Tests
{
    [TestClass]
    public class UserServiceTest
    {
        private FakeIUnitOfwork fakeIUnitOfwork;
        private FakeUserManager _fakeUserManager;
        private User user;
        public UserServiceTest()
        {
            _fakeUserManager = new FakeUserManager();
            fakeIUnitOfwork = new FakeIUnitOfwork();
            user = new User();

        }
        #region TestsCreate

        [TestMethod]
        public async Task  CreateIfSuccess()
        {
            user.Email = "sd";
            _fakeUserManager.SetUser(user);
            var newUser = new User();
            fakeIUnitOfwork.SetFlagSave(true);
            _fakeUserManager.SetFlagUserCreate(true);
            var result = new UserService(fakeIUnitOfwork,_fakeUserManager);

            await result.Create(newUser);

            Assert.IsTrue(fakeIUnitOfwork.GetCountUsers() > 0);
        }

        [TestMethod]
        public async Task CreateIfFoundUser()
        {
            user.Email = "sd";
            _fakeUserManager.SetUser(user);
            fakeIUnitOfwork.SetFlagSave(true);
            _fakeUserManager.SetFlagUserCreate(true);
            var result = new UserService(fakeIUnitOfwork, _fakeUserManager);

            await result.Create(user);

            Assert.IsTrue(fakeIUnitOfwork.GetCountUsers() == 0);
        }

        [TestMethod]
        public async Task CreateIfNotCreateUser()
        {
            user.Email = "sd";
            _fakeUserManager.SetUser(user);
            fakeIUnitOfwork.SetFlagSave(true);
            _fakeUserManager.SetFlagUserCreate(false);
            var result = new UserService(fakeIUnitOfwork, _fakeUserManager);

            await result.Create(user);

            Assert.IsTrue(fakeIUnitOfwork.GetCountUsers() == 0);
        }

        [TestMethod]
        public async Task CreateIfNotSaveUser()
        {
            user.Email = "sd";
            _fakeUserManager.SetUser(user);
            fakeIUnitOfwork.SetFlagSave(false);
            _fakeUserManager.SetFlagUserCreate(true);
            var result = new UserService(fakeIUnitOfwork, _fakeUserManager);

            await result.Create(user);

            Assert.IsTrue(fakeIUnitOfwork.GetCountUsers() == 0);
        }

        [TestMethod]
        public async Task CreateIfUserNull()
        {
            user.Email = "sd";
            _fakeUserManager.SetUser(user);
            fakeIUnitOfwork.SetFlagSave(false);
            _fakeUserManager.SetFlagUserCreate(true);
            var result = new UserService(fakeIUnitOfwork, _fakeUserManager);

            await result.Create((User)null);

            Assert.IsTrue(fakeIUnitOfwork.GetCountUsers() == 0);
        }

        #endregion

        #region TestsAuthenticate

        [TestMethod]
        public async Task AuthenticateIfSuccess()
        {
           var user = new User{Email = "mail"};
            _fakeUserManager.SetUser(user); 
            _fakeUserManager.SetFlagIdentityCreate(true);
            var userService = new UserService(fakeIUnitOfwork, _fakeUserManager);

            var result = await userService.Authenticate(user);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task AuthenticateIfUserNull()
        {
            
            var userService = new UserService(fakeIUnitOfwork, _fakeUserManager);

            var result = await userService.Authenticate(null);

            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task AuthenticateIfNotFound()
        {
            var user = new User { Email = "mail" };
            _fakeUserManager.SetUser(user);
            var newUser = new User {Email = "newmail"};
            var userService = new UserService(fakeIUnitOfwork, _fakeUserManager);

            var result = await userService.Authenticate(newUser);

            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task AuthenticateIfNotCreateIdentity()
        {
            var user = new User { Email = "mail" };
            _fakeUserManager.SetUser(user);
           
            var userService = new UserService(fakeIUnitOfwork, _fakeUserManager);

            var result = await userService.Authenticate(user);

            Assert.IsNull(result);
        }

        #endregion


    }

    public class FakeUserManager : IUserManager
    {
        private User user;
        private bool flagUserCreate = false;
        private bool flagIdentityCreate = false;

        public void SetFlagUserCreate(bool flag)
        {
            flagUserCreate = flag;
        }
        public void SetFlagIdentityCreate(bool flag)
        {
            flagIdentityCreate = flag;
        }
        public void SetUser(User user)
        {
            this.user = user;
        }
        public UserManager<User> UserManagers;

        public Task<IdentityResult> CreateAsync(User user, string password)
        {
            if (flagUserCreate) return Task.FromResult(IdentityResult.Success);
            return Task.FromResult(IdentityResult.Failed());
        }

        public Task<ClaimsIdentity> CreateIdentityAsync(User user, string authenticationTypes)
        {
            if(flagIdentityCreate) return Task.FromResult(new ClaimsIdentity());
            return Task.FromResult((ClaimsIdentity)null);
        }

        public Task<User> FindAsync(string email, string password)
        {
            if (user.Email == email) return Task.FromResult(user);
            return Task.FromResult((User)null);
        }

        public Task<User> FindAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByEmailAsync(string email)
        {
            if (user.Email == email) return Task.FromResult(user);
            return Task.FromResult((User) null);
        }
    }
}



    public class FakeIUnitOfwork : IUnitOfWork
    {
        private bool flagSave = false;
        private List<User> listUser;

        public FakeIUnitOfwork()
        {
            listUser = new List<User>();
        }

        public int GetCountUsers()
        {
            return listUser.Count();
        }
        public void SetFlagSave(bool flag)
        {
            flagSave = flag;
        }
        public Microsoft.AspNet.Identity.UserManager<User> UserManager => throw new NotImplementedException();

        public Microsoft.AspNet.Identity.RoleManager<ApplicationRole> RoleManager => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
            if (flagSave) listUser.Add(new User());

        }
    }

