using System.Collections.Generic;
using ModelWcfServiceLibrary.Model.Signals;

namespace ModelWcfServiceLibrary.Model.RTU
{
	/// <summary>
	/// Class <c>RTU</c> models RTU.
	/// </summary>
	public class RTU
    {
		/// <summary>
		/// Essential RTU data
		/// </summary>
		public RTUData RTUData { get; set; }
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
