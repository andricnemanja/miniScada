using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Contracts;
using Contracts.DTO;
using RedisDynamicCacheClientAdapter.StringManipulation;
using StackExchange.Redis;

namespace RedisDynamicCacheClientAdapter
{
	[Export(typeof(IDynamicCacheClient))]
	public class RedisDynamicCacheClient : IDynamicCacheClient
	{
		private readonly RedisStringBuilder stringBuilder = new RedisStringBuilder();
		private readonly RedisStringParser stringParser = new RedisStringParser();
		private IDatabase redisDatabase;
		private ISubscriber subscriber;

		public bool Connect()
		{
			try
			{
				var muxer = ConnectionMultiplexer.Connect("localhost:6379");
				redisDatabase = muxer.GetDatabase();
				subscriber = muxer.GetSubscriber();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public Task SubscribeToRtuChanges(int rtuId, Action<SignalChangeDTO> handleSignalChange)
		{
			subscriber.SubscribeAsync(stringBuilder.GenerateRtuSubscriptionChannel(rtuId), (channel, newValue) =>
			{
				ChangedSignalData changedSignalData = stringParser.ParseSubscriptionChannel(channel);
				SignalChangeDTO changedSignalDTO = new SignalChangeDTO(changedSignalData.RtuId, changedSignalData.SignalId, newValue);
				handleSignalChange(changedSignalDTO);
			});
			return Task.CompletedTask;
		}

		public Task SubscribeToSignalChangesAsync(int rtuId, int signalId, Action<SignalChangeDTO> action)
		{
			throw new NotImplementedException();
		}

		public SignalValueDTO GetCurrentSignalValue(int signalId)
		{
			string signalValue = redisDatabase.HashGet(stringBuilder.GenerateSignalKeyName(signalId), "value");
			return new SignalValueDTO(signalId, signalValue);
		}

		public void RtuChangesUnsubscribe(int rtuId)
		{
			throw new NotImplementedException();
		}

		public void SignalChangesUnsubscribe(int rtuId, int signalId)
		{
			throw new NotImplementedException();
		}
	}
}
