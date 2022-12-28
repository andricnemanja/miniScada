using ModbusServiceLibrary.ModbusCommands;
using ModbusServiceLibrary.ModbusCommunication;
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
			var modbusConnectionMock = new Mock<IModbusSimulatorClient>();
			var modbusCommandInvokerMock = new Mock<IModbusCommandInvoker>();
			ModbusService modbusService = new ModbusService(modbusConnectionMock.Object, modbusCommandInvokerMock.Object);

			modbusService.ReadAnalogSignal(rtuId, signalAddress);

		}
	}
}
