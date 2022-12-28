using System.Collections.Generic;
using ModbusServiceLibrary.Model.SignalMapping;

namespace ModbusServiceLibrary.Repository
{
	public interface ISignalMappingRepository
	{
		List<SignalMapping> SignalMappings { get; set; }

		void Deserialize();
		SignalMapping GetSignalMapingForSignal(int rtuId, int signalId);
		void Serialize();
	}
}