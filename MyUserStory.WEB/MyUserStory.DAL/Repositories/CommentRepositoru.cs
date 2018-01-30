using System.Data.Entity;
using MyUserStory.BLL.Entities;
using MyUserStory.BLL.Interfaces.InterfaceRepository;

namespace MyUserStory.DAL.Repositories
{
    public class CommentRepositoru : ICommentRepositoru
    {
        private readonly DbSet<Comment> _dataBase;
        public CommentRepositoru(DbSet<Comment> database)
        {
            _dataBase = database;
        }
        public void CreateComment(Comment item)
        {
            _dataBase.Add(item);
        }
    }
}
