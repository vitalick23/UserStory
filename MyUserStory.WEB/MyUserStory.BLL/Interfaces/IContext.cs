using System.Data.Entity;
using MyUserStory.BLL.Entities;

namespace MyUserStory.BLL.Interfaces
{
    public interface IContext
    {
        IDbSet<User> Users { get; set; }

    }
}
