using System.Collections.Generic;

namespace ModbusServiceLibrary.Model.SignalMapping
{
	/// <summary>
	/// Class <see cref="ModbusDiscreteSignalMapping"/> contains data required to convert from discrete signal value to signal state.
	/// </summary>
	public class ModbusDiscreteSignalMapping
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
		/// Dictionary which maps discrete signal value to signal state
		/// </summary>
		public Dictionary<byte, string> DiscreteValueToState { get; set; }

	}
}
