using ModelWcfServiceLibrary.Model.ScanPeriodMapping;
using System.Collections.Generic;

namespace ModelWcfServiceLibrary.Repository
{
	public interface ISignalScanPeriodMappingRepository
	{
		List<SignalScanPeriodMapping> SignalScanPeriodMappingList { get; }

		void Deserialize();
		SignalScanPeriodMapping GetByID(int id);
		void Serialize();
	}
}