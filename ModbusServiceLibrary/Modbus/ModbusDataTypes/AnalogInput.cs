using ModbusServiceLibrary.Modbus.ModbusClient;
using ModbusServiceLibrary.Modbus.ModbusConnection;

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

		public RtuConnectionResponse Read(IModbusClient modbusClient, out ushort readValue)
		{
			var commandState = modbusClient.ReadInputRegisters(RtuId, Address, 1, out ushort[] values);
			if (commandState == RtuConnectionResponse.CommandExecuted)
			{
				readValue = values[0];
			}
			else
			{
				readValue = 0;
			}
			return commandState;
		}

		public RtuConnectionResponse Write(IModbusClient modbusClient, int newValue)
		{
			return RtuConnectionResponse.UnsupportedCommand;
		}
	}
}
