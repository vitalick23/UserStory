using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using MyUserStory.BLL.Interfaces.Queue;


namespace MyUserStory.BLL.Queue
{
    public class QueueStoryRead: IQueueStoryRead
    {
        public QueueStoryRead()
        {
            StorageAccount = CloudStorageAccount.Parse(
    CloudConfigurationManager.GetSetting("StorageConnectionString"));
            QueueClient = StorageAccount.CreateCloudQueueClient();
            Queue = QueueClient.GetQueueReference("myqueue");
        }
        public CloudStorageAccount StorageAccount { get; }

        public CloudQueueClient QueueClient { get; }

        public CloudQueue Queue { get; }

        public void DeleteMessage(CloudQueueMessage cloudQueueMessage)
        {
            //Process the message in less than 30 seconds, and then delete the message
            Queue.DeleteMessage(cloudQueueMessage);
        }

        public CloudQueueMessage GetMessage()
        {
            CloudQueueMessage retrievedMessage = Queue.GetMessage();
            if (retrievedMessage != null)
            {
                return retrievedMessage;
            }
            return null;
        }
    }
}
