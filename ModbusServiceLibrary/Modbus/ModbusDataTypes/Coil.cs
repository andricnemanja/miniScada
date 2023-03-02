using ModbusServiceLibrary.ModbusClient;

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

		public byte Read(IModbusClient modbusClient)
		{
			modbusClient.TryReadCoils(RtuId, Address, Length, out bool[] values);
			return BoolArrayToByte(values);
		}

		public bool TryWrite(IModbusClient modbusClient, byte newValue)
		{
			return modbusClient.TryWriteCoils(RtuId, Address, ByteToBoolArray(newValue));
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
