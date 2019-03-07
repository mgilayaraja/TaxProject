using System;
using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace TaxProject.com
{
    public class AutofacConfig
    {
        public static IContainer container;

        public static void Initialize()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder = Utilities.Bootstrap.RegisterServices(builder);

            //Set the dependency resolver to be Autofac.  
            container = builder.Build();

            //config.DependencyResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}