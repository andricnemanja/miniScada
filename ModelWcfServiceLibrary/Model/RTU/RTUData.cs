using System.Runtime.Serialization;

namespace ModelWcfServiceLibrary
{
	/// <summary>
	/// Class <c>RTUData</c> models data that the RTU contains.
	/// </summary>
	[DataContract]
	public class RTUData
	{
		/// <summary>
		/// Name of the RTU
		/// </summary>
		[DataMember]
		public string Name { get; set; }
		/// <summary>
		/// Unique identification number for RTU
		/// </summary>
		[DataMember]
		public int ID { get; set; }
		/// <summary>
		/// Ip address for RTU
		/// </summary>
		[DataMember]
		public string IpAddress { get; set; }
		/// <summary>
		/// Port at which RTU can be accessed
		/// </summary>
		[DataMember]
		public int Port { get; set; }
	}
}