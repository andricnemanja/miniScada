using System.Collections.Generic;

namespace ModelWcfServiceLibrary.Model.SignalMapping
{
	/// <summary>
	/// Class <see cref="ModelDiscreteSignalMapping"/> contains data required to represent signal physicly.
	/// </summary>
	public class ModelDiscreteSignalMapping
	{
		/// <summary>
		/// ID of the RTU.
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// Mapping name.
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Mapping for a 2-bit signal. 
		/// </summary>
		public Dictionary<byte, string> DiscreteValueToState { get; set; }

	}
}
