namespace DynamicCacheManager
{
	public class RedisStringBuilder
	{
		public string GenerateSignalKeyName(int signalId)
		{
			return "signal:" + signalId;
		}

		public string GenerateChannelName(int rtuId, string signalType, int signalId)
		{
			return "rtu:" + rtuId + "." + signalType + ".signal:" + signalId;
		}
	}
}