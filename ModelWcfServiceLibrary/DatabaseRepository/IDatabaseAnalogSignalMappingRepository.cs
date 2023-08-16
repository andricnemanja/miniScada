using ModelWcfServiceLibrary.Model.SignalMapping;

namespace ModelWcfServiceLibrary.DatabaseRepository
{
	public interface IDatabaseAnalogSignalMappingRepository
	{
		ModelAnalogSignalMapping GetAnalogMappingByID(int id);
		void MapFromDatabase();
	}
}