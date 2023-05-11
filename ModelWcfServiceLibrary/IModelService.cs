using System.Collections.Generic;
using System.ServiceModel;
using ModelWcfServiceLibrary.Model.RTU;
using ModelWcfServiceLibrary.Model.ScanPeriodMapping;
using ModelWcfServiceLibrary.Model.SignalMapping;
using ModelWcfServiceLibrary.Model.Signals;

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
        List<ModelRTU> GetAllRTUs();
		/// <summary>
		/// Get static data for RTU with given ID
		/// </summary>
		/// <param name="id">Unique identifier for RTU</param>
		/// <returns>RTU with given ID</returns>
		[OperationContract]
		[FaultContract(typeof(ModelServiceException))]
        ModelRTU GetRTU(int id);
		/// <summary>
		/// Get list of discrete signals for RTU with given ID
		/// </summary>
		/// <param name="id">Unique identifier for RTU</param>
		/// <returns>List of discrete signals</returns>
		[OperationContract]
		IEnumerable<ModelDiscreteSignal> GetDiscreteSignalsForRtu(int id);
		/// <summary>
		/// Get list of analog signals for RTU with given ID
		/// </summary>
		/// <param name="id">Unique identifier for RTU</param>
		/// <returns>List of analog signals</returns>
		[OperationContract]
		IEnumerable<ModelAnalogSignal> GetAnalogSignalsForRtu(int id);
		/// <summary>
		/// Get RTUs essential data
		/// </summary>
		/// <returns>List of essential data for all RTUs</returns>
		[OperationContract]
		IEnumerable<ModelRTUData> GetRTUsEssentialData();
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
		/// <summary>
		/// Get possible states for discrete signal.
		/// </summary>
		/// <returns>List of discrete signal mappings</returns>
		[OperationContract]
		string[] GetDiscreteSignalPossibleStates(int rtuId, int signalAddress);

		[OperationContract]
		IEnumerable<SignalScanPeriodMapping> GetSignalScanPeriodMappings();

	}
}
