using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserStore.BLL.Entities;
using UserStore.BLL.Interfaces;
using UserStore.Controllers;
using UserStore.Models;

namespace UserStory.WEB.Test
{
    [TestClass]
    public class AccountControllerTest
    {
        private FakeUserService fakeUserService { get; }
        private AccountController controller { get; }

        public AccountControllerTest()
        {
            fakeUserService = new FakeUserService();
            controller = new AccountController(fakeUserService);
        }

        #region MyRegion

        [TestMethod]
        public void TestRegisterViewResultNotNull()
        {
            ViewResult result = controller.Register() as ViewResult;

            Assert.IsNotNull(result);
        }

        public void TestRegisterPostModelError()
        {
            RegisterModel model = new RegisterModel();
            controller.ModelState.AddModelError("Name", "Error");

            var result = controller.Register(model) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(model, result.Model);
        }

        [TestMethod]
        public void TestRegisterPostModelSuccess()
        {
            RegisterModel model = new RegisterModel();
            fakeUserService.SetFlagCreate(true);

            var result = controller.Register(model) as RedirectToRouteResult;

            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        #endregion

    }

    public class FakeUserService : IUserService
    {
        private bool flagCreate = false;
        private bool flagCreateIdentity = false;

        public void SetFlagCreateIdentity(bool flag)
        {
            flagCreateIdentity = flag;
        }

        public void SetFlagCreate(bool flag)
        {
            flagCreate = flag;
        }

        public Task<ClaimsIdentity> Authenticate(ApplicationUser userDto)
        {
            throw new NotImplementedException();
        }

        public Task Create(ApplicationUser userDto)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
