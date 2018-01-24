using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using UserStore.BLL.Entities;
using UserStore.BLL.Interfaces;

namespace UserStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStorySevice storyService;

        public HomeController(IStorySevice storyService)
        {
            this.storyService = storyService;
        }

        public ActionResult Index()
        {
            var model = storyService.GetStories();
            return View(model);
        }
       
    }
}