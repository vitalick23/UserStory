using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using UserStore.BLL.Entities;

namespace UserStore.BLL.Interfaces
{
    public interface IStorySevice 
    {
        Task<IdentityResult> Create(Story item);

        List<Story> GetStories();

        List<Story> GetStoriesByUserName(string email);

        Story GetStories(int idStory);
    }
}
