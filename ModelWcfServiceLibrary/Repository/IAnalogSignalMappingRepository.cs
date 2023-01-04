using System.Collections.Generic;
using ModelWcfServiceLibrary.Model.SignalMapping;

namespace ModelWcfServiceLibrary.Repository
{
	public interface IAnalogSignalMappingRepository
	{
		List<AnalogSignalMapping> AnalogSignalMappingList { get; }

		void Deserialize();
		AnalogSignalMapping GetByID(int id);
		void Serialize();
	}
}