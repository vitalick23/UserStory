using System;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Security;
using MyUserStory.BLL.Entities;
using MyUserStory.BLL.Interfaces;
using MyUserStory.BLL.Interfaces.InterfaceFinder;
using MyUserStory.BLL.Interfaces.InterfaceRepository;
using MyUserStory.BLL.Interfaces.InterfaceService;
using MyUserStory.BLL.Interfaces.Queue;
using MyUserStory.BLL.Queue;
using MyUserStory.BLL.Service;
using MyUserStory.DAL.EF;
using MyUserStory.DAL.Finder;
using MyUserStory.DAL.Repositories;
using MyUserStory.WEB.Controllers;
using AuthenticationManager = MyUserStory.DAL.AuthenticationManager;

namespace MyUserStory.WEB
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            Context.Response.AppendHeader("Access-Control-Allow-Credentials", "true");
            var referrer = Request.UrlReferrer;
            if (Context.Request.Path.Contains("signalr/") && referrer != null)
            {
                Context.Response.AppendHeader("Access-Control-Allow-Origin", referrer.Scheme + "://" + referrer.Authority);
            }
        }

        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers( Assembly.GetExecutingAssembly());
            builder.RegisterType<StoryController>().InstancePerRequest();
            builder.RegisterType<CommentController>().InstancePerRequest();


            builder.RegisterControllers(typeof(MvcApplication).Assembly);
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
            builder.Register((x)=>HttpContext.Current.GetOwinContext().Authentication);
            builder.RegisterType<AuthenticationManager>().As<BLL.Interfaces.IAuthenticationManager>();

                       var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

          
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            

        }
    }
}
