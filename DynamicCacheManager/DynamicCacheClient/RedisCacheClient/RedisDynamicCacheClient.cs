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
	//TODO Refactor class
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

		public void AddSignalFlag(int rtuId, int signalId, Flag flag)
		{
			Rtu rtu = FindRtu(rtuId);
			ISignal signal = FindSignal(rtuId, signalId);
			signal.Flags.Add(flag.ID);
			rtuRedisCollection.Update(rtu);
		}

		public void RemoveSignalFlag(int rtuId, int signalId, Flag flag)
		{
			Rtu rtu = FindRtu(rtuId);
			ISignal signal = FindSignal(rtuId, signalId);
			signal.Flags.Remove(flag.ID);
			rtuRedisCollection.Update(rtu);
		}

		public void SaveRtuToCache(Rtu rtu)
		{
			rtuRedisCollection = connectionProvider.RedisCollection<Rtu>();
			rtuRedisCollection.Insert(rtu);
			//connectionProvider.Connection.Set(rtu);
		}

		public void ChangeSignalValue(int rtuId, int signalId, string newValue)
		{
			Rtu rtu = FindRtu(rtuId);
			var signal = FindSignal(rtuId, signalId);
			signal.Value = newValue;
			rtuRedisCollection.Update(rtu);
		}

		public void AddRtuFlag(int rtuId, Flag flag)
		{
			Rtu rtu = FindRtu(rtuId);
			rtu.Flags.Add(flag.ID);
			rtuRedisCollection.Update(rtu);
		}

		public void RemoveRtuFlag(int rtuId, Flag flag)
		{
			Rtu rtu = FindRtu(rtuId);
			rtu.Flags.Remove(flag.ID);
			rtuRedisCollection.Update(rtu);
		}

		public void PublishSignalChange(int rtuId, int signalId, string signalType, string newValue)
		{
			publisher.Publish(redisStringBuilder.GenerateChannelName(rtuId, signalType, signalId), newValue);
		}

		public void PublishNewSignalFlag(int rtuId, int signalId, string signalType, Flag flag)
		{
			publisher.Publish(redisStringBuilder.GenerateFlagChannelName(rtuId, signalType, signalId), flag.ID);
		}

		public void PublishRemovedSignalFlag(int rtuId, int signalId, string signalType, Flag flag)
		{
			publisher.Publish(redisStringBuilder.GenerateRemovedFlagChannelName(rtuId, signalType, signalId), flag.ID);
		}

		public void PublishNewRtuFlag(int rtuId, Flag flag)
		{
			publisher.Publish(redisStringBuilder.GenerateFlagChannelName(rtuId), flag.ID);
		}

		public void PublishRemovedRtuFlag(int rtuId, Flag flag)
		{
			publisher.Publish(redisStringBuilder.GenerateRemovedFlagChannelName(rtuId), flag.ID);
		}

		public bool DoesRtuHaveFlag(int rtudId, Flag flag)
		{
			Rtu rtu = FindRtu(rtudId);
			return rtu.Flags.Contains(flag.ID);
		}

		public bool DoesSignalHaveFlag(int rtudId, int signalId, Flag flag)
		{
			ISignal signal = FindSignal(rtudId, signalId);
			return signal.Flags.Contains(flag.ID);
		}

		public string GetSignalValue(int rtuId, int signalId)
		{
			return FindSignal(rtuId, signalId).Value;
		}

		public double GetAnalogSignalDeadband(int rtuId, int signalId)
		{
			AnalogSignal signal = FindSignal(rtuId, signalId) as AnalogSignal;
			return signal.Deadband;
		}

		private Rtu FindRtu(int rtuId)
		{
			return rtuRedisCollection.SingleOrDefault(r => r.Id == rtuId);
		}

		private ISignal FindSignal(int rtuId, int signalId)
		{
			Rtu rtu = FindRtu(rtuId);
			ISignal signal = rtu.AnalogSignals.SingleOrDefault(s => s.Id == signalId);
			if (signal != null)
			{
				return signal;
			}
			signal = rtu.DiscreteSignals.SingleOrDefault(s => s.Id == signalId);
			return signal;
		}

	}
}