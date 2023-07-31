using Contracts.DTO;

namespace RedisDynamicCacheClientAdapter.StringManipulation
{
	/// <summary>
	/// Provides methods for parsing subscription channels used in Redis database
	/// </summary>
	public sealed class RedisStringParser
	{
		/// <summary>
		/// Parse subscription channel returned from Redis pub-sub
		/// </summary>
		/// <param name="channelName">Channel returned from Redis pub-sub</param>
		/// <returns>Instance of <see cref="ChangedSignalData"/>. Class that consists of signal id and rtu id from subscription channel</returns>
		public ChangedSignalData ParseSubscriptionChannel(string channelName)
		{
			string[] channelNameArr = channelName.Split('.');
			int rtuId = int.Parse(channelNameArr[0].Split(':')[1]);
			int signalId = int.Parse(channelNameArr[2].Split(':')[1]);

			return new ChangedSignalData(rtuId, signalId);
		}

		public RtuFlagChannelData ParseRtuFlagChannel(string channelName)
		{
			string[] channelNameArr = channelName.Split('.');
			int rtuId = int.Parse(channelNameArr[1].Split(':')[1]);

			RtuFlagChannelData rtuFlagChannelData = new RtuFlagChannelData(rtuId);
			if (channelNameArr[2] == "remove")
			{
				rtuFlagChannelData.Operation = RtuFlagOperation.Remove;
			}

			return rtuFlagChannelData;
		}
	}
}
