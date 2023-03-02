using ModbusServiceLibrary.ModbusClient;

namespace ModbusServiceLibrary.Modbus.ModbusDataTypes
{
	internal class AnalogInput : IAnalogPoint
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

		public ushort Read(IModbusClient modbusClient)
		{
			modbusClient.TryReadInputRegisters(RtuId, Address, 1, out ushort[] values);
			return values[0];
		}

		public bool TryWrite(IModbusClient modbusClient, int newValue)
		{
			return false;
		}
	}
}
