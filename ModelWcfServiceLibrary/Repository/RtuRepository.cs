using System.Collections.Generic;
using System.Linq;
using ModelWcfServiceLibrary.Model.RTU;
using ModelWcfServiceLibrary.Model.Signals;
using ModelWcfServiceLibrary.Serializer;

namespace ModelWcfServiceLibrary.Repository
{
    /// <summary>
    /// Class for communication with a file where RTU static data are stored.
    /// </summary>
    public sealed class RtuRepository : IRtuRepository
    {
        private readonly IListSerializer<RTU> rtuSerializer;

		/// <summary>
		/// Initializes a new instance of the <see cref="RtuRepository"/>
		/// </summary>
		/// <param name="rtuSerializer">Instance of the <see cref="IListSerializer"/> class</param>
		public RtuRepository(IListSerializer<RTU> rtuSerializer)
        {
            this.rtuSerializer = rtuSerializer;
            RtuList = new List<RTU>();
        }

        /// <summary>
        /// List of RTUs read from a file. If <c>Deserialize()</c> method isn't called after instantiating the class, the list is going to be empty.
        /// </summary>
        public List<RTU> RtuList { get; private set; }

        /// <summary>
        /// Saves the current state of the RTUs to a file
        /// </summary>
        public void Serialize()
        {
            rtuSerializer.Serialize(RtuList);
        }

        /// <summary>
        ///  Read RTUs data from a file in the <c>DiscreteSignalMappingList</c>.
        /// </summary>
        public void Deserialize()
        {
            RtuList = rtuSerializer.Deserialize();
        }

        /// <summary>
        /// Gets the RTU with specified ID.
        /// </summary>
        /// <param name="rtuID">Unique identification number for the RTU</param>
        /// <returns>RTU with the given ID. If RTU with that ID doesn't exist, it will return <c>null</c></returns>
        public RTU GetRTUByID(int rtuID)
        {
            return RtuList.SingleOrDefault(t => t.RTUData.ID == rtuID);
        }
		/// <summary>
		/// Get list of discrete signals for RTU with given ID
		/// </summary>
		/// <param name="id">Unique identifier for RTU</param>
		/// <returns>List of discrete signals</returns>
		public IEnumerable<DiscreteSignal> GetDiscreteSignalsForRtu(int id)
		{
            return GetRTUByID(id).DiscreteSignals;
		}
		/// <summary>
		/// Get list of analog signals for RTU with given ID
		/// </summary>
		/// <param name="id">Unique identifier for RTU</param>
		/// <returns>List of analog signals</returns>
		public IEnumerable<AnalogSignal> GetAnalogSignalsForRtu(int id)
		{
			return GetRTUByID(id).AnalogSignals;
		}
		/// <summary>
		/// Get RTUs essential data
		/// </summary>
		/// <returns>List of essential data for all RTUs</returns>
		public IEnumerable<RTUData> GetRTUsEssentialData()
		{
			return RtuList.Select(r => r.RTUData);
		}
	}
}
