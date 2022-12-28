using System.Collections.Generic;

namespace ModelWcfServiceLibrary.Serializer
{
	public interface IListSerializer<T>
	{
		List<T> Deserialize();
		void Serialize(List<T> listToSerialize);
	}
}