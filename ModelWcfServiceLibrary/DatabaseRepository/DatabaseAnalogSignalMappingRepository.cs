using ModelWcfServiceLibrary.EntityDataModel;
using ModelWcfServiceLibrary.Model.SignalMapping;
using System.Collections.Generic;
using System.Linq;

namespace ModelWcfServiceLibrary.DatabaseRepository
{
	public class DatabaseAnalogSignalMappingRepository : IDatabaseAnalogSignalMappingRepository
	{
		MiniScadaDB MiniScadaDB;

		public List<ModelAnalogSignalMapping> AnalogMappingsList;

		public DatabaseAnalogSignalMappingRepository()
		{
			MiniScadaDB = new MiniScadaDB();

			AnalogMappingsList = new List<ModelAnalogSignalMapping>();
		}

		public void MapFromDatabase()
		{
			List<AnalogSignalMappingDB> analogSignalMappingsDB = MiniScadaDB.AnalogSignalMappings.ToList();

			foreach (var analogmapping in analogSignalMappingsDB)
			{
				ModelAnalogSignalMapping newAnalogMapping = new ModelAnalogSignalMapping()
				{
					Id = analogmapping.signal_id,
					Name = analogmapping.mapping_name,
					K = analogmapping.K,
					N = analogmapping.N
				};

				AnalogMappingsList.Add(newAnalogMapping);
			}
		}

		public ModelAnalogSignalMapping GetAnalogMappingByID(int id)
		{
			return AnalogMappingsList.SingleOrDefault(m => m.Id == id);
		}
	}
}
