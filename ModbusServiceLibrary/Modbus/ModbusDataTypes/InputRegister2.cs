using ModbusServiceLibrary.ModbusClient;

namespace ModbusServiceLibrary.Modbus.ModbusDataTypes
{
	public sealed class InputRegister2 : IAnalogInput
	{
		public InputRegister2(int rtuId, int address)
		{
			RtuId = rtuId;
			Address = address;
		}

		public int RtuId { get; }

		public int Address { get; }

		public bool TryRead(IModbusClient modbusClient, out ushort readValue)
		{
			if (modbusClient.TryReadInputRegisters(RtuId, Address, 1, out ushort[] values))
			{
				readValue = values[0];
				return true;
			}

			readValue = 0;
			return false;
		}
	}
}
