using Scheduler.PointTypeScan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Scheduler
{
	public class SchedulerService : ISchedulerService
	{
		//prijavi se na scheduler u njemu se dobavlja callback(kao u modbus service-u i pomocu tog callback-a saljem komande
		public SchedulerService()
		{
			var scheduler = new Scheduler.PointTypeScan.Scheduler(10);
			scheduler.StartScheduler();
		}
	}
}
