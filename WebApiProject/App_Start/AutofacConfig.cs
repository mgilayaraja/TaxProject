using System;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using Autofac.Integration.Mvc;
using System.Web.Mvc;

namespace WebApiProject
{
    public class AutofacConfig
    {
        public static IContainer container;

        public static void Initialize(HttpConfiguration config)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder = TaxProject.Utilities.Bootstrap.RegisterServices(builder);

            //Set the dependency resolver to be Autofac.  
            container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}