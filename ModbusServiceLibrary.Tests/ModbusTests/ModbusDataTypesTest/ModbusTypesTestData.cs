using ModbusServiceLibrary.Modbus.ModbusDataTypes;

namespace ModbusServiceLibrary.Tests.ModbusTests.ModbusDataTypesTest
{
	public static class ModbusTypesTestData
	{
		public static AnalogInput GetAnalogInput()
		{
			return new AnalogInput(1, 1, 1, 1, 1);
		}

		public static Coil GetCoil()
		{
			return new Coil(1, 1, 1, 1, 2, 1);
		}

		public static DigitalInput GetDigitalInput()
		{
			return new DigitalInput(1, 1, 1, 1, 2, 1);
		}

		public static HoldingRegister GetHoldingRegister()
		{
			return new HoldingRegister(1, 1, 1, 1, 1);
		}
	}
}
