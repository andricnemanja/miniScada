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

            ServiceHost selfHost = new ServiceHost(typeof(ModelService));
            selfHost.Open();

            string listenUri = selfHost.Description.Endpoints[0].ListenUri.AbsoluteUri;
            Console.WriteLine("Listening on: {0}", listenUri);
            Console.WriteLine("Press <Enter> to terminate the service");
            Console.ReadLine();
            

        }
    }
}
