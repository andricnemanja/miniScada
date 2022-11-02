using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SharedModel.Model.RTU;
using SharedModel.Model.Signals;

namespace ClientWpfApp.Services
{
    internal class ValuesReadingService
    {
        public void ReadValues(Collection<RTU> rtuList)
        {
            /*
            Parallel.ForEach(rtuList, rtu =>
            {
                if(rtu.Connection.Status)
                    ReadSingleRTU(rtu);
            });
            */
        }


        public void ReadSingleRTU(RTU rtu)
        {
            /*
            foreach (DiscreteSignal signal in rtu.Values.DiscreteSignals)
            {
                signal.Value = rtu.Connection.Client.ReadCoils(signal.Address, 1)[0];
            }

            foreach (AnalogSignal signal in rtu.Values.AnalogSignals)
            {
                signal.Value = rtu.Connection.Client.ReadSingleRegister(signal.Address);
            }
            */
        }

    }
}
