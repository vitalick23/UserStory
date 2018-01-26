using System.Data.Entity;
using UserStore.BLL.Entities;
using UserStore.BLL.Interfaces.InterfaceRepositoru;

namespace UserStore.DAL.Repositories
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
