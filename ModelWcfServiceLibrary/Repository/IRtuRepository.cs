using System.Collections.Generic;
using ModelWcfServiceLibrary.Model.RTU;

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
    }
}
