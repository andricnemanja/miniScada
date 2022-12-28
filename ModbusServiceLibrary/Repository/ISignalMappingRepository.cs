using System.Collections.Generic;
using ModbusServiceLibrary.Model.SignalMapping;

namespace ModbusServiceLibrary.Repository
{
	public interface ISignalMappingRepository
	{
		List<SignalMapping> SignalMappings { get; set; }

		void Deserialize();
		SignalMapping GetSignalMappingForSignal(int rtuId, int signalAddress);
		string GetSignalUnit(int rtuId, int signalAddress);
		void Serialize();
	}
}