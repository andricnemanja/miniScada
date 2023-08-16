using ModelWcfServiceLibrary.EntityDataModel;
using ModelWcfServiceLibrary.Model.SignalMapping;
using System.Collections.Generic;
using System.Linq;

namespace ModelWcfServiceLibrary.DatabaseRepository
{
	public class DatabaseDiscreteSignalMappingRepository : IDatabaseDiscreteSignalMappingRepository
	{
		MiniScadaDB MiniScadaDB;

		public List<ModelDiscreteSignalMapping> DiscreteMappingsList;

		public DatabaseDiscreteSignalMappingRepository()
		{
			MiniScadaDB = new MiniScadaDB();

			DiscreteMappingsList = new List<ModelDiscreteSignalMapping>();
		}

		public void MapFromDatabase()
		{
			List<DiscreteSignalMappingDB> discreteSignalMappingsDB = MiniScadaDB.DiscreteSignalMappings.ToList();

			foreach (var discretemapping in discreteSignalMappingsDB)
			{
				ModelDiscreteSignalMapping newDiscreteMapping = new ModelDiscreteSignalMapping()
				{
					Id = discretemapping.signal_id,
					Name = discretemapping.mapping_name,
					// DiscreteValueToState = discretemapping.DiscreteValueToStates
				};

				DiscreteMappingsList.Add(newDiscreteMapping);
			}
		}

		public ModelDiscreteSignalMapping GetDiscreteMappingByID(int id)
		{
			return DiscreteMappingsList.SingleOrDefault(m => m.Id == id);
		}

	}
}
