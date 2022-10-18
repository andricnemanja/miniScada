using Autofac;
using ModelWcfServiceLibrary;
using ModelWcfServiceLibrary.Repository;

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
