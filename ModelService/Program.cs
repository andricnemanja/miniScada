using Autofac;
using Autofac.Core;
using Autofac.Integration.Wcf;
using ModelWcfServiceLibrary;
using System;
using System.ServiceModel;

namespace ModelServiceHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IContainer container = Bootstrapper.RegisterContainerBuilder().Build();

            ServiceHost selfHost = new ServiceHost(typeof(ModelService));
            selfHost.AddDependencyInjectionBehavior<IModelService>(container);

            IComponentRegistration registration;
            if (!container.ComponentRegistry.TryGetRegistration(new TypedService(typeof(IModelService)), out registration))
            {
                Console.WriteLine("The service contract has not been registered in the container.");
                Console.ReadLine();
                Environment.Exit(-1);
            }


            selfHost.Open();

            string listenUri = selfHost.Description.Endpoints[0].ListenUri.AbsoluteUri;
            Console.WriteLine("Listening on: {0}", listenUri);
            Console.WriteLine("Press <Enter> to terminate the service");
            Console.ReadLine();


        }
    }
}
