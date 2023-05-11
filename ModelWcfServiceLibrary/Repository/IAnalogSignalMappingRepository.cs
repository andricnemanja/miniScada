using System.Collections.Generic;
using ModelWcfServiceLibrary.Model.SignalMapping;

namespace ModelWcfServiceLibrary.Repository
{
	public interface IAnalogSignalMappingRepository
	{
		List<ModelAnalogSignalMapping> AnalogSignalMappingList { get; }

		void Deserialize();
		ModelAnalogSignalMapping GetByID(int id);
		void Serialize();
	}
}