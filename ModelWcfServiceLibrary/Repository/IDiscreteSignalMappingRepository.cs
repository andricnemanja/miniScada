using System.Collections.Generic;
using ModelWcfServiceLibrary.Model.SignalMapping;

namespace ModelWcfServiceLibrary.Repository
{
	public interface IDiscreteSignalMappingRepository
	{
		List<DiscreteSignalMapping> DiscreteSignalMappingList { get; }

		void Deserialize();
		DiscreteSignalMapping GetByID(int id);
		void Serialize();
	}
}