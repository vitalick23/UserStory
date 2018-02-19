using System.Threading.Tasks;
using MyUserStory.BLL.Entities;
using QueueComment.Interface;

namespace QueueComment
{
    public class Application : IApplication
    {
        public Task CreateComment(Comment story)
        {
            throw new System.NotImplementedException();
        }
    }
}
