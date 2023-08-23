using ModelWcfServiceLibrary.Model.ScanPeriodMapping;

namespace ModelWcfServiceLibrary.EntityDataModel
{
	public partial class DbScanPeriod
	{
		public SignalScanPeriodMapping ToModel()
		{
			return new SignalScanPeriodMapping()
			{
				Id = this.scan_id,
				Name = this.scan_name,
				TimeStamp = this.scan_period
			};
		}
	}
}
