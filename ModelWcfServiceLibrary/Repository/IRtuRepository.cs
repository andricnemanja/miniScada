using ModelWcfServiceLibrary.Model.RTU;
using ModelWcfServiceLibrary.Model.Signals;
using System.Collections.Generic;
using System.ServiceModel;

namespace ModelWcfServiceLibrary.Repository
{
    /// <summary>
    /// Communication with a file where RTU static data are stored.
    /// </summary>
    public interface IRtuRepository
    {
        /// <summary>
        /// List of RTUs read from a file. If <c>Deserialize()</c> method isn't called after instantiating the class, the list is going to be empty.
        /// </summary>
        List<RTU> RtuList { get; }
        /// <summary>
        /// Saves the current state of the RTUs to a file
        /// </summary>
        void Serialize();
        /// <summary>
        /// Reads RTUs static data from a file and stores it in the <c>RtuList</c>
        /// </summary>
        void Deserialize();
        /// <summary>
        /// Gets the RTU with specified ID
        /// </summary>
        /// <param name="rtuID">Unique identification number for the RTU</param>
        /// <returns>RTU with the given ID. If RTU with that ID doesn't exist, it will return <c>null</c></returns>
        RTU GetRTUByID(int rtuID);
		/// <summary>
		/// Get list of discrete signals for RTU with given ID
		/// </summary>
		/// <param name="id">Unique identifier for RTU</param>
		/// <returns>List of discrete signals</returns>
		IEnumerable<DiscreteSignal> GetDiscreteSignalsForRtu(int id);
		/// <summary>
		/// Get list of analog signals for RTU with given ID
		/// </summary>
		/// <param name="id">Unique identifier for RTU</param>
		/// <returns>List of analog signals</returns>
		IEnumerable<AnalogSignal> GetAnalogSignalsForRtu(int id);
		/// <summary>
		/// Get RTUs essential data
		/// </summary>
		/// <returns>List of essential data for all RTUs</returns>
		IEnumerable<RTUData> GetRTUsEssentialData();
	}
}
