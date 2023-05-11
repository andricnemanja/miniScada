using System;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Threading;
using SchedulerServiceLibrary.RtuConfiguration;
using SchedulerServiceLibrary.ModelServiceReference;
using SchedulerServiceLibrary.ModbusServiceReference;
using SchedulerServiceLibrary.PeriodMapper;
using SchedulerServiceLibrary.PeriodicalScan.SignalTypeScan;

namespace SchedulerServiceLibrary
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
	public class SchedulerService
	{
		private IRtuConfiguration rtuConfiguration;
		private IModelService modelService;
		private IModbusDuplex modbus;

		public IPeriodMapper periodMapper;
		public IScheduler scheduler;

		public SchedulerService(IRtuConfiguration rtuConfiguration, IModelService modelService, IModbusDuplex modbus)
		{
			this.rtuConfiguration = rtuConfiguration;
			this.modelService = modelService;
			this.modbus = modbus;

			periodMapper = new SchedulerServiceLibrary.PeriodMapper.PeriodMapper(modelService);
			scheduler = new Scheduler();
			CancellationToken stoppingToken = new CancellationToken();

			Task.Run(() => DoWork(stoppingToken));
		}

		private async void DoWork(CancellationToken stoppingToken)
		{
			scheduler.RegisterSchedulerJob<AnalogInputPeriodicalScanJob>(periodMapper.FindTimeSpanForSignal(1), rtuConfiguration, modbus);
			scheduler.RegisterSchedulerJob<AnalogOutputPeriodicalScanJob>(periodMapper.FindTimeSpanForSignal(2), rtuConfiguration, modbus);
			scheduler.RegisterSchedulerJob<DiscreteInputPeriodicalScanJob>(periodMapper.FindTimeSpanForSignal(3), rtuConfiguration, modbus);
			scheduler.RegisterSchedulerJob<DiscreteOutputPeriodicalScanJob>(periodMapper.FindTimeSpanForSignal(4), rtuConfiguration, modbus);

			while (!stoppingToken.IsCancellationRequested)
			{
				await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
			}
		}
	}
}
