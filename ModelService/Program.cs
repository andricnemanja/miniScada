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
            //// Step 1: Create a URI to serve as the base address.
            //Uri baseAddress = new Uri("http://localhost:8000/GettingStarted/");

            //// Step 2: Create a ServiceHost instance.
            //ServiceHost selfHost = new ServiceHost(typeof(ModelService), baseAddress);

            //try
            //{
            //    // Step 3: Add a service endpoint.
            //    selfHost.AddServiceEndpoint(typeof(IModelService), new NetTcpBinding(), "ModelService");

            //    // Step 4: Enable metadata exchange.
            //    ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            //    smb.HttpGetEnabled = true;
            //    selfHost.Description.Behaviors.Add(smb);

            //    // Step 5: Start the service.
            //    selfHost.Open();
            //    Console.WriteLine("The service is ready.");

            //    // Close the ServiceHost to stop the service.
            //    Console.WriteLine("Press <Enter> to terminate the service.");
            //    Console.WriteLine();
            //    Console.ReadLine();
            //    selfHost.Close();
            //}
            //catch (CommunicationException ce)
            //{
            //    Console.WriteLine("An exception occurred: {0}", ce.Message);
            //    selfHost.Abort();
            //}

            Uri tcpUri = new Uri("net.tcp://localhost:65001/GettingStarted");

            // Create the ServiceHost
            ServiceHost selfHost = new ServiceHost(typeof(ModelService), tcpUri);

            // Create a binding that uses TCP and set the security mode to none.
            NetTcpBinding binding = new NetTcpBinding();
            binding.Security.Mode = SecurityMode.None;

            // Add an endpoint to the service.
            selfHost.Description.Endpoints.Clear();
            selfHost.AddServiceEndpoint(typeof(IModelService), binding, "ModelService");

            // Step 4: Enable metadata exchange.
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            selfHost.Description.Behaviors.Add(smb);

            // Open the service and wait for calls
            selfHost.Open();

            string listenUri = selfHost.Description.Endpoints[0].ListenUri.AbsoluteUri;
            Console.WriteLine("Listening on: {0}", listenUri);
            Console.WriteLine("Press <Enter> to terminate the service");
            Console.ReadLine();
            

        }
    }
}
