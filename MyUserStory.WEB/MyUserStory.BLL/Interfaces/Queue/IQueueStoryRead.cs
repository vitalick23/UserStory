using Microsoft.WindowsAzure.Storage.Queue;

namespace MyUserStory.BLL.Interfaces.Queue
{
    public interface IQueueStoryRead : IQueue
    {
        CloudQueueMessage GetMessage();

        void DeleteMessage(CloudQueueMessage cloudQueueMessage);
    }
}
