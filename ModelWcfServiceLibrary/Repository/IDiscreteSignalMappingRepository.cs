using System.Collections.Generic;
using ModelWcfServiceLibrary.Model.SignalMapping;

namespace ModelWcfServiceLibrary.Repository
{
	public interface IDiscreteSignalMappingRepository
	{
		List<DiscreteSignalMapping> DiscreteSignalMappingList { get; }

		void Deserialize();
		void Serialize();
		DiscreteSignalMapping GetByID(int id);
		string[] GetDiscreteSignalPossibleStates(int mappingId);
	}
}