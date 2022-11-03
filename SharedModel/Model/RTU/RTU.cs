using SharedModel.Model.Signals;
using System.Collections.Generic;

namespace SharedModel.Model.RTU
{
    public class RTU
    {
		/// <summary>
		/// Name of the RTU
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Unique identification number for RTU
		/// </summary>
		public int ID { get; set; }
		/// <summary>
		/// Ip address for RTU
		/// </summary>
		public string IpAddress { get; set; }
		/// <summary>
		/// Port at which RTU can be accessed
		/// </summary>
		public int Port { get; set; }
		/// <summary>
		/// List of all Analog signal for RTU
		/// </summary>
		public IEnumerable<AnalogSignal> AnalogSignals { get; set; }
		/// <summary>
		/// List of all Discrete signal for RTU
		/// </summary>
		public IEnumerable<DiscreteSignal> DiscreteSignals { get; set; }
    }
}
