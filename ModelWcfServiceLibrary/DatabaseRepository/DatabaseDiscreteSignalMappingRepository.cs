using ModelWcfServiceLibrary.EntityDataModel;
using ModelWcfServiceLibrary.Model.SignalMapping;
using System.Collections.Generic;
using System.Linq;

namespace ModelWcfServiceLibrary.DatabaseRepository
{
	/// <summary>
	/// Class for communication with a file where RTU static data are stored.
	/// </summary>
	public class DatabaseDiscreteSignalMappingRepository : IDatabaseDiscreteSignalMappingRepository
	{
		/// <summary>
		/// Context class of the database.
		/// </summary>
		MiniScadaDBEntities miniScadaDB;

		/// <summary>
		/// List of all Discrete mappings.
		/// </summary>
		public List<ModelDiscreteSignalMapping> DiscreteMappingsList { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="DatabaseDiscreteSignalMappingRepository"/>.
		/// </summary>
		public DatabaseDiscreteSignalMappingRepository()
		{
			miniScadaDB = new MiniScadaDBEntities();

			DiscreteMappingsList = new List<ModelDiscreteSignalMapping>();
		}

		/// <summary>
		/// Maps data from database to the service model.
		/// </summary>
		public void MapFromDatabase()
		{
			List<DbMapping> signalMappingsDB = miniScadaDB.DbMappings.Include("DbDiscreteValueToStates").AsNoTracking().ToList();

			foreach (var discretemapping in signalMappingsDB)
			{
				if (discretemapping.K == null)
				{
					//Dictionary<byte, string> newDiscreteValueToStateDict = new Dictionary<byte, string>();

					//List<DbDiscreteValueToState> valueToStateQuery = miniScadaDB.DbDiscreteValueToStates
					//	.Where(valueToState => valueToState.mapping_id == discretemapping.mapping_id)
					//	.ToList();

					//foreach (var valueToState in valueToStateQuery)
					//{
					//	newDiscreteValueToStateDict.Add(valueToState.discrete_value, valueToState.discrete_state);
					//}

					//ModelDiscreteSignalMapping newDiscreteMapping = new ModelDiscreteSignalMapping()
					//{
					//	Id = discretemapping.mapping_id,
					//	Name = discretemapping.mapping_name,
					//	DiscreteValueToState = newDiscreteValueToStateDict
					//};

					ModelDiscreteSignalMapping newDiscreteMapping = discretemapping.ToModelDiscreteMapping();

					DiscreteMappingsList.Add(newDiscreteMapping);

				}
			}
		}

		/// <summary>
		/// Gets the Discrete Signal Mapping with specified ID.
		/// </summary>
		/// <param name="id">Unique identification number for the signal mapping</param>
		/// <returns>Discrete Signal Mapping with the given ID. If Mapping with that ID doesn't exist, it will return <c>null</c></returns>
		public ModelDiscreteSignalMapping GetDiscreteMappingByID(int id)
		{
			return DiscreteMappingsList.SingleOrDefault(m => m.Id == id);
		}

		/// <summary>
		/// Gets possible states for discrete signal.
		/// </summary>
		/// <param name="mappingId">Unique ID of the discrete mapping.</param>
		/// <returns></returns>
		public string[] GetDiscreteSignalPossibleStates(int mappingId)
		{
			ModelDiscreteSignalMapping mapping = DiscreteMappingsList.SingleOrDefault(m => m.Id == mappingId);
			if (mapping.DiscreteValueToState.Keys.Count == 2)
			{
				return mapping.DiscreteValueToState.Values.ToArray();
			}

			string[] possibleStates = new string[2];
			possibleStates[0] = mapping.DiscreteValueToState[1];
			possibleStates[1] = mapping.DiscreteValueToState[2];
			return possibleStates;

		}

	}
}
