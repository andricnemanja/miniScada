using DynamicCacheManager.Model;

namespace DynamicCacheManager.DynamicCacheClient
{
	public interface IDynamicCacheClient
	{
		void ConnectToDynamicCache();
		void SaveRtuToCache(Rtu rtu);
		void AddSignalFlag(ISignal signal, string flag);
		void SaveSignalToCache(ISignal signal);
		void ChangeSignalValue(ISignal signal, string newValue);
		void PublishSignalChange(ISignal signal, string newValue);
		void PublishNewSignalFlag(ISignal signal, string flag);
		string GetSignalValue(ISignal signal);
	}
}