using ModelWcfServiceLibrary.EntityDataModel;
using ModelWcfServiceLibrary.Model.RTU;
using ModelWcfServiceLibrary.Model.Signals;
using System.Collections.Generic;
using System.Linq;

namespace ModelWcfServiceLibrary.DatabaseRepository
{
	public class DatabaseRtuRepository : IDatabaseRtuRepository
	{
		private readonly MiniScadaDBEntities miniScadaDB;

		public List<ModelRTU> RtuList { get; private set; }

		public DatabaseRtuRepository()
		{
			miniScadaDB = new MiniScadaDBEntities();
			RtuList = new List<ModelRTU>();
		}

		public void MapFromDatabase()
		{
			List<DbRtu> rtusListDB = miniScadaDB.DbRtus.AsNoTracking().ToList();

			foreach (var rtuDB in rtusListDB)
			{
				ModelRTU newRtu = rtuDB.ToModel();
			
				RtuList.Add(newRtu);
			}
		}

		public ModelRTU GetRTUbyID(int id)
		{
			return RtuList.SingleOrDefault(r => r.RTUData.ID == id);
		}

		public IEnumerable<ModelAnalogSignal> GetAnalogSignalsForRtu(int id)
		{
			return GetRTUbyID(id).AnalogSignals;
		}

		public IEnumerable<ModelDiscreteSignal> GetDiscreteSignalsForRtu(int id)
		{
			return GetRTUbyID(id).DiscreteSignals;
		}

		/// <summary>
		/// Get RTUs essential data
		/// </summary>
		/// <returns>List of essential data for all RTUs</returns>
		public IEnumerable<ModelRTUData> GetRTUsEssentialData()
		{
			return RtuList.Select(r => r.RTUData);
		}
	}
}
