using DynamicCacheManager.Model;

namespace DynamicCacheManager.DynamicCacheClient
{
	public interface IDynamicCacheClient
	{
		void ConnectToDynamicCache();
		void SaveRtuToCache(Rtu rtu);
		void AddSignalFlag(ISignal signal, string flag);
		void SaveSignalToCache(ISignal signal);
		void AddRtuFlag(int rtuId, string flag);
		void RemoveRtuFlag(int rtuId, string flag);
		void ChangeSignalValue(ISignal signal, string newValue);
		void PublishSignalChange(ISignal signal, string newValue);
		void PublishNewSignalFlag(ISignal signal, string flag);
		void PublishNewRtuFlag(int rtuId, string flag);
		void PublishRemovedRtuFlag(int rtuId, string flag);
		string GetSignalValue(ISignal signal);
		bool DoesRtuHaveFlag(int rtudId, string flag);
	}
}