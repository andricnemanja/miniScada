using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Documents;
using ClientWpfApp.ModbusServiceReference;
using ClientWpfApp.Model.RTU;
using ClientWpfApp.Model.Signals;
using ClientWpfApp.Model.SignalValues;

namespace ClientWpfApp.Services
{
    public class RtuValuesReader
    {
        private readonly ModbusServiceReference.ModbusDuplexClient modbusDuplexClient;
        private readonly ObservableCollection<RTU> rtuList;

		public RtuValuesReader(ModbusDuplexClient modbusDuplexClient, ObservableCollection<RTU> rtuList)
		{
			this.modbusDuplexClient = modbusDuplexClient;
			this.rtuList = rtuList;
		}

		public void ReadValues()
        {
            Parallel.ForEach(rtuList, rtu =>
            {
                if(rtu.IsConnected)
                    ReadSingleRTU(rtu);
            });
        }


        public void ReadSingleRTU(RTU rtu)
        {
            foreach (DiscreteSignalValue signalValue in rtu.DiscreteSignalValues)
            {
                modbusDuplexClient.ReadDiscreteSignal(rtu.RTUData.ID, signalValue.DiscreteSignal.Address);

			}

            foreach (AnalogSignalValue signalValue in rtu.AnalogSignalValues)
            {
				modbusDuplexClient.ReadAnalogSignal(rtu.RTUData.ID, signalValue.AnalogSignal.Address);
			}
		}

    }
}
