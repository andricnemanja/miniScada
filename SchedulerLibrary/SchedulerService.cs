using Microsoft.Extensions.Hosting;
using ModbusServiceLibrary;
using SchedulerLibrary.ModelServiceReference;
using SchedulerLibrary.Period_Mapper;
using SchedulerLibrary.PeriodicalScan.SignalTypeScan;
using SchedulerLibrary.RtuConfiguration;
using System;
using System.ComponentModel;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;

namespace SchedulerLibrary
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

			periodMapper = new PeriodMapper(modelService);
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
