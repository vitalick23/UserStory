using System.Collections.Generic;
using UserStore.BLL.Entities;

namespace UserStore.BLL.Interfaces
{
    public interface IStoryManager
    {
        void Create(Story item);

        List<Story> GetStories();

        List<Story> GetStoriesByUserName(string userName);

        Story GetStories(int idStory);
    }
}
