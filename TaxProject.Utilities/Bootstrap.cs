using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using TaxProject.Core.IRepository;
using TaxProject.Core.IService;
using TaxProject.Repository;
using TaxProject.Service;

namespace TaxProject.Utilities
{
    public class Bootstrap
    {
        public static ContainerBuilder RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>().InstancePerRequest();

            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();

            return builder;
        }
    }
}
