using System;
using DynamicCacheManager.Model;
using Polly;
using Polly.Retry;
using StackExchange.Redis;

namespace DynamicCacheManager.DynamicCacheClient.RedisCacheClient
{
	public sealed class RedisDynamicCacheClient : IDynamicCacheClient
	{
		private IDatabase redisDatabase;
		private ISubscriber publisher;
		private readonly ISignalNameStringBuilder redisStringBuilder;
		private readonly RetryPolicy retryPolicy = Policy
			.Handle<RedisConnectionException>()
			.WaitAndRetryForever(retryAttemp => TimeSpan.FromSeconds(5));

		public RedisDynamicCacheClient(ISignalNameStringBuilder redisStringBuilder)
		{
			this.redisStringBuilder = redisStringBuilder;
		}

		public void ConnectToDynamicCache()
		{
			var muxer = retryPolicy.Execute(() =>
			{
				return ConnectionMultiplexer.Connect(System.Configuration.ConfigurationManager.AppSettings["DynamicCacheAddress"]);
			});
			redisDatabase = muxer.GetDatabase();
			publisher = muxer.GetSubscriber();
		}

		public void AddSignalFlag(ISignal signal, string flag)
		{
			redisDatabase.ListRightPush(redisStringBuilder.GenerateSignaFlagListName(signal.Id), flag);
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

		public void ChangeSignalValue(ISignal signal, string newValue)
		{
			redisDatabase.HashSet(redisStringBuilder.GenerateSignalKeyName(signal.Id), new HashEntry[]
			{
				new HashEntry("value", newValue)
			});
		}

		public void PublishSignalChange(ISignal signal, string newValue)
		{
			publisher.Publish(redisStringBuilder.GenerateChannelName(signal.RtuId, signal.GetType().Name, signal.Id), newValue);
		}

		public void PublishNewSignalFlag(ISignal signal, string flag)
		{
			publisher.Publish(redisStringBuilder.GenerateFlagChannelName(signal.RtuId, signal.GetType().Name, signal.Id), flag);
		}

		public string GetSignalValue(ISignal signal)
		{
			if (!redisDatabase.KeyExists(redisStringBuilder.GenerateSignalKeyName(signal.Id)))
			{
				return string.Empty;
			}
			return redisDatabase.HashGet(redisStringBuilder.GenerateSignalKeyName(signal.Id), "value");
		}
	}
}