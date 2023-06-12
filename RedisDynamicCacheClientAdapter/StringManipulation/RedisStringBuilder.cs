namespace RedisDynamicCacheClientAdapter.StringManipulation
{
	public sealed class RedisStringBuilder
	{
		public string GenerateSignalKeyName(int signalId)
		{
			return "signal:" + signalId;
		}

		public string GenerateSignalFlagListName(int signalId)
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

		public string GenerateRtuSubscriptionChannel(int rtuId)
		{
			return "rtu:" + rtuId + ".*";
		}

		public string GenerateSignalSubscriptionChannel(int rtuId, int signalId)
		{
			return "rtu:" + rtuId + "." + "*" + ".signal:" + signalId;
		}

		public string GenerateSignalTypeSubscriptionChannel(int rtuId, string signalType)
		{
			return "rtu:" + rtuId + "." + signalType + ".signal:*";
		}
	}
}
