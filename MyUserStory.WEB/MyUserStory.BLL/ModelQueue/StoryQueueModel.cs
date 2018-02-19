using MyUserStory.BLL.Entities;
using System;
using System.IO;

namespace MyUserStory.BLL.ModelQueue
{
    public class StoryQueueModel
    {
        public string Method { get; set; }
        public string Id { get; set; }
        public string UserId { get; set; }

        public string Theme { get; set; }

        public string Stories { get; set; }

        public static explicit operator Story(StoryQueueModel model)
        {
            var story = new Story
            {
                Id = model.Id,
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
                    writer.Write(Method);
                    writer.Write(Id);
                    writer.Write(UserId);
                    writer.Write(Theme);
                    writer.Write(Stories);
                }
                return m.ToArray();
            }
        }

        public static StoryQueueModel Desserialize(byte[] data)
        {
            var result = new StoryQueueModel();
            using (MemoryStream m = new MemoryStream(data))
            {
                using (BinaryReader reader = new BinaryReader(m))
                {
                    result.Method = reader.ReadString();
                    result.Id = reader.ReadString();
                    result.UserId = reader.ReadString();
                    result.Theme = reader.ReadString();
                    result.Stories = reader.ReadString();
                }
            }
            return result;
        }
    }
}
