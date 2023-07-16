using System;
using System.ServiceModel;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Wcf;
using ModbusServiceLibrary;

namespace ModbusServiceHost
{
	internal class Program
	{
		static void Main(string[] args)
		{
			IContainer container = Bootstrapper.RegisterContainerBuilder().Build();

			var modbusService = container.Resolve<IModbusDuplex>();
			ServiceHost selfHost = new ServiceHost(modbusService);
			selfHost.AddDependencyInjectionBehavior<IModbusDuplex>(container);

			IComponentRegistration registration;
			if (!container.ComponentRegistry.TryGetRegistration(new TypedService(typeof(IModbusDuplex)), out registration))
			{
				Console.WriteLine("The service contract has not been registered in the container.");
				Console.ReadLine();
				Environment.Exit(-1);
			}

			selfHost.Open();

			string listenUri = selfHost.Description.Endpoints[0].ListenUri.AbsoluteUri;
			Console.WriteLine("Modbus service listening on: {0}", listenUri);
			Console.WriteLine("Press <Enter> to terminate the service");
			Console.ReadLine();
		}
	}
}
