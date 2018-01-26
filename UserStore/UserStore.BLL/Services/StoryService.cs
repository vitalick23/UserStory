using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using UserStore.BLL.Entities;
using UserStore.BLL.Interfaces;
using UserStore.BLL.Interfaces.InterfaceFinder;
using UserStore.BLL.Interfaces.InterfaceRepositoru;

namespace UserStore.BLL.Services
{
    public class StoryService : IStorySevice
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStoryFinder _storyFinder;
        private readonly IStoryRepositoru _storyRepository;
        private readonly IUserFinder _userFinder;

        public StoryService(IUnitOfWork uow, 
                        IStoryRepositoru storyRepository,
                        IStoryFinder storyFinder,
                        IUserFinder userFinder)
        {
            _storyFinder = storyFinder;
            _storyRepository = storyRepository;
            _userFinder = userFinder;
            _unitOfWork = uow;

        }

        public async Task<IdentityResult> Create(Story item)
        {
            if (item != null)
            {
                item.TimePublicate = DateTime.Now;
                try
                {
                    _storyRepository.Create(item);
                    await _unitOfWork.SaveAsync();
                }
                catch (Exception ex)
                {
                    return await Task.FromResult(IdentityResult.Failed(ex.Message));
                }
                return IdentityResult.Success;
            }
            return await Task.FromResult(IdentityResult.Failed("Null Story"));
        }

    public List<Story> GetStories()
        {
            return _storyFinder.GetStories();
        }

        public Story GetStories(int idStory)
        {
            if (idStory < 0) return null;
            return _storyFinder.GetStories(idStory);
        }

        public  List<Story> GetStoriesByUserName(string id)
        {
            if (String.IsNullOrWhiteSpace(id)) return null;
            if (_userFinder.FindById(id) == null) return null;
            return _storyFinder.GetStoriesByUserId(id);
        }
    }
}
