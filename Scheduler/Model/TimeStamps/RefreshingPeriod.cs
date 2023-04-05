﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Model.TimeStamps
{
	/// <summary>
	/// Class that holds the information about time periods of a scheduler refresh.
	/// </summary>
	public class RefreshingPeriod
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
