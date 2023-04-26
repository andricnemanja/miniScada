using System;
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
		/// <summary>
		/// Analog signal mapping ID
		/// </summary>
		[DataMember]
		public int MappingId { get; set; }
		/// <summary>
		/// Indicates whether the signal is read only or read-write
		/// </summary>
		[DataMember]
		public SignalAccessType AccessType { get; set; }
		[DataMember]
		public double Deadband { get; set; }
		[DataMember]
		public TimeSpan StaleTime { get; set; }
	}
}
