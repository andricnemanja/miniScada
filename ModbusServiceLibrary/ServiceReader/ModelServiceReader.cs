using System.Collections.Generic;
using ModbusServiceLibrary.Model.RTU;
using ModbusServiceLibrary.Model.SignalMapping;

namespace ModbusServiceLibrary.ServiceReader
{
	public sealed class ModelServiceReader : IModelServiceReader
	{
		private readonly ModelServiceReference.IModelService modelService;


		/// <summary>
		/// Initializes the new instance of the <see cref="ModelServiceReader"/> class.
		/// </summary>
		/// <param name="modelService">An instance of the <see cref="ModelServiceReference.IModelService"/>.</param>
		public ModelServiceReader(ModelServiceReference.IModelService modelService)
		{
			this.modelService = modelService;
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
