using SchedulerService.Model.SignalPeriod;
using SchedulerService.ModelServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchedulerService.Period_Mapper
{
	/// <summary>
	/// Holds information mapped from <see cref="ModelServiceReference"/>
	/// </summary>
	public class PeriodMapper : IPeriodMapper
	{
		private readonly IModelService modelService;

		/// <summary>
		/// List of periods from every type of signal.
		/// </summary>
		public List<SignalPeriod> signalPeriods = new List<SignalPeriod>();

		public PeriodMapper(IModelService modelService)
		{
			this.modelService = modelService;
			this.signalPeriods = ReadPeriodMapping();
		}

		/// <summary>
		/// Reads period mapping from <see cref="ModelService"/>
		/// </summary>
		/// <returns></returns>
		public List<SignalPeriod> ReadPeriodMapping()
		{
			List<SignalPeriod> periods = new List<SignalPeriod>();

			foreach (var mapping in modelService.GetSignalScanPeriodMappings())
			{
				SignalPeriod newPeriod = new SignalPeriod()
				{
					Id = mapping.Id,
					Name = mapping.Name,
					TimeStamp = mapping.TimeStamp
				};

				periods.Add(newPeriod);
			}

			return periods;
		}

		/// <summary>
		/// Finds period for certain signal type.
		/// </summary>
		/// <param name="mappingId">Id of mapping.</param>
		/// <returns>Signal period.</returns>
		public SignalPeriod FindSignalPeriod(int mappingId)
		{
			return signalPeriods.SingleOrDefault(m => m.Id == mappingId);
		}

		public TimeSpan FindTimeSpanForSignal(int mappingId)
		{
			return FindSignalPeriod(mappingId).TimeStamp;
		}
	}
}
