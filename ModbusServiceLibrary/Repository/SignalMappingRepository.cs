using System.Collections.Generic;
using System.Linq;
using ModbusServiceLibrary.Model.SignalMapping;
using ModelWcfServiceLibrary.Serializer;

namespace ModbusServiceLibrary.Repository
{
	/// <summary>
	/// Class containg list of data that needs to be mapped in order to convert signal values.
	/// </summary>
	public class SignalMappingRepository : ISignalMappingRepository
	{
		private IListSerializer<SignalMapping> signalMappingSerializer;

		/// <summary>
		/// Initializes a new instance of the <see cref="SignalMappingRepository"/>
		/// </summary>
		/// <param name="signalMappingSerializer">Instance of the <see cref="IListSerializer"/> class</param>
		public SignalMappingRepository(IListSerializer<SignalMapping> signalMappingSerializer)
		{
			this.signalMappingSerializer = signalMappingSerializer;
		}

		/// <summary>
		/// List of data that needs to be mapped.
		/// </summary>
		public List<SignalMapping> SignalMappings { get; set; }

		/// <summary>
		/// Serializes data to the JSON file.
		/// </summary>
		public void Serialize()
		{
			signalMappingSerializer.Serialize(SignalMappings);
		}

		/// <summary>
		/// Deserializes data from JSON file.
		/// </summary>
		public void Deserialize()
		{
			SignalMappings = signalMappingSerializer.Deserialize();
		}

		/// <summary>
		/// Gets signal for mapping by it's RTU ID and it's analog signal ID.
		/// </summary>
		/// <param name="rtuId">ID of the RTU.</param>
		/// <param name="signalId">ID of the analog signal.</param>
		/// <returns>Instance of class <see cref="SignalMapping"/> contains data required to represent signal physicly.</returns>
		public SignalMapping GetSignalMappingForSignal(int rtuId, int signalAddress)
		{
			return SignalMappings.FirstOrDefault(s => s.RtuId == rtuId && s.AnalogSignalAddress == signalAddress);
		}

		public string GetSignalUnit(int rtuId, int signalAddress)
		{
			return GetSignalMappingForSignal(rtuId, signalAddress).Unit;
		}
	}
}
