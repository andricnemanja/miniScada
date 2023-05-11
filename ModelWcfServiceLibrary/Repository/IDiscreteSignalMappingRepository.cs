using System.Collections.Generic;
using ModelWcfServiceLibrary.Model.SignalMapping;

namespace ModelWcfServiceLibrary.Repository
{
	public interface IDiscreteSignalMappingRepository
	{
		List<ModelDiscreteSignalMapping> DiscreteSignalMappingList { get; }

		void Deserialize();
		void Serialize();
		ModelDiscreteSignalMapping GetByID(int id);
		string[] GetDiscreteSignalPossibleStates(int mappingId);
	}
}