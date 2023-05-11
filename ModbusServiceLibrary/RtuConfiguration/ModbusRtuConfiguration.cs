using System;
using System.Collections.Generic;
using System.Linq;
using ModbusServiceLibrary.Model.RTU;
using ModbusServiceLibrary.Model.Signals;

namespace ModbusServiceLibrary.RtuConfiguration
{
	public sealed class ModbusRtuConfiguration : IModbusRtuConfiguration
	{
		private readonly ModelServiceReference.IModelService modelService;
		/// <summary>
		/// List of RTUs.
		/// </summary>
		private List<ModbusRTU> RtuList;


		/// <summary>
		/// Initializes the new instance of the <see cref="ModbusRtuConfiguration"/> class.
		/// </summary>
		/// <param name="modelService">An instance of the <see cref="ModelServiceReference.IModelService"/>.</param>
		public ModbusRtuConfiguration(ModelServiceReference.IModelService modelService)
		{
			this.modelService = modelService;
		}

		/// <summary>
		/// Initialize static data by reading all of RTUs from Model Service.
		/// Need to be called before using class methods.
		/// </summary>
		public void InitializeData()
		{
			RtuList = ReadAllRTUs();
		}



		/// <summary>
		/// Reads all RTU static data from Model Service
		/// </summary>
		/// <returns>List of RTUs</returns>
		public List<ModbusRTU> ReadAllRTUs()
		{
			List<ModbusRTU> rtus = new List<ModbusRTU>();

			foreach (var rtu in modelService.GetAllRTUs())
			{
				ModbusRTU newRTU = new ModbusRTU(rtu);
				rtus.Add(newRTU);
			}

			return rtus;
		}

		public RTUConnectionParameters GetRtuConnectionParameters(int rtuId)
		{
			return FindRtu(rtuId).RTUConnectionParameters;
		}

		public IModbusSignal GetSignal(int rtuId, int signalId)
		{
			return FindRtu(rtuId).Signals.SingleOrDefault(s => s.ID == signalId);
		}

		private ModbusRTU FindRtu(int rtuId)
		{
			return RtuList.SingleOrDefault(r => r.ID == rtuId);
		}

	}
}
