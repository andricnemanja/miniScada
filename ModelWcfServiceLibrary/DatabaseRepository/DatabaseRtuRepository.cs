using ModelWcfServiceLibrary.EntityDataModel;
using ModelWcfServiceLibrary.Model.RTU;
using ModelWcfServiceLibrary.Model.Signals;
using System.Collections.Generic;
using System.Linq;

namespace ModelWcfServiceLibrary.DatabaseRepository
{
	/// <summary>
	/// Class for communication with a file where RTU static data are stored.
	/// </summary>
	public class DatabaseRtuRepository : IDatabaseRtuRepository
	{
		/// <summary>
		/// Context class of the database.
		/// </summary>
		private readonly MiniScadaDBEntities miniScadaDB;

		/// <summary>
		/// List of all Rtus in the model service. 
		/// </summary>
		public List<ModelRTU> RtuList { get; private set; }

		/// <summary>
		/// Initializes new instance of the <see cref="DatabaseRtuRepository"/> class.
		/// </summary>
		public DatabaseRtuRepository()
		{
			miniScadaDB = new MiniScadaDBEntities();
			RtuList = new List<ModelRTU>();
		}

		/// <summary>
		/// Maps data from the database to the Model Service.
		/// </summary>
		public void MapFromDatabase()
		{
			List<DbRtu> rtusListDB = miniScadaDB.DbRtus.AsNoTracking().ToList();

			foreach (var rtuDB in rtusListDB)
			{
				ModelRTU newRtu = rtuDB.ToModel();
			
				RtuList.Add(newRtu);
			}
		}

		/// <summary>
		/// Gets the RTU with specified ID.
		/// </summary>
		/// <param name="rtuID">Unique identification number for the RTU</param>
		/// <returns>RTU with the given ID. If RTU with that ID doesn't exist, it will return <c>null</c></returns>
		public ModelRTU GetRTUByID(int id)
		{
			return RtuList.SingleOrDefault(r => r.RTUData.ID == id);
		}

		/// <summary>
		/// Get list of analog signals for RTU with given ID
		/// </summary>
		/// <param name="id">Unique identifier for RTU</param>
		/// <returns>List of analog signals</returns>
		public IEnumerable<ModelAnalogSignal> GetAnalogSignalsForRtu(int id)
		{
			return GetRTUByID(id).AnalogSignals;
		}

		/// <summary>
		/// Get list of discrete signals for RTU with given ID
		/// </summary>
		/// <param name="id">Unique identifier for RTU</param>
		/// <returns>List of discrete signals</returns>
		public IEnumerable<ModelDiscreteSignal> GetDiscreteSignalsForRtu(int id)
		{
			return GetRTUByID(id).DiscreteSignals;
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
