using System;

namespace SchedulerService.Model.SignalPeriod
{
	/// <summary>
	/// Class that holds the information about time periods of a scheduler refresh.
	/// </summary>
	public class SignalPeriod
	{
		/// <summary>
		/// ID of the period.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Period name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Period in different time intervals.
		/// </summary>
		public TimeSpan TimeStamp { get; set; }
	}
}
