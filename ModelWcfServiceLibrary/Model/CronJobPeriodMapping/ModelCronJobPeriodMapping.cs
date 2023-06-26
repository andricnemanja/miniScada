using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelWcfServiceLibrary.Model.CronJobPeriodMapping
{
	/// <summary>
	/// Class that models period mapping for the Cron Job.
	/// </summary>
	public class ModelCronJobPeriodMapping
	{
		/// <summary>
		/// ID of the period.
		/// </summary>
		public int Id { get; set; }
		
		/// <summary>
		/// Represents seconds of the period.
		/// </summary>
		public string Seconds { get; set; }

		/// <summary>
		/// Represents minutes of the period.
		/// </summary>
		public string Minutes { get; set; }

		/// <summary>
		/// Represents hours of the period.
		/// </summary>
		public string Hours { get; set; }

		/// <summary>
		/// Represents day of the month of the period.
		/// </summary>
		public string DayOfMonth { get; set; }

		/// <summary>
		/// Represents month of the period.
		/// </summary>
		public string Month { get; set; }

		/// <summary>
		/// Represents day of the week of the period.
		/// </summary>
		public string DayOfWeek { get; set; }

		/// <summary>
		/// Represents year of the period.
		/// </summary>
		public string Year { get; set; }

	}
}
