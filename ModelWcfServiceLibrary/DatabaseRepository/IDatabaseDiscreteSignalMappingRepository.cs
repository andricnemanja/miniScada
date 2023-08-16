using ModelWcfServiceLibrary.Model.SignalMapping;

namespace ModelWcfServiceLibrary.DatabaseRepository
{
	public interface IDatabaseDiscreteSignalMappingRepository
	{
		ModelDiscreteSignalMapping GetDiscreteMappingByID(int id);
		void MapFromDatabase();
	}
}