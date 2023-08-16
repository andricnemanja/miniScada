using ModelWcfServiceLibrary.EntityDataModel;
using ModelWcfServiceLibrary.Model.RTU;
using ModelWcfServiceLibrary.Model.Signals;
using System.Collections.Generic;
using System.Linq;

namespace ModelWcfServiceLibrary.DatabaseRepository
{
	public class DatabaseRtuRepository : IDatabaseRtuRepository
	{
		private readonly MiniScadaDB miniScadaDB;
		public List<ModelRTU> RtuList;

		public DatabaseRtuRepository()
		{
			miniScadaDB = new MiniScadaDB();
			RtuList = new List<ModelRTU>();
		}

		public void MapFromDatabase()
		{
			List<RtuDB> rtusListDB = miniScadaDB.Rtus.ToList();

			foreach (var rtuDB in rtusListDB)
			{
				ModelRTUData newRtuData = new ModelRTUData()
				{
					ID = rtuDB.rtu_id,
					Name = rtuDB.rtu_name,
					IpAddress = rtuDB.ip_address,
					Port = rtuDB.rtu_port
				};

				ModelRTU newRtu = new ModelRTU()
				{
					RTUData = newRtuData,
					// AnalogSignals = rtuDB.Signals.Where(m => m.signal_type == 0),
					// DiscreteSignals = rtuDB.Signals.Where(m => m.signal_type == 1)
				};

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
