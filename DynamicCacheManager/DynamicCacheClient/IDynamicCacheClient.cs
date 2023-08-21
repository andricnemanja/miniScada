using DynamicCacheManager.Model;

namespace DynamicCacheManager.DynamicCacheClient
{
	public interface IDynamicCacheClient
	{
		void ConnectToDynamicCache();
		void SaveRtuToCache(Rtu rtu);
		void AddSignalFlag(int rtuId, int signalId, Flag flag);
		void AddRtuFlag(int rtuId, Flag flag);
		void RemoveRtuFlag(int rtuId, Flag flag);
		void ChangeSignalValue(int rtuId, int signalId, string newValue);
		void PublishSignalChange(int rtuId, int signalId, string signalType, string newValue);
		void PublishNewSignalFlag(int rtuId, int signalId, string signalType, Flag flag);
		void PublishRemovedSignalFlag(int rtuId, int signalId, string signalType, Flag flag);
		void PublishNewRtuFlag(int rtuId, Flag flag);
		void PublishRemovedRtuFlag(int rtuId, Flag flag);
		string GetSignalValue(int rtuId, int signalId);
		bool DoesRtuHaveFlag(int rtudId, Flag flag);
		bool DoesSignalHaveFlag(int rtudId, int signalId, Flag flag);
		double GetAnalogSignalDeadband(int rtuId, int signalId);
	}
}