using Autofac;
using MyUserStory.BLL.Entities;
using Queue.Interface;
using Queue.Model;

namespace Queue
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();
            while(true)
            {
                using (var scope = container.BeginLifetimeScope())
                {
                    var queueRead = scope.Resolve<IQueueRead>();
                    var message = queueRead.GetMessage();
                    if (message != null)
                    {
                        var s = CreateStoryModelRequest.Desserialize(message.AsBytes);
                        var story = new Story
                        {
                            Stories = s.Stories,
                            UserId = s.UserId,
                            Theme = s.Theme
                        };

                        var app = scope.Resolve<IApplication>();
                        app.CreateStory(story);

                        queueRead.DeleteMessage(message);
                    }
                }
            }
        }
    }
}
