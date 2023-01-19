using ModbusServiceLibrary.ModbusCommands;
using ModbusServiceLibrary.ModbusCommunication;
using Moq;
using Xunit;

namespace ModbusServiceLibrary.Tests.CommandTests
{
	public class ReadDiscreteSignalValueCommandTests
	{
		[Fact]
		public void ReadValue_SimulatorAvailable()
		{
			//Arrange
			byte value = 0;
			var modbusSimulatorClientMock = new Mock<IModbusSimulatorClient>();
			modbusSimulatorClientMock.Setup(x => x.TryReadDiscreteInput(1, 1, out value)).Returns(true);
			ReadDiscreteSignalValueCommand readDiscreteSignalValueCommand =
				new ReadDiscreteSignalValueCommand(modbusSimulatorClientMock.Object, 1, 1);

			//Act
			bool returnValue = readDiscreteSignalValueCommand.Execute();

			//Assert
			modbusSimulatorClientMock.Verify(n => n.TryReadDiscreteInput(1, 1, out value));
			Assert.True(returnValue);
		}

		[Fact]
		public void ReadValue_SimulatorNotAvailable()
		{
			//Arrange
			byte value = 0;
			var modbusSimulatorClientMock = new Mock<IModbusSimulatorClient>();
			modbusSimulatorClientMock.Setup(x => x.TryReadDiscreteInput(1, 1, out value)).Returns(false);
			ReadDiscreteSignalValueCommand readDiscreteSignalValueCommand =
				new ReadDiscreteSignalValueCommand(modbusSimulatorClientMock.Object, 1, 1);

			//Act
			bool returnValue = readDiscreteSignalValueCommand.Execute();

			//Assert
			modbusSimulatorClientMock.Verify(n => n.TryReadDiscreteInput(1, 1, out value));
			Assert.False(returnValue);
		}


	}
}
