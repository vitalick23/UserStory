using System.Data.Entity;
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using UserStore.BLL.Entities;
using UserStore.BLL.Interfaces;
using UserStore.BLL.Interfaces.InterfaceFinder;
using UserStore.BLL.Interfaces.InterfaceRepositoru;
using UserStore.BLL.Services;
using UserStore.DAL.EF;
using UserStore.DAL.Finder;
using UserStore.DAL.Identity;
using UserStore.DAL.Repositories;

namespace UserStore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();
            IContainer container = null;
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<IdentityUnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<ApplicationContext>().InstancePerLifetimeScope();
            builder.RegisterType<UserManager<User>>();
            builder.RegisterType<UserStore<User>>();
            builder.RegisterType<UserManager<User>>();
            builder.RegisterType<UserRepository>();
            builder.RegisterType<DAL.Identity.UserManager>().As<IUserManager>();
            builder.RegisterType<UserRepository>().As<IUserRepositoru>();
            builder.RegisterType<UserFinder>().As<IUserFinder>();
            builder.Register<IUserFinder>(x => new UserFinder(x.Resolve<ApplicationContext>().Users));
            builder.RegisterType<CommentRepositoru>().As<ICommentRepositoru>();
            builder.RegisterType<CommentFinder>().As<ICommentFinder>();
            builder.Register<ICommentFinder>(x => new CommentFinder(x.Resolve<ApplicationContext>().Comments));
            builder.Register<ICommentRepositoru>(x => new CommentRepositoru(x.Resolve<ApplicationContext>().Comments));
            builder.Register<IUserStore<User>>(x=>new UserStore<User>(x.Resolve<ApplicationContext>()));
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<AuthenticationManager>().As<IAuthenticationManager>();
            builder.RegisterType<StoryService>().As<IStorySevice>();
            builder.RegisterType<StoryManager>().As<IStoryManager>();
            builder.RegisterType<CommentService>().As<ICommentService>();
            builder.RegisterType<CommentManager>().As<ICommentManager>();
            container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
