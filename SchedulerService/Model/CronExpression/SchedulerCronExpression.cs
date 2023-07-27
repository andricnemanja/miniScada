using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerService.Model.CronExpression
{
	public class SchedulerCronExpression
	{
		/// <summary>
		/// Identification number of a cron expression mapping.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Name of the CronExpressionMapping.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Field that represents start date of the scheduled job.
		/// </summary>
		public DateTime Start { get; set; }

		/// <summary>
		/// Input adapted for Quartz.NET Scheduler trigger.
		/// </summary>
		public string CronExpressionScheduler { get; set; }

		/// <summary>
		/// Field that represents end date of the scheduled job.
		/// </summary>
		public DateTime End { get; set; }

	}
}
