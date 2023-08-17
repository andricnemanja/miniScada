using ModelWcfServiceLibrary.Model.ScanPeriodMapping;
using System.Collections.Generic;

namespace ModelWcfServiceLibrary.DatabaseRepository
{
	public interface IDatabaseScanPeriodRepository
	{
		List<SignalScanPeriodMapping> ScanPeriodList { get; }

		SignalScanPeriodMapping GetScanPeriodByID(int id);
		void MapFromDatabase();
	}
}