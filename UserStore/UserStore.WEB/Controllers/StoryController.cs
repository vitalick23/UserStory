using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Web.Mvc;
using UserStore.BLL.Entities;
using UserStore.BLL.Interfaces;
using UserStore.Models;

namespace UserStore.Controllers
{
    public class StoryController : Controller
    {
        private readonly IStorySevice _storyService;

        private readonly ICommentService _commentService;
        public StoryController(ICommentService commentService,IStorySevice storyService)
        {
            _commentService = commentService;
            _storyService = storyService;
        }

        // GET: Stories
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
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
                var result = await _storyService.Create((Story) model);  
                if(result.Succeeded) return RedirectToAction("Index","Home");
               
            }
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Stories(int id)
        {
            var story =  _storyService.GetStories(id);

            if (story != null)
            {
                var model = new StoryAndCommentModel();
                model.Story = story;
                model.CommentList = await _commentService.GetCommentByIdStory(id);
                return View(model);

            }
            else return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CommentPartial(int storyId, string text)
        {
            var comment = new Comment
            {
                StoriesId = storyId,
                Text = text,
                UserId = User.Identity.GetUserId()
            };
            await _commentService.CreateComment(comment);
            var allComment = await _commentService.GetCommentByIdStory(storyId);
            
            return PartialView(allComment);
        }

    }
}
