using System;
using System.Threading.Tasks;
using Contracts.DTO;

namespace Contracts
{
	public interface IDynamicCacheClient
    {
		bool Connect();
		SignalValueDTO GetCurrentSignalValue(int signalId);
		void RtuChangesUnsubscribe(int rtuId);
		void SignalChangesUnsubscribe(int rtuId, int signalId);
		Task SubscribeToRtuChanges(int rtuId, Action<SignalChangeDTO> handleSignalChange);
		Task SubscribeToSignalChangesAsync(int rtuId, int signalId, Action<SignalChangeDTO> action);
	}
}
