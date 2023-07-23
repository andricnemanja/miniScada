using ModelWcfServiceLibrary.Model.ScanPeriodMapping;
using ModelWcfServiceLibrary.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelWcfServiceLibrary.Repository
{
	public sealed class SignalScanPeriodMappingRepository : ISignalScanPeriodMappingRepository
	{
		/// <summary>
		/// Provides functionality to serialize and deserialize <see cref="SignalScanPeriodMapping"/> list to JSON file
		/// </summary>
		private readonly IListSerializer<SignalScanPeriodMapping> serializer;

		/// <summary>
		/// List of the SignalScanPeriodMappings.
		/// </summary>
		public List<SignalScanPeriodMapping> SignalScanPeriodMappingList { get; private set; }

		public SignalScanPeriodMappingRepository(IListSerializer<SignalScanPeriodMapping> serializer)
		{
			this.serializer = serializer;
			SignalScanPeriodMappingList = new List<SignalScanPeriodMapping>();
		}

		/// <summary>
		/// Saves the current state of the List to a JSON file.
		/// </summary>
		public void Serialize()
		{
			serializer.Serialize(SignalScanPeriodMappingList);
		}

		/// <summary>
		/// Deserializes list from its JSON file.
		/// </summary>
		public void Deserialize()
		{
			SignalScanPeriodMappingList = serializer.Deserialize();
		}

		/// <summary>
		/// Gets a certain mapping by its ID.
		/// </summary>
		/// <param name="id">ID of the scan period mapping.</param>
		/// <returns>Signal scan period mapping.</returns>
		public SignalScanPeriodMapping GetByID(int id)
		{
			return SignalScanPeriodMappingList.SingleOrDefault(m => m.Id == id);
		}
	}
}
