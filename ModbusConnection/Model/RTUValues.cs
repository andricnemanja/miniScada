using ModbusConnection.Model.Signals;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusConnection.Model
{
    public class RTUValues
    {
        public ObservableCollection<ISignal> DiscreteSignals { get; set; }
        public IModbusClient ModbusClient { get; set; }

        public RTUValues()
        {
            DiscreteSignals = new ObservableCollection<ISignal>();
        }

        public RTUValues(ObservableCollection<ISignal> discreteSignals)
        {
            DiscreteSignals = discreteSignals;
        }

        public void SetModbusClientToSignals(IModbusClient client)
        {
            foreach(ISignal signal in DiscreteSignals)
                signal.ModbusClient = client;
        }

        public void UpdateSignals()
        {
            foreach(var signal in DiscreteSignals)
            {
                signal.Read();
            }
        }
    }
}
