using SchedulerLibrary.Model.Signals;
using SchedulerLibrary.ModelServiceReference;
using System.Collections.Generic;
using System.Linq;
using RTU = SchedulerLibrary.Model.RTU.RTU;

namespace SchedulerLibrary.RtuConfiguration
{
	public class RtuConfiguration : IRtuConfiguration
	{
		private readonly IModelService modelService;

		/// <summary>
		/// List of RTUs.
		/// </summary>
		public List<RTU> RtuList { get; private set; }

		/// <summary>
		/// Initializes instance of the class <see cref="RtuConfiguration"/.>
		/// </summary>
		/// <param name="modelService">Model service.</param>
		public RtuConfiguration(IModelService modelService)
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
		public List<RTU> ReadAllRTUs()
		{
			List<RTU> rtus = new List<RTU>();

			foreach (var rtu in modelService.GetAllRTUs())
			{
				RTU newRtu = new RTU(rtu);
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
		public ISignal GetSignal(int rtuId, int signalId)
		{
			return FindRtu(rtuId).Signals.SingleOrDefault(s => s.ID == signalId);
		}

		/// <summary>
		/// Finds RTU by its ID.
		/// </summary>
		/// <param name="rtuId">ID of the RTU.</param>
		/// <returns>RTU.</returns>
		private RTU FindRtu(int rtuId)
		{
			return RtuList.SingleOrDefault(r => r.ID == rtuId);
		}
	}
}
