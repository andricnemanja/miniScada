using System.Collections.Generic;
using System.Linq;
using ModbusServiceLibrary.ModelServiceReference;

namespace ModbusServiceLibrary.SignalConverter
{
	public class SignalMapper : ISignalMapper
	{
		private readonly ModelServiceReference.IModelService modelService;
		private List<AnalogSignalMapping> analogSignalMappings;
		public List<DiscreteSignalMapping> discreteSignalMappings;

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

		private DiscreteSignalMapping FindDiscreteSingalMapping(int mappingId)
		{
			return discreteSignalMappings.SingleOrDefault(m => m.Id == mappingId);
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
