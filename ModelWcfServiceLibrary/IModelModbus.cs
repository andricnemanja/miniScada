using ModelWcfServiceLibrary.Model.SignalMapping;
using System.Collections.Generic;
using System.ServiceModel;

namespace ModelWcfServiceLibrary
{
	[ServiceContract]
	public interface IModelModbus
	{
		/// <summary>
		/// Get all analog signal mappings
		/// </summary>
		/// <returns>List of analog signal mappings</returns>
		[OperationContract]
		IEnumerable<ModelAnalogSignalMapping> GetAnalogSignalMappings();

		/// <summary>
		/// Get all discrete signal mappings
		/// </summary>
		/// <returns>List of discrete signal mappings</returns>
		[OperationContract]
		IEnumerable<ModelDiscreteSignalMapping> GetDiscreteSignalMappings();
	}
}
