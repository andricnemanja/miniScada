using DynamicCacheManager.Model;

namespace DynamicCacheManager
{
	public interface IDynamicCacheClient
	{
		void ConnectToDynamicCache();
		void SaveSignalToCache(AnalogSignal analogSignal);
		void SaveSignalToCache(DiscreteSignal discreteSignal);
		void ChangeSignalValue(int rtuId, int signalId, double newValue);
		void ChangeSignalValue(int rtuId, int signalId, string newValue);
	}
}