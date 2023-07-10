<<<<<<< Updated upstream
﻿using SchedulerService.ModbusServiceReference;
=======
﻿using System;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using SchedulerService.ModbusServiceReference;
>>>>>>> Stashed changes
using SchedulerService.ModelServiceReference;
using SchedulerService.Period_Mapper;
using SchedulerService.PeriodicalScan;
using SchedulerService.RtuConfiguration;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SchedulerService
{
<<<<<<< Updated upstream
	class Program
=======
	public static class Program
	{
		private static IContainer CompositionRoot()
		{
			var builder = new ContainerBuilder();

			builder.RegisterType<SchedulerService>();
			builder.RegisterType<ModelServiceClient>().As<IModelService>();
			builder.RegisterType<SchedulerRtuConfiguration>().As<ISchedulerRtuConfiguration>().OnActivated(r => r.Instance.InitializeData());
			//builder.RegisterType<ModbusDuplexClient>().As<IModbusDuplex>();

			return builder.Build();
		}


		public static void Main()
		{
			var container = CompositionRoot();
			var application = container.Resolve<SchedulerService>();

			application.Run();
		}
	}

	public class SchedulerService
>>>>>>> Stashed changes
	{
		private ISchedulerRtuConfiguration rtuConfiguration;
		private IModelService modelService;
		private IModbusDuplex modbus;

		public IPeriodMapper periodMapper;
		public IScheduler scheduler;


		static void Main(string[] args)
		{
			CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
			Console.WriteLine("Press ENTER to terminate the application...");
			Task backgroundTask = Task.Run(() => DoWork(cancellationTokenSource.Token)).ContinueWith(_ => Console.WriteLine("Operation cancelled."), TaskContinuationOptions.OnlyOnCanceled);


			Console.ReadLine();

			cancellationTokenSource.Cancel();
			backgroundTask.Wait();

			Console.WriteLine("Background task has stopped.");
		}

		static async Task DoWork(CancellationToken token)
		{

<<<<<<< Updated upstream
=======
			scheduler.RegisterCronJob<RtuScanJob>("abc", rtuConfiguration, modbus, 1);

			Console.ReadKey();

			//while (!cancellationToken.IsCancellationRequested)
			//{
			//	await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
			//}
>>>>>>> Stashed changes
		}
	}
}


