using System.Collections.Generic;
using System.Linq;
using ModbusServiceLibrary.Model.RTU;
using ModbusServiceLibrary.Model.SignalMapping;
using ModbusServiceLibrary.Model.Signals;
using ModbusServiceLibrary.Model.SignalValues;

namespace ModbusServiceLibrary.ServiceReader
{
	public sealed class RtuConfiguration : IRtuConfiguration
	{
		private readonly ModelServiceReference.IModelService modelService;


		/// <summary>
		/// Initializes the new instance of the <see cref="RtuConfiguration"/> class.
		/// </summary>
		/// <param name="modelService">An instance of the <see cref="ModelServiceReference.IModelService"/>.</param>
		public RtuConfiguration(ModelServiceReference.IModelService modelService)
		{
			this.modelService = modelService;
		}

		/// <summary>
		/// List of RTUs.
		/// </summary>
		public List<RTU> RtuList { get; private set; }

		/// <summary>
		/// Initialize static data by reading all of RTUs from Model Service. Need to be called before using class methods.
		/// </summary>
		public void InitializeData()
		{
			RtuList = ReadAllRTUs();
		}

		public ISignalValue GetSignalValue(int rtuId, int signalId)
		{
			AnalogSignalValue signalValue = (AnalogSignalValue)FindRtu(rtuId).AnalogSignalValues.SingleOrDefault(s => s.SignalData.ID == signalId);
			
			if(signalValue != null)
				return signalValue;

			return FindRtu(rtuId).DiscreteSignalValues.SingleOrDefault(s => s.SignalData.ID == signalId);
		}

		/// <summary>
		/// Reads all RTU static data from Model Service
		/// </summary>
		/// <returns>List of RTUs</returns>
		public List<RTU> ReadAllRTUs()
		{
			List<RTU> rtus = new List<RTU>();

			foreach (var rtu in modelService.GetAllRTUs())
			{
				RTU newRTU = new RTU(rtu);
				rtus.Add(newRTU);
			}

			return rtus;
		}


		public int GetMappingIdForDiscreteSignal(int rtuId, int signalId)
		{
			return FindDiscreteSignal(rtuId, signalId).MappingId;
		}

		private RTU FindRtu(int rtuId)
		{
			return RtuList.SingleOrDefault(r => r.RTUData.ID == rtuId);
		}

		public RTUData FindRtuData(int rtuId)
		{
			return FindRtu(rtuId).RTUData;
		}

		private ISignal FindDiscreteSignal(int rtuId, int signalId)
		{
			return FindRtu(rtuId).DiscreteSignalValues.SingleOrDefault(s => s.SignalData.ID == signalId).SignalData;
		}

		/// <summary>
		/// Reads all analog signal mappings from Model Service
		/// </summary>
		/// <returns>List of analog signal mappings</returns>
		public List<AnalogSignalMapping> ReadAnalogSignalMappings() 
		{
			List<AnalogSignalMapping> analogSignalMappings = new List<AnalogSignalMapping>();

			foreach (var mapping in modelService.GetAnalogSignalMappings())
			{
				AnalogSignalMapping newMapping= new AnalogSignalMapping()
				{
					Id = mapping.Id,
					Name = mapping.Name,
					K = mapping.K,
					N = mapping.N
				};
				analogSignalMappings.Add(newMapping);
			}
			return analogSignalMappings;
		}

		/// <summary>
		/// Reads all discrete signal mappings from model service
		/// </summary>
		/// <returns>List of discrete signal mappings</returns>
		public List<DiscreteSignalMapping> ReadDiscreteSignalMappings()
		{
			List<DiscreteSignalMapping> discreteSignalMappings = new List<DiscreteSignalMapping>();

			foreach (var mapping in modelService.GetDiscreteSignalMappings())
			{
				DiscreteSignalMapping newMapping = new DiscreteSignalMapping()
				{
					Id = mapping.Id,
					Name = mapping.Name,
					DiscreteValueToState = mapping.DiscreteValueToState,
				};
				discreteSignalMappings.Add(newMapping);
			}
			return discreteSignalMappings;
		}
	}
}
