using ModbusServiceLibrary.ModbusClient;

namespace ModbusServiceLibrary.Modbus.ModbusDataTypes
{
	public class AnalogInput : IAnalogPoint
	{
		public AnalogInput(int id, int signalId, int address, int mappingId, int rtuId)
		{
			Id = id;
			SignalId = signalId;
			Address = address;
			MappingId = mappingId;
			RtuId = rtuId;
		}

		public int Id { get; }
		public int SignalId { get; }
		public int RtuId { get; }
		public int Address { get; }
		public int MappingId { get; }

		public bool TryRead(IModbusClient modbusClient, out ushort readValue)
		{
			if(modbusClient.TryReadInputRegisters(RtuId, Address, 1, out ushort[] values))
			{
				readValue = values[0];
				return true;
			}
			readValue = 0;
			return false;
		}

		public bool TryWrite(IModbusClient modbusClient, int newValue)
		{
			return false;
		}
	}
}
