using System.Collections.ObjectModel;
using System.Linq;
using ClientWpfApp.Model.SignalValues;
using ClientWpfApp.ServiceClients;

namespace ClientWpfApp.Model
{
	public class RtuCache : IRtuCache
	{
		public ObservableCollection<RTU.RTU> RtuList { get; private set; }

		public RtuCache()
		{
			RtuList = new ObservableCollection<RTU.RTU>();
		}

		public void ReadRtuStaticData()
		{
			ModelServiceConverter modelServiceConverter = new ModelServiceConverter(new ModelServiceReference.ModelServiceClient());
			RtuList = modelServiceConverter.ReadAllRTUs();
		}

		public void UpdateAnalogSignalValue(int rtuId, int signalId, double newValue)
		{
			RTU.RTU rtu = FindRtu(rtuId);
			AnalogSignalValue analogSignalValue = FindAnalogSignalValue(rtu, signalId);
			analogSignalValue.Value = newValue;
		}

		public void UpdateDiscreteSignalValue(int rtuId, int signalId, string newState)
		{
			RTU.RTU rtu = FindRtu(rtuId);
			DiscreteSignalValue discreteSignalValue = FindDiscreteSignalValue(rtu, signalId);
			discreteSignalValue.State = newState;
		}


		private RTU.RTU FindRtu(int rtuId)
		{
			return RtuList.Where(r => r.RTUData.ID == rtuId).FirstOrDefault();
		}

		private AnalogSignalValue FindAnalogSignalValue(RTU.RTU rtu, int signalId)
		{
			return rtu.AnalogSignalValues.Where(s => s.AnalogSignal.ID == signalId).FirstOrDefault();
		}
		private DiscreteSignalValue FindDiscreteSignalValue(RTU.RTU rtu, int signalId)
		{
			return rtu.DiscreteSignalValues.Where(s => s.DiscreteSignal.ID == signalId).FirstOrDefault();
		}
	}
}
