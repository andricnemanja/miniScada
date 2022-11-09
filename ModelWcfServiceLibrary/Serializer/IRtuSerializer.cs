using System.Collections.Generic;
using ModelWcfServiceLibrary.Model.RTU;

namespace ModelWcfServiceLibrary.Serializer
{
	/// <summary>
	/// Provides functionality to serialize and deserialize RTU list
	/// </summary>
	public interface IRtuSerializer
	{
		/// <summary>
		/// Saves the current state of the RTUs to a file
		/// </summary>
		/// <param name="rtuList">List of RTUs to be saved</param>
		void Serialize(List<RTU> rtuList);
		/// <summary>
		/// Read RTUs static data from a file.
		/// </summary>
		/// <returns>List of RTUs</returns>
		List<RTU> Deserialize();
	}
}
