using ModelWcfServiceLibrary.Model.Signals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelWcfServiceLibrary.Model.RTU
{
    public class RTU
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public string Address { get; set; }
        public int Port { get; set; }
        public IEnumerable<AnalogSignal> AnalogSignals { get; set; }
        public IEnumerable<DiscreteSignal> DiscredSignals{ get; set; }
    }
}
