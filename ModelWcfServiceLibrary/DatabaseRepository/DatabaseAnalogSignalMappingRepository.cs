using ModelWcfServiceLibrary.EntityDataModel;
using ModelWcfServiceLibrary.Model.SignalMapping;
using System.Collections.Generic;
using System.Linq;

namespace ModelWcfServiceLibrary.DatabaseRepository
{
	public class DatabaseAnalogSignalMappingRepository : IDatabaseAnalogSignalMappingRepository
	{
		MiniScadaDBEntities miniScadaDB;

		public List<ModelAnalogSignalMapping> AnalogMappingsList { get; private set; }

		public DatabaseAnalogSignalMappingRepository()
		{
			miniScadaDB = new MiniScadaDBEntities();

			AnalogMappingsList = new List<ModelAnalogSignalMapping>();
		}

		public void MapFromDatabase()
		{
			List<DbMapping> signalMappingsDB = miniScadaDB.DbMappings.ToList();

			foreach (var analogmapping in signalMappingsDB)
			{
				if (analogmapping.K != null)
				{
					ModelAnalogSignalMapping newAnalogMapping = analogmapping.ToModelAnalogMapping();

					AnalogMappingsList.Add(newAnalogMapping);
				}
			}
		}

		public ModelAnalogSignalMapping GetAnalogMappingByID(int id)
		{
			return AnalogMappingsList.SingleOrDefault(m => m.Id == id);
		}
	}
}
