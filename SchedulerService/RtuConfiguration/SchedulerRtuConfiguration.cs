using SchedulerService.Model.Signals;
using SchedulerService.ModelServiceReference;
using System.Collections.Generic;
using System.Linq;
using SchedulerRTU = SchedulerService.Model.RTU.SchedulerRTU;

namespace SchedulerService.RtuConfiguration
{
	public class SchedulerRtuConfiguration : ISchedulerRtuConfiguration
	{
		private readonly IModelService modelService;

		/// <summary>
		/// List of RTUs.
		/// </summary>
		public List<SchedulerRTU> RtuList { get; private set; }

		/// <summary>
		/// Initializes instance of the class <see cref="SchedulerRtuConfiguration"/.>
		/// </summary>
		/// <param name="modelService">Model service.</param>
		public SchedulerRtuConfiguration(IModelService modelService)
		{
			this.modelService = modelService;
		}

		/// <summary>
		/// Initializes data.
		/// </summary>
		public void InitializeData()
		{
			RtuList = ReadAllRTUs();
		}

		/// <summary>
		/// Reads all RTU data from Model Service.
		/// </summary>
		/// <returns></returns>
		public List<SchedulerRTU> ReadAllRTUs()
		{
			List<SchedulerRTU> rtus = new List<SchedulerRTU>();

			foreach (var rtu in modelService.GetAllRTUs())
			{
				SchedulerRTU newRtu = new SchedulerRTU(rtu);
				rtus.Add(newRtu);
			}

			return rtus;
		}

		/// <summary>
		/// Gets signal by its ID.
		/// </summary>
		/// <param name="rtuId">ID of the RTU.</param>
		/// <param name="signalId">ID of the signal.</param>
		/// <returns></returns>
		public ISchedulerSignal GetSignal(int rtuId, int signalId)
		{
			return FindRtu(rtuId).Signals.SingleOrDefault(s => s.ID == signalId);
		}

		/// <summary>
		/// Finds RTU by its ID.
		/// </summary>
		/// <param name="rtuId">ID of the RTU.</param>
		/// <returns>RTU.</returns>
		private SchedulerRTU FindRtu(int rtuId)
		{
			return RtuList.SingleOrDefault(r => r.ID == rtuId);
		}
	}
}
