using System.Runtime.Serialization;

namespace ModelWcfServiceLibrary.Model.Signals
{
	[DataContract]
	public class DiscreteSignal
	{
		/// <summary>
		/// Unique identification number for digital signal
		/// </summary>
		[DataMember]
		public int ID { get; set; }
		/// <summary>
		/// Digital signal address
		/// </summary>
		[DataMember]
		public int Address { get; set; }
		/// <summary>
		/// Name of the discrete signal
		/// </summary>
		[DataMember]
		public string Name { get; set; }
	}
}
