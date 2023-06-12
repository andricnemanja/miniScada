namespace RedisDynamicCacheClientAdapter.StringManipulation
{
	public sealed class RedisStringParser
	{
		public ChangedSignalData ParseSubscriptionChannel(string channelName)
		{
			string[] channelNameArr = channelName.Split('.');
			int rtuId = int.Parse(channelNameArr[0].Split(':')[1]);
			int signalId = int.Parse(channelNameArr[2].Split(':')[1]);

			return new ChangedSignalData(rtuId, signalId);
		}
	}
}
