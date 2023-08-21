using System.Collections.Generic;
using ModelWcfServiceLibrary.Model.Flags;
using ModelWcfServiceLibrary.Serializer;

namespace ModelWcfServiceLibrary.Repository
{
	/// <summary>
	/// Class for communication with a file where Flags static data are stored.
	/// </summary>
	public sealed class FlagRepository : IFlagRepository
	{
		private readonly IListSerializer<ModelFlag> serializer;

		/// <summary>
		/// Initializes a new instance of the <see cref="FlagRepository"/>
		/// </summary>
		/// <param name="serializer">Instance of the <see cref="IListSerializer"/> class</param>
		public FlagRepository(IListSerializer<ModelFlag> serializer)
		{
			this.serializer = serializer;
			FlagList = new List<ModelFlag>();
		}

		/// <summary>
		/// List of Flags read from a file. If <c>Deserialize()</c> method isn't called after instantiating the class, the list is going to be empty.
		/// </summary>
		public List<ModelFlag> FlagList { get; private set; }

		/// <summary>
		/// Saves the current state of the Flags to a file
		/// </summary>
		public void Serialize()
		{
			serializer.Serialize(FlagList);
		}

		/// <summary>
		///  Read Flags data from a file in the <c>DiscreteSignalMappingList</c>.
		/// </summary>
		public void Deserialize()
		{
			FlagList = serializer.Deserialize();
		}

	}
}
