using ModbusServiceLibrary.ModbusClient;

namespace ModbusServiceLibrary.Modbus.ModbusDataTypes
{
	public sealed class HoldingRegister2 : IAnalogInput, IAnalogOutput
	{
		public HoldingRegister2(int rtuId, int address)
		{
			RtuId = rtuId;
			Address = address;
		}

		public int RtuId { get; }

		public int Address { get; }

		public bool TryRead(IModbusClient modbusClient, out ushort readValue)
		{
			if (modbusClient.TryReadHoldingRegisters(RtuId, Address, 1, out ushort[] values))
			{
				readValue = values[0];
				return true;
			}

			readValue = 0;
			return false;
		}

		public bool TryWrite(IModbusClient modbusClient, int newValue)
		{
			throw new System.NotImplementedException();
		}
	}
}
