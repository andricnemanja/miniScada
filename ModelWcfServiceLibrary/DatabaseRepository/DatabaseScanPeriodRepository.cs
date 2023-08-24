using ModelWcfServiceLibrary.EntityDataModel;
using ModelWcfServiceLibrary.Model.ScanPeriodMapping;
using System.Collections.Generic;
using System.Linq;

namespace ModelWcfServiceLibrary.DatabaseRepository
{
	public class DatabaseScanPeriodRepository : IDatabaseScanPeriodRepository
	{
		MiniScadaDBEntities miniScadaDB;

		public List<SignalScanPeriodMapping> ScanPeriodList { get; private set; }

		public DatabaseScanPeriodRepository()
		{
			miniScadaDB = new MiniScadaDBEntities();
			ScanPeriodList = new List<SignalScanPeriodMapping>();
		}

		public void MapFromDatabase()
		{
			List<DbScanPeriod> scanPeriodsDB = miniScadaDB.DbScanPeriods.AsNoTracking().ToList();

			foreach (var period in scanPeriodsDB)
			{
				SignalScanPeriodMapping newScanPeriod = period.ToModel();

				ScanPeriodList.Add(newScanPeriod);
			}
		}

		public SignalScanPeriodMapping GetScanPeriodByID(int id)
		{
			return ScanPeriodList.SingleOrDefault(m => m.Id == id);
		}
	}
}
