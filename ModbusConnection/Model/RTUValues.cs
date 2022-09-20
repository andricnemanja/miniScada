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
        public ObservableCollection<ISignal> AnalogSignals { get; set; }

        public IModbusClient ModbusClient { get; set; }

        public RTUValues()
        {
            DiscreteSignals = new ObservableCollection<ISignal>();
            AnalogSignals = new ObservableCollection<ISignal>();
        }

        public RTUValues(ObservableCollection<ISignal> discreteSignals, ObservableCollection<ISignal> analogSignals)
        {
            DiscreteSignals = discreteSignals;
            AnalogSignals = analogSignals;
        }
    }
}
