using System.Collections.Generic;
using System.Linq;
using ModbusServiceLibrary.Model.SignalMapping;
using ModelWcfServiceLibrary.Serializer;

namespace ModbusServiceLibrary.Repository
{
	public class SignalMappingRepository : ISignalMappingRepository
	{
		private IListSerializer<SignalMapping> signalMappingSerializer;

		public SignalMappingRepository(IListSerializer<SignalMapping> signalMappingSerializer)
		{
			this.signalMappingSerializer = signalMappingSerializer;
		}

		public List<SignalMapping> SignalMappings { get; set; }

		public void Serialize()
		{
			signalMappingSerializer.Serialize(SignalMappings);
		}

		public void Deserialize()
		{
			SignalMappings = signalMappingSerializer.Deserialize();
		}

		public SignalMapping GetSignalMapingForSignal(int rtuId, int signalId)
		{
			return SignalMappings.FirstOrDefault(s => s.RtuId == rtuId && s.AnalogSignalId == signalId);
		}
	}
}
