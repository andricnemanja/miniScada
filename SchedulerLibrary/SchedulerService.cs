using Quartz;
using SchedulerLibrary.ModelServiceReference;
using SchedulerLibrary.Period_Mapper;
using SchedulerLibrary.PeriodicalScan.SignalTypeScan;
using SchedulerLibrary.RtuConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchedulerLibrary
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
	public class SchedulerService : ISchedulerService
	{
		private IRtuConfiguration rtuConfiguration;
		private IModelService modelService;

		public SchedulerService(IRtuConfiguration rtuConfiguration, IModelService modelService)
		{
			this.rtuConfiguration = rtuConfiguration;
			this.modelService = modelService;

			IPeriodMapper periodMapper = new PeriodMapper(modelService);


			Scheduler scheduler = new Scheduler();
			scheduler.RegisterSchedulerJob<AnalogInputPeriodicalScanJob>(periodMapper.FindTimeSpanForSignal(1), rtuConfiguration);
			scheduler.RegisterSchedulerJob<AnalogOutputPeriodicalScanJob>(periodMapper.FindTimeSpanForSignal(2), rtuConfiguration);
			scheduler.RegisterSchedulerJob<DiscreteInputPeriodicalScanJob>(periodMapper.FindTimeSpanForSignal(3), rtuConfiguration);
			scheduler.RegisterSchedulerJob<DiscreteOutputPeriodicalScanJob>(periodMapper.FindTimeSpanForSignal(4), rtuConfiguration);
		}


		public int UselessMethod()
		{
			return 0;
		}
	}
}
