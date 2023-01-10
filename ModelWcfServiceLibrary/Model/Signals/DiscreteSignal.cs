using System.Runtime.Serialization;
using ModelWcfServiceLibrary.Model.SignalMapping;

namespace ModelWcfServiceLibrary.Model.Signals
{
	/// <summary>
	/// Class models discrete signal of the RTU.
	/// </summary>
	[DataContract]
	public class DiscreteSignal
	{
		/// <summary>
		/// Unique identification number for digital signal.
		/// </summary>
		[DataMember]
		public int ID { get; set; }
		/// <summary>
		/// Name of the discrete signal.
		/// </summary>
		[DataMember]
		public string Name { get; set; }
		/// <summary>
		/// Digital signal address.
		/// </summary>
		[DataMember]
		public int Address { get; set; }
		/// <summary>
		/// Signal type, one bit or two bit signal.
		/// </summary>
		[DataMember]
		public DiscreteSignalType SignalType { get; set; }
		/// <summary>
		/// Discrete signal mapping ID.
		/// </summary>
		[DataMember]
		public int MappingId { get; set; }
	}
}
