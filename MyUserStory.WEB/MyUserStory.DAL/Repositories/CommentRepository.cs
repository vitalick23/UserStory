using System.Data.Entity;
using MyUserStory.BLL.Entities;
using MyUserStory.BLL.Interfaces.InterfaceRepository;

namespace MyUserStory.DAL.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DbSet<Comment> _dataBase;
        public CommentRepository(DbSet<Comment> database)
        {
            _dataBase = database;
        }
        public void CreateComment(Comment item)
        {
            _dataBase.Add(item);
        }
    }
}
