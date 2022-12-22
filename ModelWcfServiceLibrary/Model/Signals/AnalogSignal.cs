using System.Runtime.Serialization;

namespace ModelWcfServiceLibrary.Model.Signals
{
	/// <summary>
	/// Class models analog signal of the RTU.
	/// </summary>
	[DataContract]
	public class AnalogSignal
    {
		/// <summary>
		/// Unique identification number for analog signal
		/// </summary>
		[DataMember]
		public int ID { get; set; }
		/// <summary>
		/// Analog signal address
		/// </summary>
		[DataMember]
		public int Address { get; set; }
		/// <summary>
		/// Name of the analog signal
		/// </summary>
		[DataMember]
		public string Name { get; set; }
    }
}
