using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UserStore.BLL.Entities;
using UserStore.BLL.Interfaces;
using UserStore.Models;

namespace UserStore.Controllers
{
    public class StoryController : Controller
    {
        private readonly IStorySevice storyService;

        public StoryController(IStorySevice storyService)
        {
            this.storyService = storyService;
        }

        // GET: Story
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult CreateStory()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async  Task<ActionResult> CreateStory(StoryModel model)
        {
            if (ModelState.IsValid && model != null)
            {
                model.TimePublicate = DateTime.Now;
                var result = await storyService.Create((Story) model);
                if(result.Succeeded)return View("Index");
                return View(model);
            }
            return View(model);
        }
       
    }
}
