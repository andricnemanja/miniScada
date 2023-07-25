using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelWcfServiceLibrary.Model.CronExpressionMappings
{
	public class ModelCronExpressionMapping
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
		/// Field that represents type of recurrence of the cron job.
		/// </summary>
		public ModelCronExpressionRecurrenceType RecurrenceType { get; set; }

		/// <summary>
		/// Field that represents period of recurrence of the cron job.
		/// </summary>
		public int RecurrencePeriod { get; set; }

		/// <summary>
		/// Field that represents end date of the scheduled job.
		/// </summary>
		public DateTime End { get; set; }
	}
}
