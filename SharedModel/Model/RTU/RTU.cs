using SharedModel.Model.Signals;
using System.Collections.Generic;

namespace SharedModel.Model.RTU
{
    public class RTU
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public string Address { get; set; }
        public int Port { get; set; }
        public IEnumerable<AnalogSignal> AnalogSignals { get; set; }
        public IEnumerable<DiscreteSignal> DiscreteSignals { get; set; }
    }
}
