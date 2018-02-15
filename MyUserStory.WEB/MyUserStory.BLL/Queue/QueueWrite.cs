using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using MyUserStory.BLL.Entities;
using MyUserStory.BLL.Interfaces.Queue;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUserStory.BLL.Queue
{
    public class CreateStoryModelRequest
    {
        public string UserId { get; set; }

        public string Theme { get; set; }

        public string Stories { get; set; }

        public static explicit operator Story(CreateStoryModelRequest model)
        {
            var story = new Story
            {
                Stories = model.Stories,
                Theme = model.Theme,
                UserId = model.UserId
            };
            return story;
        }
        public byte[] Serialize()
        {
            using (MemoryStream m = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(m))
                {
                    writer.Write(UserId);
                    writer.Write(Theme);
                    writer.Write(Stories);
                }
                return m.ToArray();
            }
        }

        public static CreateStoryModelRequest Desserialize(byte[] data)
        {
            CreateStoryModelRequest result = new CreateStoryModelRequest();
            using (MemoryStream m = new MemoryStream(data))
            {
                using (BinaryReader reader = new BinaryReader(m))
                {
                    result.UserId = reader.ReadString();
                    result.Theme = reader.ReadString();
                    result.Stories = reader.ReadString();
                }
            }
            return result;
        }
    }
    public class QueueWrite : IQueueWrite
    {
        public QueueWrite()
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
