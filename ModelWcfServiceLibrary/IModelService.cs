using System.Collections.Generic;
using System.ServiceModel;
using ModelWcfServiceLibrary.Model.Flags;
using ModelWcfServiceLibrary.Model.RTU;
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
        List<RTU> GetAllRTUs();
		/// <summary>
		/// Get static data for RTU with given ID
		/// </summary>
		/// <param name="id">Unique identifier for RTU</param>
		/// <returns>RTU with given ID</returns>
		[OperationContract]
		[FaultContract(typeof(ModelServiceException))]
        RTU GetRTU(int id);
		/// <summary>
		/// Get list of discrete signals for RTU with given ID
		/// </summary>
		/// <param name="id">Unique identifier for RTU</param>
		/// <returns>List of discrete signals</returns>
		[OperationContract]
		IEnumerable<DiscreteSignal> GetDiscreteSignalsForRtu(int id);
		/// <summary>
		/// Get list of analog signals for RTU with given ID
		/// </summary>
		/// <param name="id">Unique identifier for RTU</param>
		/// <returns>List of analog signals</returns>
		[OperationContract]
		IEnumerable<AnalogSignal> GetAnalogSignalsForRtu(int id);
		/// <summary>
		/// Get RTUs essential data
		/// </summary>
		/// <returns>List of essential data for all RTUs</returns>
		[OperationContract]
		IEnumerable<RTUData> GetRTUsEssentialData();
		/// <summary>
		/// Get all analog signal mappings
		/// </summary>
		/// <returns>List of analog signal mappings</returns>
		[OperationContract]
		IEnumerable<AnalogSignalMapping> GetAnalogSignalMappings();

		/// <summary>
		/// Get all discrete signal mappings
		/// </summary>
		/// <returns>List of discrete signal mappings</returns>
		[OperationContract]
		IEnumerable<DiscreteSignalMapping> GetDiscreteSignalMappings();
		/// <summary>
		/// Get possible states for discrete signal.
		/// </summary>
		/// <returns>List of discrete signal mappings</returns>
		[OperationContract]
		string[] GetDiscreteSignalPossibleStates(int rtuId, int signalAddress);

		[OperationContract]
		IEnumerable<Flag> GetAllFlags();
	}
}
