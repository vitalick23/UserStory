using MyUserStory.BLL.Entities;
using System.IO;

namespace Queue.Model
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
}
