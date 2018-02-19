using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using MyUserStory.BLL.Entities;
using MyUserStory.BLL.Interfaces.InterfaceService;
using MyUserStory.WEB.Models.Request;
using MyUserStory.WEB.Models.Response;

namespace MyUserStory.WEB.Controllers
{
    public class CommentController : ApiController
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        
        [HttpGet]
        public Task<List<CommentModelResponce>> GetAll()
        {
            return null;
        }

        [HttpGet]
        // GET: api/Comment/5
        public async Task<List<CommentModelResponce>> GetByStoryId(string id)
        {
            var commentList = await _commentService.GetCommentByIdStory(id);
            var result = new List<CommentModelResponce>();
            foreach (var item in commentList)
            {
                result.Add((CommentModelResponce)item);
            }
            return result;
        }

        // POST: api/Comment
        public async Task<CommentModelResponce> Post([FromBody]CommentModelRequest value)
        {         
            var comment = (Comment) value;
            await _commentService.CreateComment(comment);
            return ((CommentModelResponce) comment);

        }

        // PUT: api/Comment/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Comment/5
        public void Delete(int id)
        {
        }
    }
}
