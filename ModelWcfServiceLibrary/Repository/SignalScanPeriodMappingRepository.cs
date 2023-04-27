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
		private readonly IListSerializer<SignalScanPeriodMapping> serializer;

		public SignalScanPeriodMappingRepository(IListSerializer<SignalScanPeriodMapping> serializer)
		{
			this.serializer = serializer;
			SignalScanPeriodMappingList = new List<SignalScanPeriodMapping>();
		}

		public List<SignalScanPeriodMapping> SignalScanPeriodMappingList { get; private set; }

		public void Serialize()
		{
			serializer.Serialize(SignalScanPeriodMappingList);
		}

		public void Deserialize()
		{
			SignalScanPeriodMappingList = serializer.Deserialize();
		}

		public SignalScanPeriodMapping GetByID(int id)
		{
			return SignalScanPeriodMappingList.SingleOrDefault(m => m.Id == id);
		}
	}
}
