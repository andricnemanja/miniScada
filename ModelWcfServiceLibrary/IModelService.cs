using System.Collections.Generic;
using System.ServiceModel;
using SharedModel.Model.RTU;
using SharedModel.Model.Signals;

namespace ModelWcfServiceLibrary
{
	/// <summary>
	/// Provides endpoints for Model Service
	/// </summary>
	[ServiceContract]
    public interface IModelService
    {
		/// <summary>
		/// Get static data for all RTUs
		/// </summary>
		/// <returns>List of RTUs</returns>
		[OperationContract]
        List<RTU> GetStaticData();
		/// <summary>
		/// Get static data for RTU with given ID
		/// </summary>
		/// <param name="id">Unique identifier for RTU</param>
		/// <returns>RTU with given ID</returns>
		[OperationContract]
        RTU GetRTU(int id);
		/// <summary>
		/// Get list of discrete signals for RTU with given ID
		/// </summary>
		/// <param name="id">Unique identifier for RTU</param>
		/// <returns>List of discrete signals</returns>
		[OperationContract]
		List<DiscreteSignal> GetDiscreteSignalsForRtu(int id);
		/// <summary>
		/// Get list of analog signals for RTU with given ID
		/// </summary>
		/// <param name="id">Unique identifier for RTU</param>
		/// <returns>List of analog signals</returns>
		[OperationContract]
		IEnumerable<AnalogSignal> GetAnalogSignalsForRtu(int id);


	}
}
