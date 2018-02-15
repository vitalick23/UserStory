using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace MyUserStory.BLL.Interfaces.Queue
{
    public interface IQueue
    {
         CloudStorageAccount StorageAccount { get; }
         CloudQueueClient QueueClient { get; }
        CloudQueue Queue { get; }
    }
}
