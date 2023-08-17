using ModelWcfServiceLibrary.EntityDataModel;
using ModelWcfServiceLibrary.Model.SignalMapping;
using System.Collections.Generic;
using System.Linq;

namespace ModelWcfServiceLibrary.DatabaseRepository
{
	public class DatabaseDiscreteSignalMappingRepository : IDatabaseDiscreteSignalMappingRepository
	{
		MiniScadaDB miniScadaDB;

		public List<ModelDiscreteSignalMapping> DiscreteMappingsList { get; private set; }

		public DatabaseDiscreteSignalMappingRepository()
		{
			miniScadaDB = new MiniScadaDB();

			DiscreteMappingsList = new List<ModelDiscreteSignalMapping>();
		}

		public void MapFromDatabase()
		{
			List<DbMapping> signalMappingsDB = miniScadaDB.DbMappings.ToList();

			foreach (var discretemapping in signalMappingsDB)
			{
				if (discretemapping.mapping_type == 1)
				{
					Dictionary<byte, string> newDiscreteValueToStateDict = new Dictionary<byte, string>();

					List<DbDiscreteValueToState> valueToStateQuery = miniScadaDB.DbDiscreteValueToStates
						.Where(valueToState => valueToState.mapping_id == discretemapping.mapping_id)
						.ToList();

					foreach (var valueToState in valueToStateQuery)
					{
						newDiscreteValueToStateDict.Add(valueToState.discrete_value, valueToState.discrete_state);
					}

					ModelDiscreteSignalMapping newDiscreteMapping = new ModelDiscreteSignalMapping()
					{
						Id = discretemapping.mapping_id,
						Name = discretemapping.mapping_name,
						DiscreteValueToState = newDiscreteValueToStateDict
					};

					DiscreteMappingsList.Add(newDiscreteMapping);

				}
			}
		}

		public ModelDiscreteSignalMapping GetDiscreteMappingByID(int id)
		{
			return DiscreteMappingsList.SingleOrDefault(m => m.Id == id);
		}

	}
}
