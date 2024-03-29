﻿using System.Collections.Generic;
using System.Linq;
using ModelWcfServiceLibrary.Model.SignalMapping;
using ModelWcfServiceLibrary.Serializer;

namespace ModelWcfServiceLibrary.Repository
{
	/// <summary>
	/// Class for communication with a file where RTU static data are stored.
	/// </summary>
	public sealed class DiscreteSignalMappingRepository : IDiscreteSignalMappingRepository
	{
		private readonly IListSerializer<ModelDiscreteSignalMapping> serializer;

		/// <summary>
		/// Initializes a new instance of the <see cref="DiscreteSignalMappingRepository"/>
		/// </summary>
		/// <param name="serializer">Instance of the <see cref="IListSerializer"/> class</param>
		public DiscreteSignalMappingRepository(IListSerializer<ModelDiscreteSignalMapping> serializer)
		{
			this.serializer = serializer;
			DiscreteSignalMappingList = new List<ModelDiscreteSignalMapping>();
		}

		/// <summary>
		/// List of RTUs read from a file. If <c>Deserialize()</c> method isn't called after instantiating the class, the list is going to be empty.
		/// </summary>
		public List<ModelDiscreteSignalMapping> DiscreteSignalMappingList { get; private set; }

		/// <summary>
		/// Saves the current state of the RTUs to a file
		/// </summary>
		public void Serialize()
		{
			serializer.Serialize(DiscreteSignalMappingList);
		}

		/// <summary>
		///  Read RTUs data from a file in the <c>DiscreteSignalMappingList</c>.
		/// </summary>
		public void Deserialize()
		{
			DiscreteSignalMappingList = serializer.Deserialize();
		}

		/// <summary>
		/// Gets the Analog Signal Mapping with specified ID.
		/// </summary>
		/// <param name="id">Unique identification number for the signal mapping</param>
		/// <returns>Analog Signal Mapping with the given ID. If Mapping with that ID doesn't exist, it will return <c>null</c></returns>
		public ModelDiscreteSignalMapping GetByID(int id)
		{
			return DiscreteSignalMappingList.SingleOrDefault(t => t.Id == id);
		}

		public string[] GetDiscreteSignalPossibleStates(int mappingId)
		{
			ModelDiscreteSignalMapping mapping = DiscreteSignalMappingList.SingleOrDefault(m => m.Id == mappingId);
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
