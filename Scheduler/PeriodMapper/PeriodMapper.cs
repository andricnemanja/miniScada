using ModelWcfServiceLibrary;
using Scheduler.Model.TimeStamps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.PeriodMapper
{
	/// <summary>
	/// Holds information mapped from the Model service.
	/// </summary>
	public class PeriodMapper
	{
		private readonly IModelService modelService;
		
		/// <summary>
		/// List of periods for every type of signal.
		/// </summary>
		public List<SignalPeriod> signalPeriods = new List<SignalPeriod>();

		/// <summary>
		/// Creates new instance of PeriodMapper class.
		/// </summary>
		/// <param name="modelService">Holds information about mappings.</param>
		public PeriodMapper(IModelService modelService)
		{
			this.modelService = modelService;
			signalPeriods = ReadPeriodMapping();
		}

		/// <summary>
		/// Reads the period mappings from the Model service.
		/// </summary>
		/// <returns>List of Signal Periods.</returns>
		private List<SignalPeriod> ReadPeriodMapping()
		{
			List<SignalPeriod> periods = new List<SignalPeriod>();

			foreach(var mapping in modelService.GetPeriodMapping())
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
		/// Finds period for the certain signal type.
		/// </summary>
		/// <param name="mappingId">ID of the mapping.</param>
		/// <returns>Period for the certain type of signal.</returns>
		private SignalPeriod FindSignalPeriod(int mappingId)
		{
			return signalPeriods.SingleOrDefault(m => m.Id == mappingId);
		}
	}
}
