using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ClientWpfApp.Model.RTU;
using ClientWpfApp.Model.Signals;
using ClientWpfApp.Model.SignalValues;

namespace ClientWpfApp.Services
{
    internal class ValuesReader
    {
        public void ReadValues(Collection<RTU> rtuList)
        {
            Parallel.ForEach(rtuList, rtu =>
            {
                if(rtu.Connection.Status)
                    ReadSingleRTU(rtu);
            });
        }


        public void ReadSingleRTU(RTU rtu)
        {
            foreach (DiscreteSignalValue signalValue in rtu.DiscreteSignalValues)
            {
				signalValue.Value = rtu.Connection.Client.ReadCoils(signalValue.DiscreteSignal.Address, 1)[0];
            }

            foreach (AnalogSignalValue signalValue in rtu.AnalogSignalValues)
            {
				signalValue.Value = rtu.Connection.Client.ReadSingleRegister(signalValue.AnalogSignal.Address);
            }
        }

    }
}
