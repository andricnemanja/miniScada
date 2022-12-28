using ModbusServiceLibrary.ModbusCommands;
using ModbusServiceLibrary.ModbusCommunication;
using Moq;
using Xunit;

namespace ModbusServiceLibrary.Tests.CommandTests
{
	public class ReadAnalogSignalValueCommandTests
	{
		[Fact]
		public void ReadValue_SimulatorAvailable()
		{
			//Arrange
			int value = 0;
			var modbusSimulatorClientMock = new Mock<IModbusSimulatorClient>();
			modbusSimulatorClientMock.Setup(x => x.TryReadAnalogInput(1, 1, out value)).Returns(true);
			ReadAnalogSignalValueCommand readAnalogSignalValueCommand =
				new ReadAnalogSignalValueCommand(modbusSimulatorClientMock.Object, 1, 1);

			//Act
			bool returnValue = readAnalogSignalValueCommand.Execute();

			//Assert
			modbusSimulatorClientMock.Verify(n => n.TryReadAnalogInput(1, 1, out value));
			Assert.True(returnValue);
		}

		[Fact]
		public void ReadValue_SimulatorNotAvailable()
		{
			//Arrange
			int value = 0;
			var modbusSimulatorClientMock = new Mock<IModbusSimulatorClient>();
			modbusSimulatorClientMock.Setup(x => x.TryReadAnalogInput(1, 1, out value)).Returns(false);
			ReadAnalogSignalValueCommand readAnalogSignalValueCommand =
				new ReadAnalogSignalValueCommand(modbusSimulatorClientMock.Object, 1, 1);

			//Act
			bool returnValue = readAnalogSignalValueCommand.Execute();

			//Assert
			modbusSimulatorClientMock.Verify(n => n.TryReadAnalogInput(1, 1, out value));
			Assert.False(returnValue);
		}
	}
}
