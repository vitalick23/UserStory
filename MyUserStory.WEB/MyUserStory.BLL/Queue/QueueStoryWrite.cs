using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using MyUserStory.BLL.Interfaces.Queue;
using System.Threading.Tasks;

namespace MyUserStory.BLL.Queue
{

    public class QueueStoryWrite : IQueueStoryWrite
    {
        public QueueStoryWrite()
        {
            StorageAccount = CloudStorageAccount.Parse(
            CloudConfigurationManager.GetSetting("StorageConnectionString"));
            QueueClient = StorageAccount.CreateCloudQueueClient();
            Queue = QueueClient.GetQueueReference("myqueue");
            CreateQueue();
        }
        public CloudStorageAccount StorageAccount { get; }

        public CloudQueueClient QueueClient { get; }

        public CloudQueue Queue { get; }

        public async Task AddMessage(byte[] content)
        {
            CloudQueueMessage message = new CloudQueueMessage(content);
            await Queue.AddMessageAsync(message);
            
        }

        public void CreateQueue()
        {
            Queue.CreateIfNotExists();
        }
    }
}
