using ModelWcfServiceLibrary.Model.ScanPeriodMapping;

namespace ModelWcfServiceLibrary.DatabaseRepository
{
	public interface IDatabaseScanPeriodRepository
	{
		SignalScanPeriodMapping GetScanPeriodByID(int id);
		void MapFromDatabase();
	}
}