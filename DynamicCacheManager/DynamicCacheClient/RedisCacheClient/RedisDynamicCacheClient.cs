using System;
using System.Linq;
using DynamicCacheManager.Model;
using Polly;
using Polly.Retry;
using Redis.OM;
using Redis.OM.Searching;
using StackExchange.Redis;

namespace DynamicCacheManager.DynamicCacheClient.RedisCacheClient
{
	public sealed class RedisDynamicCacheClient : IDynamicCacheClient
	{
		private IDatabase redisDatabase;
		private ISubscriber publisher;
		private RedisConnectionProvider connectionProvider;
		private IRedisCollection<Rtu> rtuRedisCollection;
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

			connectionProvider = new RedisConnectionProvider("redis://localhost:6379");
			//var listOfIndexes = connectionProvider.Connection.Execute("FT._LIST").ToArray();
			//if (!listOfIndexes.Any(x => x == "rtu-idx"))
			//{
			connectionProvider.Connection.DropIndex(typeof(Rtu));
			connectionProvider.Connection.CreateIndex(typeof(Rtu));
			//}
		}

		public void AddSignalFlag(ISignal signal, string flag)
		{
			redisDatabase.ListRightPush(redisStringBuilder.GenerateSignaFlagListName(signal.Id), flag);
		}

		public void SaveRtuToCache(Rtu rtu)
		{
			rtuRedisCollection = connectionProvider.RedisCollection<Rtu>();
			rtuRedisCollection.Insert(rtu);
			//connectionProvider.Connection.Set(rtu);
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
			Rtu rtu = FindRtu(signal.RtuId);

			if (signal.GetType() == typeof(AnalogSignal))
			{
				AnalogSignal analogSignal = rtu.AnalogSignals.SingleOrDefault(s => s.Id == signal.Id);
				analogSignal.Value = newValue;
				rtuRedisCollection.Update(rtu);
				return;
			}

			DiscreteSignal discreteSignal = rtu.DiscreteSignals.SingleOrDefault(s => s.Id == signal.Id);
			discreteSignal.Value = newValue;
			rtuRedisCollection.Update(rtu);
		}

		public void AddRtuFlag(int rtuId, string flag)
		{
			Rtu rtu = FindRtu(rtuId);
			rtu.Flags.Add(flag);
			rtuRedisCollection.Update(rtu);
		}

		public void RemoveRtuFlag(int rtuId, string flag)
		{
			Rtu rtu = FindRtu(rtuId);
			rtu.Flags.Remove(flag);
			rtuRedisCollection.Update(rtu);
		}

		public void PublishSignalChange(ISignal signal, string newValue)
		{
			publisher.Publish(redisStringBuilder.GenerateChannelName(signal.RtuId, signal.GetType().Name, signal.Id), newValue);
		}

		public void PublishNewSignalFlag(ISignal signal, string flag)
		{
			publisher.Publish(redisStringBuilder.GenerateFlagChannelName(signal.RtuId, signal.GetType().Name, signal.Id), flag);
		}

		public void PublishNewRtuFlag(int rtuId, string flag)
		{
			publisher.Publish(redisStringBuilder.GenerateFlagChannelName(rtuId), flag);
		}

		public void PublishRemovedRtuFlag(int rtuId, string flag)
		{
			publisher.Publish(redisStringBuilder.GenerateRemovedFlagChannelName(rtuId), flag);
		}

		public bool DoesRtuHaveFlag(int rtudId, string flag)
		{
			Rtu rtu = FindRtu(rtudId);
			return rtu.Flags.Contains(flag);
		}

		public string GetSignalValue(ISignal signal)
		{
			Rtu rtu = FindRtu(signal.RtuId);
			ISignal selectedSignal;
			if (signal.GetType() == typeof(AnalogSignal))
			{
				selectedSignal = rtu.AnalogSignals.SingleOrDefault(s => s.Id == signal.Id);
			}
			else
			{
				selectedSignal = rtu.DiscreteSignals.SingleOrDefault(s => s.Id == signal.Id);
			}
			return selectedSignal.Value;
		}



		private Rtu FindRtu(int rtuId)
		{
			return rtuRedisCollection.SingleOrDefault(r => r.Id == rtuId);
		}
	}
}