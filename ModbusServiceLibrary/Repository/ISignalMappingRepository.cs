using System.Collections.Generic;
using ModbusServiceLibrary.Model.SignalMapping;

namespace ModbusServiceLibrary.Repository
{
	public interface ISignalMappingRepository
	{
		/// <summary>
		/// List of data that needs to be mapped.
		/// </summary>
		List<SignalMapping> SignalMappings { get; set; }

		/// <summary>
		/// Read serialized object from a JSON file.
		/// </summary>
		void Deserialize();

		/// <summary>
		/// Gets signal for mapping by it's RTU ID and it's analog signal ID.
		/// </summary>
		/// <param name="rtuId">ID of the RTU.</param>
		/// <param name="signalId">ID of the analog signal.</param>
		/// <returns>Instance of class <see cref="SignalMapping"/> contains data required to represent signal physicly.</returns>
		SignalMapping GetSignalMappingForSignal(int rtuId, int signalId);

		/// <summary>
		/// Serializes data from the JSON file.
		/// </summary>
		void Serialize();
	}
}