using Autofac;
using MyUserStory.BLL.Entities;
using MyUserStory.BLL.ModelQueue;
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
                        var storyQueue = StoryQueueModel.Desserialize(message.AsBytes);
                        var story = new Story
                        {
                            Id = storyQueue.Id,
                            Stories = storyQueue.Stories,
                            UserId = storyQueue.UserId,
                            Theme = storyQueue.Theme
                        };
                        var app = scope.Resolve<IApplication>();
                        switch (storyQueue.Method)
                        {
                            case "post":
                                 app.CreateStory(story).Wait();
                                break;
                            case "put":

                                app.UpdateStory(story.Id,story).Wait();
                              //  item.
                                break;
                            case "delete":
                                app.Delete(story).Wait();
                                break;
                            default: break;
                        }

                        queueRead.DeleteMessage(message);
                    }
                }
            }
        }
    }
}
