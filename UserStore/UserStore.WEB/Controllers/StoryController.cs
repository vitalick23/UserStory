using Microsoft.AspNet.Identity;
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

        private readonly ICommentService commentService;
        public StoryController(ICommentService commentService,IStorySevice storyService)
        {
            this.commentService = commentService;
            this.storyService = storyService;
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
                var result = await storyService.Create((Story) model);  
                if(result.Succeeded) return RedirectToAction("Index","Home");
               
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Stories(int id)
        {
            var story =  storyService.GetStories(id);

            if (story != null)
            {
                var model = new StoryAndCommentModel();
                model.Story = story;
                model.CommentList = commentService.GetCommentByIdStory(id);
                return View(model);

            }
            else return RedirectToAction("Index", "Home");
        }

       
        [HttpPost]
        public async Task<ActionResult> CommentPartial(int Storyid, string text)
        {
            var comment = new Comment
            {
                StoriesId = Storyid,
                Text = text,
                UserId = User.Identity.GetUserId()
            };
            await commentService.CreateComment(comment);
            var allComment = commentService.GetCommentByIdStory(Storyid);
            
            return PartialView(allComment);
        }

    }
}
