using System.Collections.Generic;
using ModelWcfServiceLibrary.Model.Signals;

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
		public ModelRTUData RTUData { get; set; }
		/// <summary>
		/// List of all Analog signal for RTU
		/// </summary>
		[DataMember]
		public IEnumerable<ModelAnalogSignal> AnalogSignals { get; set; }
		/// <summary>
		/// List of all Discrete signal for RTU
		/// </summary>
		[DataMember]
		public IEnumerable<ModelDiscreteSignal> DiscreteSignals { get; set; }
    }
}
