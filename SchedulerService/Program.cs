using System;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using SchedulerService.CronExpressionMapper;
using SchedulerService.ModbusServiceReference;
using SchedulerService.ModelServiceReference;
using SchedulerService.Period_Mapper;
using SchedulerService.PeriodicalScan;
using SchedulerService.PeriodicalScan.RtuScan;
using SchedulerService.PeriodicalScan.SignalTypeScan;
using SchedulerService.RtuConfiguration;
using IContainer = Autofac.IContainer;

namespace SchedulerService
{
	public static class Program
	{
		private static IContainer CompositionRoot()
		{
			var builder = new ContainerBuilder();

			builder.RegisterType<SchedulerService>();
			builder.RegisterType<ModelServiceClient>().As<IModelService>();
			builder.RegisterType<SchedulerRtuConfiguration>().As<ISchedulerRtuConfiguration>().OnActivated(r => r.Instance.InitializeData());

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
	{
		private ISchedulerRtuConfiguration rtuConfiguration;
		private IModelService modelService;
		private IModbusDuplex modbus;

		public IPeriodMapper periodMapper;
		public PeriodicalScan.IScheduler scheduler;

		public ISchedulerCronExpressionMapper cronExpressionMapper;

		public SchedulerService(ISchedulerRtuConfiguration rtuConfiguration, IModelService modelService)
		{
			this.rtuConfiguration = rtuConfiguration;
			this.rtuConfiguration.InitializeData();
			this.modelService = modelService;

			periodMapper = new PeriodMapper(modelService);
			scheduler = new Scheduler();

			cronExpressionMapper = new SchedulerCronExpressionMapper(modelService);

			ModbusServiceCallback modbusServiceCallback = new ModbusServiceCallback();
			InstanceContext instanceContext = new InstanceContext(modbusServiceCallback);
			modbus = new ModbusDuplexClient(instanceContext);

			CancellationToken cancellationToken = new CancellationToken();

			Task.Run(() => Run());

			Console.ReadKey();
		}

		public async void Run()
		{
			scheduler.RegisterPeriodicalScanJob<AnalogInputPeriodicalScanJob>(periodMapper.FindTimeSpanForSignal(1), rtuConfiguration, modbus);
			scheduler.RegisterPeriodicalScanJob<AnalogOutputPeriodicalScanJob>(periodMapper.FindTimeSpanForSignal(2), rtuConfiguration, modbus);
			scheduler.RegisterPeriodicalScanJob<DiscreteInputPeriodicalScanJob>(periodMapper.FindTimeSpanForSignal(3), rtuConfiguration, modbus);
			scheduler.RegisterPeriodicalScanJob<DiscreteOutputPeriodicalScanJob>(periodMapper.FindTimeSpanForSignal(4), rtuConfiguration, modbus);

			//scheduler.RegisterCronJob<RtuScanJob>("abc", rtuConfiguration, modbus, 1);

			//while (!cancellationToken.IsCancellationRequested)
			//{
			//	await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
			//}
		}
	}
}