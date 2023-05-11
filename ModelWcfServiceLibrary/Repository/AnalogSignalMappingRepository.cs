using System.Collections.Generic;
using System.Linq;
using ModelWcfServiceLibrary.Model.SignalMapping;
using ModelWcfServiceLibrary.Serializer;

namespace ModelWcfServiceLibrary.Repository
{
	/// <summary>
	/// Class for communication with a file where RTU static data are stored.
	/// </summary>
	public sealed class AnalogSignalMappingRepository : IAnalogSignalMappingRepository
	{
		private readonly IListSerializer<ModelAnalogSignalMapping> serializer;

		/// <summary>
		/// Initializes a new instance of the <see cref="RtuRepository"/>
		/// </summary>
		/// <param name="rtuSerializer">Instance of the <see cref="IListSerializer"/> class</param>
		public AnalogSignalMappingRepository(IListSerializer<ModelAnalogSignalMapping> serializer)
		{
			this.serializer = serializer;
			AnalogSignalMappingList = new List<ModelAnalogSignalMapping>();
		}

		/// <summary>
		/// List of RTUs read from a file. If <c>Deserialize()</c> method isn't called after instantiating the class, the list is going to be empty.
		/// </summary>
		public List<ModelAnalogSignalMapping> AnalogSignalMappingList { get; private set; }

		/// <summary>
		/// Saves the current state of the RTUs to a file
		/// </summary>
		public void Serialize()
		{
			serializer.Serialize(AnalogSignalMappingList);
		}

		/// <summary>
		///  Read RTUs data from a file in the <c>DiscreteSignalMappingList</c>.
		/// </summary>
		public void Deserialize()
		{
			AnalogSignalMappingList = serializer.Deserialize();
		}

		/// <summary>
		/// Gets the Analog Signal Mapping with specified ID.
		/// </summary>
		/// <param name="id">Unique identification number for the signal mapping</param>
		/// <returns>Analog Signal Mapping with the given ID. If Mapping with that ID doesn't exist, it will return <c>null</c></returns>
		public ModelAnalogSignalMapping GetByID(int id)
		{
			return AnalogSignalMappingList.SingleOrDefault(t => t.Id == id);
		}
	}
}
