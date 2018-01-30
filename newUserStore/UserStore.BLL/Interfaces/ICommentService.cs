using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using UserStore.BLL.Entities;

namespace UserStore.BLL.Interfaces
{
    public interface ICommentService
    {
        Task CreateComment(Comment item);

        Task<List<Comment>> GetCommentByIdStory(int StoryId);
    }
}
