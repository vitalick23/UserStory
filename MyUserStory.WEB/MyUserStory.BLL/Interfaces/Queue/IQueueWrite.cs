using System;
using System.Threading.Tasks;

namespace MyUserStory.BLL.Interfaces.Queue
{
    public interface IQueueWrite: IQueue
    {
        void CreateQueue();
        Task AddMessage(byte[] content);

    }
}
