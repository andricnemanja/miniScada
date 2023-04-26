namespace DynamicCacheManager
{
	public sealed class RedisStringBuilder : ISignalNameStringBuilder
	{
		public string GenerateSignalKeyName(int signalId)
		{
			return "signal:" + signalId;
		}

		public string GenerateSignaFlagListName(int signalId)
		{
			return "signal:" + signalId + ":flags";
		}

		public string GenerateChannelName(int rtuId, string signalType, int signalId)
		{
			return "rtu:" + rtuId + "." + signalType + ".signal:" + signalId;
		}

		public string GenerateFlagChannelName(int rtuId, string signalType, int signalId)
		{
			return GenerateChannelName(rtuId, signalType, signalId) + ":flags";
		}
	}
}