namespace RedisDynamicCacheClientAdapter.StringManipulation
{
	/// <summary>
	/// Provides methods for generating key names and subscription channels used in Redis database
	/// </summary>
	public sealed class RedisStringBuilder
	{
		/// <summary>
		/// Generates key name that points to signal with provided ID in Redis database
		/// </summary>
		/// <param name="signalId">Unique identifier for signal</param>
		/// <returns>Signal key in Redis database</returns>
		public string GenerateSignalKeyName(int signalId)
		{
			return "signal:" + signalId;
		}

		/// <summary>
		/// Generates key name that points to list of flags for signal provided ID in Redis database
		/// </summary>
		/// <param name="signalId">Unique identifier for signal</param>
		/// <returns>Flag list key in Redis database</returns>
		public string GenerateSignalFlagListName(int signalId)
		{
			return "signal:" + signalId + ":flags";
		}

		/// <summary>
		/// Generates subscription channel name for the signal with provided ID
		/// </summary>
		/// <param name="rtuId">Unique identifier for RTU</param>
		/// <param name="signalType">Type of signal. Can be 'AnalogSignal' or 'DiscreteSignal'</param>
		/// <param name="signalId">Unique identifier for signal</param>
		/// <returns>Subscription channel name</returns>
		public string GenerateChannelName(int rtuId, string signalType, int signalId)
		{
			return "rtu:" + rtuId + "." + signalType + ".signal:" + signalId;
		}

		/// <summary>
		/// Generates subscription channel name for the signal flags with provided ID
		/// </summary>
		/// <param name="rtuId">Unique identifier for RTU</param>
		/// <param name="signalType">Type of signal. Can be 'AnalogSignal' or 'DiscreteSignal'</param>
		/// <param name="signalId">Unique identifier for signal</param>
		/// <returns>Subscription channel name</returns>
		public string GenerateFlagChannelName(int rtuId, string signalType, int signalId)
		{
			return "flags." + GenerateChannelName(rtuId, signalType, signalId);
		}

		public string GenerateFlagChannelName(int rtuId)
		{
			return "flags." + "rtu:" + rtuId + ".*";
		}

		/// <summary>
		/// Generates subscription channel name for entire rtu with provided ID
		/// </summary>
		/// <param name="rtuId">Unique identifier for RTU</param>
		/// <returns>Subscription channel name</returns>
		public string GenerateRtuSubscriptionChannel(int rtuId)
		{
			return "rtu:" + rtuId + ".*";
		}

		/// <summary>
		/// Generates subscription channel name for the signal with provided ID
		/// </summary>
		/// <param name="rtuId">Unique identifier for RTU</param>
		/// <param name="signalId">Unique identifier for signal</param>
		/// <returns>Subscription channel name</returns>
		public string GenerateSignalSubscriptionChannel(int rtuId, int signalId)
		{
			return "rtu:" + rtuId + "." + "*" + ".signal:" + signalId;
		}

		/// <summary>
		/// Generates subscription channel name for the signal that is of the <paramref name="signalType"/> type
		/// </summary>
		/// <param name="rtuId">Unique identifier for RTU</param>
		/// <param name="signalType">Type of signal. Can be 'AnalogSignal' or 'DiscreteSignal'</param>
		/// <returns>Subscription channel name</returns>
		public string GenerateSignalTypeSubscriptionChannel(int rtuId, string signalType)
		{
			return "rtu:" + rtuId + "." + signalType + ".signal:*";
		}
	}
}
