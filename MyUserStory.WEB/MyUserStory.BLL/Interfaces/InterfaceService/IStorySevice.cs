using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using MyUserStory.BLL.Entities;

namespace MyUserStory.BLL.Interfaces.InterfaceService
{
    public interface IStorySevice 
    {
        Task Create(Story item);

        Task<List<Story>> GetStories();

        Task<List<Story>> GetStoriesByUserName(string email);

        Task<Story> GetStory(string idStory);

        Task Remove(Story item);

        Task Update(Story item);
    }
}
