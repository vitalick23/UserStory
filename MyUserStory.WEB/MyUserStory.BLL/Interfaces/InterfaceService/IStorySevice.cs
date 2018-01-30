using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using MyUserStory.BLL.Entities;

namespace MyUserStory.BLL.Interfaces.InterfaceService
{
    public interface IStorySevice 
    {
        Task<IdentityResult> Create(Story item);

        List<Story> GetStories();

        List<Story> GetStoriesByUserName(string email);

        Story GetStories(int idStory);
    }
}
