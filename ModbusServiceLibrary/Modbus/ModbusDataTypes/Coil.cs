using ModbusServiceLibrary.Modbus.ModbusClient;
using ModbusServiceLibrary.Modbus.ModbusConnection;

namespace ModbusServiceLibrary.Modbus.ModbusDataTypes
{
	public class Coil : IDigitalPoint
	{
		public Coil(int id, int signalId, int address, int mappingId, byte length, int rtuId)
		{
			Id = id;
			SignalId = signalId;
			Address = address;
			MappingId = mappingId;
			Length = length;
			RtuId = rtuId;
		}

		public int Id { get; }
		public int SignalId { get; }
		public int RtuId { get; }
		public int Address { get; }
		public int MappingId { get; }
		public byte Length { get; }

		public RtuConnectionResponse Read(IModbusClient modbusClient, out byte readValue)
		{
			var commandState = modbusClient.ReadCoils(RtuId, Address, Length, out bool[] values);
			if (commandState == RtuConnectionResponse.CommandExecuted)
			{
				readValue = BoolArrayToByte(values);
			}
			else
			{
				readValue = 0;
			}
			return commandState;
		}

		public RtuConnectionResponse Write(IModbusClient modbusClient, byte newValue)
		{
			return modbusClient.WriteCoils(RtuId, Address, ByteToBoolArray(newValue));
		}

		private byte BoolArrayToByte(bool[] readValues)
		{
			if (readValues.Length == 1)
				return (byte)(readValues[0] ? 1 : 0);

			return (byte)((readValues[0] ? 2 : 0) + (readValues[1] ? 1 : 0));
		}

		private bool[] ByteToBoolArray(byte value)
		{
			if (Length == 1)
			{
				return new bool[1] { value == 1 };
			}

			return new bool[2] { (value & 2) == 2, (value & 1) == 1 };
		}
	}
}
