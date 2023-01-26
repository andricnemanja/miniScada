using ModbusServiceLibrary.ModbusCommands;
using ModbusServiceLibrary.SignalConverter;
using Moq;
using Xunit;

namespace ModbusServiceLibrary.Tests.ModbusServiceTests
{
	public class ModbusServiceTests
	{
		[Theory]
		[InlineData(1, 1)]
		[InlineData(1, 2)]
		[InlineData(2, 1)]
		public void ReadAnalogSignal(int rtuId, int signalAddress)
		{
			var modbusCommandInvokerMock = new Mock<IModbusCommandInvoker>();
			var valueConverterMock = new Mock<IValueConverter>();
			ModbusService modbusService = new ModbusService(modbusCommandInvokerMock.Object, valueConverterMock.Object);

			modbusService.ReadAnalogSignal(rtuId, signalAddress);

		}
	}
}
