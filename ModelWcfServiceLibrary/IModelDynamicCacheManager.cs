using ModelWcfServiceLibrary.Model.RTU;
using System.Collections.Generic;
using System.ServiceModel;

namespace ModelWcfServiceLibrary
{
	[ServiceContract]
	public interface IModelDynamicCacheManager
	{
		/// <summary>
		/// Get static data for all RTUs
		/// </summary>
		/// <returns>List of RTUs</returns>
		[OperationContract]
		List<ModelRTU> GetAllRTUs();
	}
}
