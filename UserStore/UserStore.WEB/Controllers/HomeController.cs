using System.Web.Mvc;
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