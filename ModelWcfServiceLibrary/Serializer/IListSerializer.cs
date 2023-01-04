using System.Collections.Generic;

namespace ModelWcfServiceLibrary.Serializer
{
	/// <summary>
	/// Provides functionality to serialize and deserialize RTU list
	/// </summary>
	public interface IListSerializer<T>
	{
		/// <summary>
		/// Saves the current state of the RTUs to a file
		/// </summary>
		/// <param name="rtuList">List of RTUs to be saved</param>
		void Serialize(List<T> rtuList);
		/// <summary>
		/// Read RTUs static data from a file.
		/// </summary>
		/// <returns>List of RTUs</returns>
		List<T> Deserialize();
	}
}
