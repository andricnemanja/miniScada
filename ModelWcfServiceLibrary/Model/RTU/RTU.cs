using ModelWcfServiceLibrary.Model.Signals;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ModelWcfServiceLibrary.Model.RTU
{
	/// <summary>
	/// Class <c>RTU</c> models RTU.
	/// </summary>
	[DataContract]
	public class ModelRTU
    {
		/// <summary>
		/// Essential RTU data
		/// </summary>
		[DataMember]
		public RTUData RTUData { get; set; }
		/// <summary>
		/// List of all Analog signal for RTU
		/// </summary>
		[DataMember]
		public IEnumerable<AnalogSignal> AnalogSignals { get; set; }
		/// <summary>
		/// List of all Discrete signal for RTU
		/// </summary>
		[DataMember]
		public IEnumerable<DiscreteSignal> DiscreteSignals { get; set; }
    }
}
