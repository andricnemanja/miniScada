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

		public List<ModelRTU> RtuList { get; private set; }

		public DatabaseRtuRepository()
		{
			miniScadaDB = new MiniScadaDB();
			RtuList = new List<ModelRTU>();
		}

		public void MapFromDatabase()
		{
			List<DbRtu> rtusListDB = miniScadaDB.DbRtus.ToList();

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
					AnalogSignals = rtuDB.DbSignals
						.Where(signal => signal.signal_type == 0)
						.Select(signal => new ModelAnalogSignal
						{
							ID = signal.signal_id,
							Name = signal.signal_name,
							Address = signal.signal_address,
							AccessType = (ModelSignalAccessType)signal.access_type,
							Deadband = signal.deadband,
							StaleTime = signal.stale_time,
							MappingId = signal.mapping_id
						})
						.ToList(),
					DiscreteSignals = rtuDB.DbSignals
						.Where(signal => signal.signal_type == 1)
						.Select(signal => new ModelDiscreteSignal
						{
							ID = signal.signal_id,
							Name = signal.signal_name,
							Address = signal.signal_address,
							AccessType = (ModelSignalAccessType)signal.access_type,
							Deadband = signal.deadband,
							StaleTime = signal.stale_time,
							SignalType = (ModelDiscreteSignalType)signal.discrete_signal_type,
							MappingId = signal.mapping_id
						})
						.ToList()
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
