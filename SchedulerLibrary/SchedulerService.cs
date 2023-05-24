using SchedulerLibrary.ModbusServiceReference;
using SchedulerLibrary.ModelServiceReference;
using SchedulerLibrary.Period_Mapper;
using SchedulerLibrary.PeriodicalScan.SignalTypeScan;
using SchedulerLibrary.RtuConfiguration;
using System;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;

namespace SchedulerLibrary
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
	public class SchedulerService : ISchedulerService
	{
		private ISchedulerRtuConfiguration rtuConfiguration;
		private IModelService modelService;
		private IModbusDuplex modbus;

		public IPeriodMapper periodMapper;
		public IScheduler scheduler;

		public SchedulerService(ISchedulerRtuConfiguration rtuConfiguration, IModelService modelService)
		{
			this.rtuConfiguration = rtuConfiguration;
			this.modelService = modelService;

			Callback modbusServiceCallback = new Callback();
			InstanceContext instanceContext = new InstanceContext(modbusServiceCallback);
			modbus = new ModbusDuplexClient(instanceContext);

			periodMapper = new PeriodMapper(modelService);
			scheduler = new Scheduler();
			CancellationToken stoppingToken = new CancellationToken();

			Task.Run(() => DoWork(stoppingToken));
		}

		private async void DoWork(CancellationToken stoppingToken)
		{
			scheduler.RegisterPeriodicalScanJob<AnalogInputPeriodicalScanJob>(periodMapper.FindTimeSpanForSignal(1), rtuConfiguration, modbus);
			scheduler.RegisterPeriodicalScanJob<AnalogOutputPeriodicalScanJob>(periodMapper.FindTimeSpanForSignal(2), rtuConfiguration, modbus);
			scheduler.RegisterPeriodicalScanJob<DiscreteInputPeriodicalScanJob>(periodMapper.FindTimeSpanForSignal(3), rtuConfiguration, modbus);
			scheduler.RegisterPeriodicalScanJob<DiscreteOutputPeriodicalScanJob>(periodMapper.FindTimeSpanForSignal(4), rtuConfiguration, modbus);

			while (!stoppingToken.IsCancellationRequested)
			{
				await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
			}
		}

		public int UselessMethod()
		{
			throw new NotImplementedException();
		}
	}
}
