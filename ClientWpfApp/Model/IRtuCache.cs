using System.Collections.ObjectModel;
using ClientWpfApp.Model.Flags;

namespace ClientWpfApp.Model
{
	public interface IRtuCache
	{
		ObservableCollection<RTU.RTU> RtuList { get; }
		void ReadRtuStaticData();
		void UpdateAnalogSignalValue(int rtuId, int signalId, double newValue);
		void UpdateDiscreteSignalValue(int rtuId, int signalId, string newState);
		void UpdateSignalValue(int rtuId, int signalId, string newValue);
		void AddFlagToRtu(int rtuId, Flag flag);
		void RemoveFlagFromRtu(int rtuId, Flag flag);
		RTU.RTU FindRtu(int rtuId);
	}
}