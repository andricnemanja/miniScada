using ModelWcfServiceLibrary.Model.SignalMapping;
using System.Collections.Generic;

namespace ModelWcfServiceLibrary.DatabaseRepository
{
	public interface IDatabaseDiscreteSignalMappingRepository
	{
		List<ModelDiscreteSignalMapping> DiscreteMappingsList { get; }

		ModelDiscreteSignalMapping GetDiscreteMappingByID(int id);
		string[] GetDiscreteSignalPossibleStates(int mappingId);
		void MapFromDatabase();
	}
}