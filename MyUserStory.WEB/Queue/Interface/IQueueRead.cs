using Microsoft.WindowsAzure.Storage.Queue;

namespace Queue.Interface
{
    public interface IQueueRead
    {
        CloudQueueMessage GetMessage();
        void DeleteMessage(CloudQueueMessage message);
    }
}
