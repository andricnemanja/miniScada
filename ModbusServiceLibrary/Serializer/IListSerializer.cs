using System.Collections.Generic;

namespace ModelWcfServiceLibrary.Serializer
{
	public interface IListSerializer<T>
	{
		/// <summary>
		/// Read serialized object from a JSON file.
		/// </summary>
		/// <returns>List of saved objects</returns>
		List<T> Deserialize();
		void Serialize(List<T> listToSerialize);
	}
}