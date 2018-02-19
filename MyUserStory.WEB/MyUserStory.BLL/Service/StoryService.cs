using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using MyUserStory.BLL.Entities;
using MyUserStory.BLL.Interfaces.InterfaceFinder;
using MyUserStory.BLL.Interfaces.InterfaceRepository;
using MyUserStory.BLL.Interfaces.InterfaceService;

namespace MyUserStory.BLL.Service
{
    public class StoryService : IStorySevice
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStoryFinder _storyFinder;
        private readonly IStoryRepository _storyRepository;
        private readonly IUserFinder _userFinder;

        public StoryService(IUnitOfWork uow, 
                        IStoryRepository storyRepository,
                        IStoryFinder storyFinder,
                        IUserFinder userFinder)
        {
            _storyFinder = storyFinder;
            _storyRepository = storyRepository;
            _userFinder = userFinder;
            _unitOfWork = uow;

        }

        public async Task Create(Story item)
        {               
                        item.TimePublicate = DateTime.Now;
               _storyRepository.Create(item);
                await _unitOfWork.SaveAsync();
        }

        public async Task<List<Story>> GetStories()
        {
            return  _storyFinder.GetStories();
        }

        public Task<Story> GetStory(string idStory)
        {
            return  _storyFinder.GetStory(idStory);
        }

        public async Task<List<Story>> GetStoriesByUserName(string id)
        {
            if (String.IsNullOrWhiteSpace(id)) return null;
            if (_userFinder.FindById(id) == null) return null;
            return _storyFinder.GetStoriesByUserId(id);
        }

        public async Task Remove(Story item)
        {
            
            _storyRepository.Remove(item);
            await _unitOfWork.SaveAsync();
        }

        public async Task Update(Story item)
        {
            _storyRepository.Update(item);
            await _unitOfWork.SaveAsync();
        }
    }
}
