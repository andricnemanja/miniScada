using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ModbusServiceLibrary;

namespace ModbusServiceHost
{
	internal class Program
	{
		static void Main(string[] args)
		{
			ServiceHost selfHost = new ServiceHost(typeof(ModbusService));

			selfHost.Open();

			string listenUri = selfHost.Description.Endpoints[0].ListenUri.AbsoluteUri;
			Console.WriteLine("Modbus service listening on: {0}", listenUri);
			Console.WriteLine("Press <Enter> to terminate the service");
			Console.ReadLine();
		}
	}
}
