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
			return "rtu:" + rtuId + "." + signalType + ":" + signalId;
		}

		public string GenerateFlagChannelName(int rtuId, string signalType, int signalId)
		{
			return "flags." + GenerateChannelName(rtuId, signalType, signalId) + ".add";
		}

		public string GenerateFlagChannelName(int rtuId)
		{
			return "flags." + "rtu:" + rtuId + ".rtuFlag.add";
		}

		public string GenerateRemovedFlagChannelName(int rtuId)
		{
			return "flags." + "rtu:" + rtuId + ".rtuFlag.remove";
		}

		public string GenerateRemovedFlagChannelName(int rtuId, string signalType, int signalId)
		{
			return "flags." + GenerateChannelName(rtuId, signalType, signalId) + ".remove";
		}

	}
}