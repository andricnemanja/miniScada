using DynamicCacheManager.Model;
using StackExchange.Redis;

namespace DynamicCacheManager
{
	public sealed class RedisDynamicCacheClient : IDynamicCacheClient
	{
		private IDatabase redisDatabase;
		private ISubscriber publisher;
		private readonly ISignalNameStringBuilder redisStringBuilder;

		public RedisDynamicCacheClient(ISignalNameStringBuilder redisStringBuilder)
		{
			this.redisStringBuilder = redisStringBuilder;
		}

		public void ConnectToDynamicCache()
		{
			var muxer = ConnectionMultiplexer.Connect(System.Configuration.ConfigurationManager.AppSettings["DynamicCacheAddress"]);
			redisDatabase = muxer.GetDatabase();
			publisher = muxer.GetSubscriber();
		}

		public void AddFlagToSignal(ISignal signal, string flag)
		{
			redisDatabase.ListRightPush(redisStringBuilder.GenerateSignaFlagListName(signal.Id), flag);
			publisher.Publish(redisStringBuilder.GenerateFlagChannelName(signal.RtuId, signal.GetType().Name, signal.Id), flag);
		}

		public void SaveSignalToCache(ISignal signal)
		{
			if (!redisDatabase.KeyExists(redisStringBuilder.GenerateSignalKeyName(signal.Id)))
			{
				redisDatabase.HashSet(redisStringBuilder.GenerateSignalKeyName(signal.Id), new HashEntry[]
				{
					new HashEntry("id", signal.Id),
					new HashEntry("signalType", signal.GetType().Name),
					new HashEntry("value", string.Empty),
				});
			}
		}

		public void ChangeSignalValue(ISignal signal, double newValue)
		{
			ChangeSignalValue(signal, newValue.ToString());
		}

		public void ChangeSignalValue(ISignal signal, string newValue)
		{
			redisDatabase.HashSet(redisStringBuilder.GenerateSignalKeyName(signal.Id), new HashEntry[]
			{
				new HashEntry("value", newValue)
			});
			publisher.Publish(redisStringBuilder.GenerateChannelName(signal.RtuId, signal.GetType().Name, signal.Id), newValue);
		}
	}
}