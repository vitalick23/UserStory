using Autofac;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyUserStory.BLL.Entities;
using MyUserStory.BLL.Interfaces.InterfaceFinder;
using MyUserStory.BLL.Interfaces.InterfaceRepository;
using MyUserStory.BLL.Interfaces.InterfaceService;
using MyUserStory.BLL.Interfaces.Queue;
using MyUserStory.BLL.Queue;
using MyUserStory.BLL.Service;
using MyUserStory.DAL.EF;
using MyUserStory.DAL.Finder;
using MyUserStory.DAL.Repositories;
using Queue.Interface;

namespace Queue
{
    public static class ContainerConfig
    {
        public static Autofac.IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<IdentityUnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<ApplicationContext>().InstancePerLifetimeScope();
            builder.RegisterType<UserStore<User>>();
            builder.RegisterType<UserManager<User>>();
            builder.RegisterType<UserRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<UserFinder>().As<IUserFinder>();

            builder.RegisterType<QueueStoryWrite>().As<IQueueStoryWrite>();
            builder.RegisterType<CommentService>().As<ICommentService>();
            builder.RegisterType<CommentRepository>().As<ICommentRepository>();
            builder.RegisterType<CommentFinder>().As<ICommentFinder>();
            builder.Register<ICommentFinder>(x => new CommentFinder(x.Resolve<ApplicationContext>().Comments));
            builder.Register<ICommentRepository>(x => new CommentRepository(x.Resolve<ApplicationContext>().Comments));

            builder.RegisterType<StoryService>().As<IStorySevice>();
            builder.RegisterType<StoryRepository>().As<IStoryRepository>();
            builder.RegisterType<StoryFinder>().As<IStoryFinder>();
            builder.Register<IStoryFinder>(x => new StoryFinder(x.Resolve<ApplicationContext>().Stories));
            builder.Register<IStoryRepository>(x => new StoryRepository(x.Resolve<ApplicationContext>().Stories));

            builder.Register<IUserFinder>(x => new UserFinder(x.Resolve<ApplicationContext>().Users));
            builder.Register<IUserStore<User>>(x => new UserStore<User>(x.Resolve<ApplicationContext>()));
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<MyUserStory.DAL.AuthenticationManager>().As<MyUserStory.BLL.Interfaces.IAuthenticationManager>();
            builder.RegisterType<QueueStoryRead>().As<IQueueStoryRead>();
            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<QueueRead>().As<IQueueRead>();
            return builder.Build();
        }
    }
   
}

