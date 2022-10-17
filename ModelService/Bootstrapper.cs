using Autofac;
using ModelWcfServiceLibrary;
using ModelWcfServiceLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelServiceHost
{
    public class Bootstrapper
    {
        public static ContainerBuilder RegisterContainerBuilder()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.Register(c => new JsonRtuRepository()).As<IRtuRepository>();
            builder.Register(c => new ModelService(c.Resolve<IRtuRepository>())).As<IModelService>();

            return builder;
        }
    }
}
