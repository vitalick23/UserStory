using Microsoft.WindowsAzure.Storage.Queue;
using MyUserStory.BLL.Interfaces.Queue;
using Queue.Interface;

namespace Queue
{

    public class QueueRead : IQueueRead
    {
        private readonly IQueueStoryRead _queueRead;
        public QueueRead(IQueueStoryRead queueRead)
        {
            _queueRead = queueRead;
        }
        public void DeleteMessage(CloudQueueMessage message)
        {
            _queueRead.DeleteMessage(message);
        }

        public CloudQueueMessage GetMessage()
        {
            return _queueRead.GetMessage();
        }
    }
}
