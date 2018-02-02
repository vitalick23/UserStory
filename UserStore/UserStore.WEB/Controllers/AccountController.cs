using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using UserStore.Models;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using UserStore.BLL.Interfaces;
using UserStore.BLL.Entities;

namespace UserStore.Controllers
{
    public class AccountController : Controller
    {
      
        private readonly IUserService userService;

      
        public AccountController(IUserService userService)
        {
            
            this.userService = userService;
        }
        
    

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
          
            if (ModelState.IsValid)
            {
                User userDto = new User{ Email = model.Email, PasswordHash = model.Password};
                ClaimsIdentity claim = await userService.Authenticate(userDto);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    HttpContext.GetOwinContext().Authentication.SignOut();
                    HttpContext.GetOwinContext().Authentication.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        
        public ActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if(model == null) return View(model);
                User user = new User
                {
                    Email = model.Email,
                    PasswordHash = model.Password,
                };
                 var result = await userService.Create(user,model.Password);
                 if(result.Succeeded)return View("SuccessRegister");
                else ModelState.AddModelError(result.Errors.ToString(),new Exception());
            }
            return View(model);
        }

       
    }
}