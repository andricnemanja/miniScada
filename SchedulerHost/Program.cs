﻿using Autofac;
using Autofac.Core;
using SchedulerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Autofac.Integration.Wcf;

namespace SchedulerHost
{
	public class Program
	{
		static void Main(string[] args)
		{
			IContainer container = Bootstrapper.RegisterContainerBuilder().Build();

			ISchedulerService schedulerService = container.Resolve<ISchedulerService>();

			ServiceHost selfHost = new ServiceHost(schedulerService);
			selfHost.AddDependencyInjectionBehavior<ISchedulerService>(container);

			IComponentRegistration registration;
			if (!container.ComponentRegistry.TryGetRegistration(new TypedService(typeof(ISchedulerService)), out registration))
			{
				Console.WriteLine("The service contract has not been registered in the container.");
				Console.ReadLine();
				Environment.Exit(-1);
			}

			selfHost.Open();

			string listenUri = selfHost.Description.Endpoints[0].ListenUri.AbsoluteUri;
			Console.WriteLine("Scheduler service listening on: {0}", listenUri);
			Console.WriteLine("Press <Enter> to terminate the service");
			Console.ReadLine();
		}
	}
}
