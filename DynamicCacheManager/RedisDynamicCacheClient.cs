using DynamicCacheManager.Model;
using StackExchange.Redis;

namespace DynamicCacheManager
{
	public class RedisDynamicCacheClient : IDynamicCacheClient
	{
		private IDatabase redisDatabase;
		private ISubscriber publisher;
		private readonly RedisStringBuilder redisStringBuilder = new RedisStringBuilder();

		public void ConnectToDynamicCache()
		{
			var muxer = ConnectionMultiplexer.Connect("localhost:6379");
			redisDatabase = muxer.GetDatabase();
			publisher = muxer.GetSubscriber();
		}

		public void SaveSignalToCache(AnalogSignal analogSignal)
		{
			if (!redisDatabase.KeyExists(redisStringBuilder.GenerateSignalKeyName(analogSignal.Id)))
			{
				redisDatabase.HashSet(redisStringBuilder.GenerateSignalKeyName(analogSignal.Id), new HashEntry[]
				{
					new HashEntry("id", analogSignal.Id),
					new HashEntry("signalType", nameof(AnalogSignal)),
					new HashEntry("value", 0),
				});
			}
		}

		public void SaveSignalToCache(DiscreteSignal discreteSignal)
		{
			if (!redisDatabase.KeyExists(redisStringBuilder.GenerateSignalKeyName(discreteSignal.Id)))
			{
				redisDatabase.HashSet(redisStringBuilder.GenerateSignalKeyName(discreteSignal.Id), new HashEntry[]
				{
					new HashEntry("id", discreteSignal.Id),
					new HashEntry("signalType", nameof(DiscreteSignal)),
					new HashEntry("value", string.Empty),
				});
			}
		}

		public void ChangeSignalValue(int rtudId, int signalId, double newValue)
		{
			redisDatabase.HashSet(redisStringBuilder.GenerateSignalKeyName(signalId), new HashEntry[]
			{
				new HashEntry("value", newValue)
			});
			publisher.Publish(redisStringBuilder.GenerateChannelName(rtudId, "analogSignal", signalId), newValue);
		}

		public void ChangeSignalValue(int rtuId, int signalId, string newValue)
		{
			redisDatabase.HashSet(redisStringBuilder.GenerateSignalKeyName(signalId), new HashEntry[]
			{
				new HashEntry("value", newValue)
			});
			publisher.Publish(redisStringBuilder.GenerateChannelName(rtuId, "discreteSignal", signalId), newValue);
		}
	}
}