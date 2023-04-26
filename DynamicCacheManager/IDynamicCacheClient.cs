using DynamicCacheManager.Model;

namespace DynamicCacheManager
{
	public interface IDynamicCacheClient
	{
		void ConnectToDynamicCache();
		void AddFlagToSignal(ISignal signal, string flag);
		void SaveSignalToCache(ISignal signal);
		void ChangeSignalValue(ISignal signal, double newValue);
		void ChangeSignalValue(ISignal signal, string newValue);
	}
}