using SchedulerLibrary.Model.SignalPeriod;
using SchedulerLibrary.ModelServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerLibrary.Period_Mapper
{
	/// <summary>
	/// Holds information mapped from <see cref="ModelServiceReference"/>
	/// </summary>
	public class PeriodMapper
	{
		private readonly IModelService modelService;

		/// <summary>
		/// List of periods from every type of signal.
		/// </summary>
		public List<SignalPeriod> signalPeriods = new List<SignalPeriod>();

		public PeriodMapper(IModelService modelService, List<SignalPeriod> signalPeriods)
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

			foreach (var mapping in modelService.GetPeriodMapping)
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
	}
}
