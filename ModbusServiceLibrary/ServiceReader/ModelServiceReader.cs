using System.Collections.Generic;
using ModbusServiceLibrary.Model.RTU;

namespace ModbusServiceLibrary.ServiceReader
{
	public sealed class ModelServiceReader : IModelServiceReader
	{
		private readonly ModelServiceReference.IModelService modelService;


		/// <summary>
		/// Initializes the new instance of the <see cref="ModelServiceReader"/> class.
		/// </summary>
		/// <param name="modelService">An instance of the <see cref="IModelService"/>.</param>
		public ModelServiceReader(ModelServiceReference.IModelService modelService)
		{
			this.modelService = modelService;
		}

		/// <summary>
		/// Reads all RTUs
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
	}
}
