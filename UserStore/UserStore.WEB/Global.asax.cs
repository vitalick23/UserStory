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
using UserStore.BLL.Services;
using UserStore.DAL.EF;
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
            builder.RegisterType<UserManager<ApplicationUser>>();
            builder.RegisterType<UserStore<ApplicationUser>>();
            builder.RegisterType<UserManager<ApplicationUser>>();
            builder.RegisterType<DAL.Identity.UserManager>().As<IUserManager>();
            builder.Register<IUserStore<ApplicationUser>>(x=>new UserStore<ApplicationUser>(x.Resolve<ApplicationContext>()));
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<StoryService>().As<IStorySevice>();
            builder.RegisterType<StoryManager>().As<IStoryManager>();
            container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
