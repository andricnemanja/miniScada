using Autofac;
using Autofac.Core;
using Autofac.Integration.Wcf;
using ModelWcfServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ModelServiceHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IContainer container = Bootstrapper.RegisterContainerBuilder().Build();

            Uri baseAddress = new Uri("http://localhost:8000/ModbusConnection/");
            ServiceHost selfHost = new ServiceHost(typeof(ModelService), baseAddress);

            try
            {

                selfHost.AddDependencyInjectionBehavior<IModelService>(container);
                selfHost.AddServiceEndpoint(typeof(IModelService), new BasicHttpBinding(), "ModelService");

                // Step 4: Enable metadata exchange.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;


                IComponentRegistration registration;
                if (!container.ComponentRegistry.TryGetRegistration(new TypedService(typeof(IModelService)), out registration))
                {
                    Console.WriteLine("The service contract has not been registered in the container.");
                    Console.ReadLine();
                    Environment.Exit(-1);
                }

                selfHost.Description.Behaviors.Add(smb);
                selfHost.Open();
                Console.WriteLine("The service is ready.");

                Console.WriteLine("Press <Enter> to terminate the service.");
                Console.WriteLine();
                Console.ReadLine();
                selfHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                selfHost.Abort();
            }

            ServiceHost selfHost = new ServiceHost(typeof(ModelService));
            selfHost.Open();

            string listenUri = selfHost.Description.Endpoints[0].ListenUri.AbsoluteUri;
            Console.WriteLine("Listening on: {0}", listenUri);
            Console.WriteLine("Press <Enter> to terminate the service");
            Console.ReadLine();
            

        }
    }
}
