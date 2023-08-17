using ModelWcfServiceLibrary.Model.SignalMapping;
using System.Collections.Generic;

namespace ModelWcfServiceLibrary.DatabaseRepository
{
	public interface IDatabaseAnalogSignalMappingRepository
	{
		List<ModelAnalogSignalMapping> AnalogMappingsList { get; }

		ModelAnalogSignalMapping GetAnalogMappingByID(int id);
		void MapFromDatabase();
	}
}