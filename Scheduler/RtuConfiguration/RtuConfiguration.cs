using ModelWcfServiceLibrary;
using Scheduler.Model.RTU;
using Scheduler.Model.Signals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.RtuConfiguration
{
	public sealed class RtuConfiguration : IRtuConfiguration
	{
		private readonly IModelService modelService;
		/// <summary>
		/// List of RTUs.
		/// </summary>
		private List<RTU> RtuList;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="modelService"></param>
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
		/// Reads all RTU data from the Model Service.
		/// </summary>
		/// <returns>List of RTUs.</returns>
		public List<RTU> ReadAllRTUs()
		{
			List<RTU> rtulist = new List<RTU>();

			foreach (var rtu in modelService.GetAllRTUs())
			{
				RTU newRTU = new RTU(rtu);
				rtulist.Add(newRTU);
			}

			return rtulist;
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
