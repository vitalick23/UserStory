using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserStore.BLL.Entities;

namespace UserStore.BLL.Interfaces
{
    public interface ICommentManager
    {
        void CreateComment(Comment item);

        List<Comment> GetCommentByIdStory(int StoryId);
    }
}
