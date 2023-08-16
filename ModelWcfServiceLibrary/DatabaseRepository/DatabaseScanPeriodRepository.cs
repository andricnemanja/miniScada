using ModelWcfServiceLibrary.EntityDataModel;
using ModelWcfServiceLibrary.Model.ScanPeriodMapping;
using System.Collections.Generic;
using System.Linq;

namespace ModelWcfServiceLibrary.DatabaseRepository
{
	public class DatabaseScanPeriodRepository : IDatabaseScanPeriodRepository
	{
		MiniScadaDB miniScadaDB;

		List<SignalScanPeriodMapping> ScanPeriodList;

		public DatabaseScanPeriodRepository()
		{
			miniScadaDB = new MiniScadaDB();
			ScanPeriodList = new List<SignalScanPeriodMapping>();
		}

		public void MapFromDatabase()
		{
			List<ScanPeriodDB> scanPeriodsDB = miniScadaDB.ScanPeriods.ToList();

			foreach (var periods in scanPeriodsDB)
			{
				SignalScanPeriodMapping newScanPeriod = new SignalScanPeriodMapping()
				{
					Id = periods.scan_id,
					Name = periods.scan_name,
					TimeStamp = periods.scan_period
				};

				ScanPeriodList.Add(newScanPeriod);
			}
		}

		public SignalScanPeriodMapping GetScanPeriodByID(int id)
		{
			return ScanPeriodList.SingleOrDefault(m => m.Id == id);
		}
	}
}
