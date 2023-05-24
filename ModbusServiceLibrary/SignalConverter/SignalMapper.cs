using System;
using System.Collections.Generic;
using System.Linq;
using ModbusServiceLibrary.ModelServiceReference;

namespace ModbusServiceLibrary.SignalConverter
{
	/// <summary>
	/// Class that maps signal values of the signal from the sensors to the values that have physical meaning.
	/// </summary>
	public class SignalMapper : ISignalMapper
	{
		private readonly ModelServiceReference.IModelService modelService;
		private List<ModelAnalogSignalMapping> analogSignalMappings;
		private List<ModelDiscreteSignalMapping> discreteSignalMappings;

		public SignalMapper(IModelService modelService)
		{
			this.modelService = modelService;
			analogSignalMappings = ReadAnalogSignalMappings();
			discreteSignalMappings = ReadDiscreteSignalMappings();
		}

		/// <summary>
		/// Converts discrete singla value to the state.
		/// </summary>
		/// <param name="mappingId">ID of the mapping.</param>
		/// <param name="signalValue">Value of the signal.</param>
		/// <returns></returns>
		public string ConvertDiscreteSignalValueToState(int mappingId, byte signalValue)
		{
			return FindDiscreteSingalMapping(mappingId).DiscreteValueToState[signalValue];
		}

		/// <summary>
		/// Convert sensor values to real values that have physical meaning.
		/// </summary>
		/// <param name="rtuId">ID of the RTU.</param>
		/// <param name="analogSignalAddress">Address of the analog signal.</param>
		/// <param name="value">Value that is being converted.</param>
		/// <returns>Value with it's phyisical connotation.</returns>
		public double ConvertAnalogSignalToRealValue(int mappingId, double signalValue)
		{
			ModelAnalogSignalMapping analogSignalMapping = FindAnalogSignalMapping(mappingId);
			return signalValue * analogSignalMapping.K + analogSignalMapping.N;
		}

		/// <summary>
		/// Converts real value to the analog signal value.
		/// </summary>
		/// <param name="mappingId">ID of the mapping.</param>
		/// <param name="signalValue">Value of the analog signal.</param>
		/// <returns></returns>
		public int ConvertRealValueToAnalogSignalValue(int mappingId, double signalValue)
		{
			ModelAnalogSignalMapping analogSignalMapping = FindAnalogSignalMapping(mappingId);
			return (int)Math.Round((signalValue - analogSignalMapping.N) / analogSignalMapping.K);
		}
		
		/// <summary>
		/// Converts state of the signal to the discrete signal value.
		/// </summary>
		/// <param name="mappingId">ID of the mapping.</param>
		/// <param name="value">Value thats is converted.</param>
		/// <returns></returns>
		public byte ConvertStateToDiscreteSignalValue(int mappingId, string value)
		{
			return FindDiscreteSingalMapping(mappingId).DiscreteValueToState.SingleOrDefault(x => x.Value == value).Key;
		}

		/// <summary>
		/// Finds discrete signal mapping by its ID.
		/// </summary>
		/// <param name="mappingId">ID of the mapping.</param>
		/// <returns>Discrete signal mapping.</returns>
		private ModelDiscreteSignalMapping FindDiscreteSingalMapping(int mappingId)
		{
			return discreteSignalMappings.SingleOrDefault(m => m.Id == mappingId);
		}

		/// <summary>
		/// Finds mapping for analog signal.
		/// </summary>
		/// <param name="rtuId">ID of the RTU.</param>
		/// <returns>Discrete signal mapping for signal with given address.</returns>
		private ModelAnalogSignalMapping FindAnalogSignalMapping(int mappingId)	
		{
			return analogSignalMappings.SingleOrDefault(m => m.Id == mappingId);
		}

		/// <summary>
		/// Reads all the mappings from the Model service.
		/// </summary>
		/// <returns>List of mapping for analog signals.</returns>
		private List<ModelAnalogSignalMapping> ReadAnalogSignalMappings()
		{
			List<ModelAnalogSignalMapping> analogSignalMappings = new List<ModelAnalogSignalMapping>();

			foreach (var mapping in modelService.GetAnalogSignalMappings())
			{
				ModelAnalogSignalMapping newMapping = new ModelAnalogSignalMapping()
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
		private List<ModelDiscreteSignalMapping> ReadDiscreteSignalMappings()
		{
			List<ModelDiscreteSignalMapping> discreteSignalMappings = new List<ModelDiscreteSignalMapping>();

			foreach (var mapping in modelService.GetDiscreteSignalMappings())
			{
				ModelDiscreteSignalMapping newMapping = new ModelDiscreteSignalMapping()
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
