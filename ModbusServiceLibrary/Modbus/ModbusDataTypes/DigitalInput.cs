using ModbusServiceLibrary.ModbusClient;

namespace ModbusServiceLibrary.Modbus.ModbusDataTypes
{
	public class DigitalInput : IDigitalPoint
	{
		public DigitalInput(int id, int signalId, int address, int mappingId, byte length, int rtuId)
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


		public bool TryRead(IModbusClient modbusClient, out byte readValue)
		{
			if(modbusClient.TryReadInputs(RtuId, Address, Length, out bool[] values))
			{
				readValue = BoolArrayToByte(values);
				return true;
			}
			readValue = 0;
			return false;
		}

		public bool TryWrite(IModbusClient modbusClient, byte newValue)
		{
			return false;
		}

		private byte BoolArrayToByte(bool[] readValues)
		{
			if (readValues.Length == 1)
				return (byte)(readValues[0] ? 1 : 0);

			return (byte)((readValues[0] ? 2 : 0) + (readValues[1] ? 1 : 0));
		}
	}
}
