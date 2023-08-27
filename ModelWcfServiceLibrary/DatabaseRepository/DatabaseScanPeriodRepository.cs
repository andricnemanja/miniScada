using ModelWcfServiceLibrary.EntityDataModel;
using ModelWcfServiceLibrary.Model.ScanPeriodMapping;
using System.Collections.Generic;
using System.Linq;

namespace ModelWcfServiceLibrary.DatabaseRepository
{
	/// <summary>
	/// Stores data from the database to the Model Service.
	/// </summary>
	public class DatabaseScanPeriodRepository : IDatabaseScanPeriodRepository
	{
		/// <summary>
		/// Context class of the database.
		/// </summary>
		MiniScadaDBEntities miniScadaDB;

		/// <summary>
		/// List of scan periods.
		/// </summary>
		public List<SignalScanPeriodMapping> ScanPeriodList { get; private set; }

		/// <summary>
		/// Initializes new instance of the <see cref="DatabaseScanPeriodRepository"/>
		/// </summary>
		public DatabaseScanPeriodRepository()
		{
			miniScadaDB = new MiniScadaDBEntities();
			ScanPeriodList = new List<SignalScanPeriodMapping>();
		}

		/// <summary>
		/// Maps data from the database to the Model Service.
		/// </summary>
		public void MapFromDatabase()
		{
			List<DbScanPeriod> scanPeriodsDB = miniScadaDB.DbScanPeriods.AsNoTracking().ToList();

			foreach (var period in scanPeriodsDB)
			{
				SignalScanPeriodMapping newScanPeriod = period.ToModel();

				ScanPeriodList.Add(newScanPeriod);
			}
		}

		/// <summary>
		/// Gets scan period by its ID.
		/// </summary>
		/// <param name="id">Unique ID of the scan period.</param>
		/// <returns>Instance of the <see cref="SignalScanPeriodMapping"/> class.</returns>
		public SignalScanPeriodMapping GetScanPeriodByID(int id)
		{
			return ScanPeriodList.SingleOrDefault(m => m.Id == id);
		}
	}
}
