using SchedulerService.ModbusServiceReference;
using SchedulerService.ModelServiceReference;
using SchedulerService.Period_Mapper;
using SchedulerService.PeriodicalScan;
using SchedulerService.RtuConfiguration;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SchedulerService
{
	class Program
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

		}
	}
}


