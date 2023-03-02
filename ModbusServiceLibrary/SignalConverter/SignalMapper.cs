using System;
using System.Collections.Generic;
using System.Linq;
using ModbusServiceLibrary.ModelServiceReference;

namespace ModbusServiceLibrary.SignalConverter
{
	public class SignalMapper : ISignalMapper
	{
		private readonly ModelServiceReference.IModelService modelService;
		private List<AnalogSignalMapping> analogSignalMappings;
		private List<DiscreteSignalMapping> discreteSignalMappings;

		public SignalMapper(IModelService modelService)
		{
			this.modelService = modelService;
			analogSignalMappings = ReadAnalogSignalMappings();
			discreteSignalMappings = ReadDiscreteSignalMappings();
		}

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
			AnalogSignalMapping analogSignalMapping = FindAnalogSignalMapping(mappingId);
			return signalValue * analogSignalMapping.K + analogSignalMapping.N;
		}

		public int ConvertRealValueToAnalogSignalValue(int mappingId, double signalValue)
		{
			AnalogSignalMapping analogSignalMapping = FindAnalogSignalMapping(mappingId);
			return (int)Math.Round((signalValue - analogSignalMapping.N) / analogSignalMapping.K);
		}
		
		public byte ConvertStateToDiscreteSignalValue(int mappingId, string value)
		{
			return FindDiscreteSingalMapping(mappingId).DiscreteValueToState.SingleOrDefault(x => x.Value == value).Key;
		}

		private DiscreteSignalMapping FindDiscreteSingalMapping(int mappingId)
		{
			return discreteSignalMappings.SingleOrDefault(m => m.Id == mappingId);
		}

		/// <summary>
		/// Finds mapping for analog signal.
		/// </summary>
		/// <param name="rtuId">ID of the RTU.</param>
		/// <returns>Discrete signal mapping for signal with given address.</returns>
		private AnalogSignalMapping FindAnalogSignalMapping(int mappingId)
		{
			return analogSignalMappings.SingleOrDefault(m => m.Id == mappingId);
		}

		private List<AnalogSignalMapping> ReadAnalogSignalMappings()
		{
			List<AnalogSignalMapping> analogSignalMappings = new List<AnalogSignalMapping>();

			foreach (var mapping in modelService.GetAnalogSignalMappings())
			{
				AnalogSignalMapping newMapping = new AnalogSignalMapping()
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
		private List<DiscreteSignalMapping> ReadDiscreteSignalMappings()
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
