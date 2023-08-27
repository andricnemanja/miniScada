using ModelWcfServiceLibrary.EntityDataModel;
using ModelWcfServiceLibrary.Model.SignalMapping;
using System.Collections.Generic;
using System.Linq;

namespace ModelWcfServiceLibrary.DatabaseRepository
{
	/// <summary>
	/// Class for communication with a file where RTU static data are stored.
	/// </summary>
	public class DatabaseAnalogSignalMappingRepository : IDatabaseAnalogSignalMappingRepository
	{
		/// <summary>
		/// Context class of the database.
		/// </summary>
		MiniScadaDBEntities miniScadaDB;

		/// <summary>
		/// List of all analog mappings.
		/// </summary>
		public List<ModelAnalogSignalMapping> AnalogMappingsList { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="DatabaseAnalogSignalMappingRepository"/>
		/// </summary>
		public DatabaseAnalogSignalMappingRepository()
		{
			miniScadaDB = new MiniScadaDBEntities();

			AnalogMappingsList = new List<ModelAnalogSignalMapping>();
		}

		/// <summary>
		/// Maps data from the database to the service model.
		/// </summary>
		public void MapFromDatabase()
		{
			List<DbMapping> signalMappingsDB = miniScadaDB.DbMappings.AsNoTracking().ToList();

			foreach (var analogmapping in signalMappingsDB)
			{
				if (analogmapping.K != null)
				{
					ModelAnalogSignalMapping newAnalogMapping = analogmapping.ToModelAnalogMapping();

					AnalogMappingsList.Add(newAnalogMapping);
				}
			}
		}

		/// <summary>
		/// Gets the Analog Signal Mapping with specified ID.
		/// </summary>
		/// <param name="id">Unique identification number for the signal mapping</param>
		/// <returns>Analog Signal Mapping with the given ID. If Mapping with that ID doesn't exist, it will return <c>null</c></returns>
		public ModelAnalogSignalMapping GetAnalogMappingByID(int id)
		{
			return AnalogMappingsList.SingleOrDefault(m => m.Id == id);
		}
	}
}
