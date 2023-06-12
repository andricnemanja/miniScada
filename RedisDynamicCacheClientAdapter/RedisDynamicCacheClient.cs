using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Contracts;
using Contracts.DTO;
using RedisDynamicCacheClientAdapter.StringManipulation;
using StackExchange.Redis;

namespace RedisDynamicCacheClientAdapter
{
	/// <summary>
	/// Provides methods for communication with Redis dynamic cache
	/// </summary>
	[Export(typeof(IDynamicCacheClient))]
	public class RedisDynamicCacheClient : IDynamicCacheClient
	{
		private readonly RedisStringBuilder stringBuilder = new RedisStringBuilder();
		private readonly RedisStringParser stringParser = new RedisStringParser();
		private IDatabase redisDatabase;
		private ISubscriber subscriber;

		/// <summary>
		/// Connect to dynamic cache. Needs to be called before trying to use any other method.
		/// </summary>
		/// <returns>True if a connection is made, False if not</returns>
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

		/// <summary>
		/// Get current signal value from dynamic cache for signal with provided ID
		/// </summary>
		/// <param name="signalId">ID of signal that you want to read</param>
		/// <returns>DTO that holds signal id and value</returns>
		public SignalValueDTO GetCurrentSignalValue(int signalId)
		{
			string signalValue = redisDatabase.HashGet(stringBuilder.GenerateSignalKeyName(signalId), "value");
			return new SignalValueDTO(signalId, signalValue);
		}

		/// <summary>
		/// Subscribe to rtu changes
		/// </summary>
		/// <param name="rtuId">ID of rtu from which you want to receive changes</param>
		/// <param name="handleSignalChange">Handler to perform when signal change is received</param>
		public Task SubscribeToRtuChangesAsync(int rtuId, Action<SignalChangeDTO> handleSignalChange)
		{
			return SubscribeToChannel(stringBuilder.GenerateRtuSubscriptionChannel(rtuId), handleSignalChange);
		}

		/// <summary>
		/// Subscribe to signal changes
		/// </summary>
		/// <param name="rtuId">ID of rtu which contains signal you want to subscribe to</param>
		/// <param name="rtuId">ID of signal you want to subscribe to</param>
		/// <param name="handleSignalChange">Handler to perform when signal change is received</param>
		public Task SubscribeToSignalChangesAsync(int rtuId, int signalId, Action<SignalChangeDTO> handleSignalChange)
		{
			return SubscribeToChannel(stringBuilder.GenerateSignalSubscriptionChannel(rtuId, signalId), handleSignalChange);
		}

		/// <summary>
		/// Unsubscribe from changes for rtu with provided ID
		/// </summary>
		/// <param name="rtuId">ID of rtu that you want to unsubscribe from</param>
		public void UnsubscribeFromRtuChanges(int rtuId)
		{
			subscriber.Unsubscribe(stringBuilder.GenerateRtuSubscriptionChannel(rtuId));
		}

		/// <summary>
		/// Unsubscribe from changes for signal with provided ID
		/// </summary>
		/// <param name="rtuId">ID of rtu which contains signal you want to unsubscribe from</param>
		/// <param name="signalId">ID of signal you want to unsubscribe from</param>
		public void UnsubscribeFromSignalChanges(int rtuId, int signalId)
		{
			subscriber.Unsubscribe(stringBuilder.GenerateSignalSubscriptionChannel(rtuId, signalId));
		}

		private Task SubscribeToChannel(string subscriptionChannel, Action<SignalChangeDTO> handleSignalChange)
		{
			subscriber.SubscribeAsync(subscriptionChannel, (channel, newValue) =>
			{
				ChangedSignalData changedSignalData = stringParser.ParseSubscriptionChannel(channel);
				SignalChangeDTO changedSignalDTO = new SignalChangeDTO(changedSignalData.RtuId, changedSignalData.SignalId, newValue);
				handleSignalChange(changedSignalDTO);
			});
			return Task.CompletedTask;
		}
	}
}
