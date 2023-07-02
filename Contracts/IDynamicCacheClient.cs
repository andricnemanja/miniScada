using System;
using System.Threading.Tasks;
using Contracts.DTO;

namespace Contracts
{
	/// <summary>
	/// Provides methods for communication with dynamic cache
	/// </summary>
	public interface IDynamicCacheClient
	{
		/// <summary>
		/// Connect to dynamic cache. Needs to be called before trying to use any other method.
		/// </summary>
		/// <returns>True if a connection is made, False if not</returns>
		bool Connect();
		/// <summary>
		/// Disconnect from dynamic cache.
		/// </summary>
		void Disconnect();
		/// <summary>
		/// Check if dynamic cache is available
		/// </summary>
		/// <returns>True if a dynamic cache is available, False if not</returns>
		bool IsAvailable();
		/// <summary>
		/// Get current signal value from dynamic cache for signal with provided ID
		/// </summary>
		/// <param name="signalId">ID of signal that you want to read</param>
		/// <returns>DTO that holds signal id and value</returns>
		SignalValueDTO GetCurrentSignalValue(int signalId);
		/// <summary>
		/// Unsubscribe from changes for rtu with provided ID
		/// </summary>
		/// <param name="rtuId">ID of rtu that you want to unsubscribe from</param>
		void UnsubscribeFromRtuChanges(int rtuId);
		/// <summary>
		/// Unsubscribe from changes for signal with provided ID
		/// </summary>
		/// <param name="rtuId">ID of rtu which contains signal you want to unsubscribe from</param>
		/// <param name="signalId">ID of signal you want to unsubscribe from</param>
		void UnsubscribeFromSignalChanges(int rtuId, int signalId);
		/// <summary>
		/// Subscribe to rtu changes
		/// </summary>
		/// <param name="rtuId">ID of rtu from which you want to receive changes</param>
		/// <param name="handleSignalChange">Handler to perform when signal change is received</param>
		Task SubscribeToRtuChangesAsync(int rtuId, Action<SignalChangeDTO> handleSignalChange, Action<RtuFlagDTO> handleNewFlag);
		/// <summary>
		/// Subscribe to signal changes
		/// </summary>
		/// <param name="rtuId">ID of rtu which contains signal you want to subscribe to</param>
		/// <param name="rtuId">ID of signal you want to subscribe to</param>
		/// <param name="handleSignalChange">Handler to perform when signal change is received</param>
		Task SubscribeToSignalChangesAsync(int rtuId, int signalId, Action<SignalChangeDTO> handleSignalChange);
	}
}
