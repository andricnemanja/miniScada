namespace RedisDynamicCacheClientAdapter
{
	public class ChangedSignalData
	{
		public int RtuId { get; set; }
		public int SignalId { get; set; }

		public ChangedSignalData(int rtuId, int signalId)
		{
			RtuId = rtuId;
			SignalId = signalId;
		}
	}
}