using DynamicCacheManager.Model;

namespace DynamicCacheManager.DynamicCacheClient
{
	public interface IDynamicCacheClient
	{
		void ConnectToDynamicCache();
		void SaveRtuToCache(Rtu rtu);
		void AddSignalFlag(ISignal signal, string flag);
		void SaveSignalToCache(ISignal signal);
		void AddRtuFlag(int rtuId, Flag flag);
		void RemoveRtuFlag(int rtuId, Flag flag);
		void ChangeSignalValue(ISignal signal, string newValue);
		void PublishSignalChange(ISignal signal, string newValue);
		void PublishNewSignalFlag(ISignal signal, string flag);
		void PublishNewRtuFlag(int rtuId, Flag flag);
		void PublishRemovedRtuFlag(int rtuId, Flag flag);
		string GetSignalValue(ISignal signal);
		bool DoesRtuHaveFlag(int rtudId, Flag flag);
	}
}