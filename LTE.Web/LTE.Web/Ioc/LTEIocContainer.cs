using Autofac;
using Autofac.Integration.Mvc;
using LTE.Data;
using LTE.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTE.Core;
using LTE.Core.Interface;
namespace LTE.Web.Ioc
{
    public class LTEIocContainer
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            // controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // dependencies
            builder.RegisterType<LTEDbContext>().As<IDbContext>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            
            // set dependency resolver
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}