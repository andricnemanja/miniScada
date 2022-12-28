using ModbusServiceLibrary.ModbusCommands;
using ModbusServiceLibrary.ModbusCommunication;
using Moq;
using Xunit;

namespace ModbusServiceLibrary.Tests.CommandTests
{
	public class ChangeDiscreteSignalValueCommandTests
	{
		[Fact]
		public void WriteValue_SimulatorAvailable()
		{
			//Arrange
			var modbusSimulatorClientMock = new Mock<IModbusSimulatorClient>();
			modbusSimulatorClientMock.Setup(x => x.TryWriteAnalogSignalValue(1, 1, 10)).Returns(true);
			ChangeAnalogSignalValueCommand changeAnalogSignalValueCommand =
				new ChangeAnalogSignalValueCommand(modbusSimulatorClientMock.Object, 10, 1, 1);

			//Act
			bool returnValue = changeAnalogSignalValueCommand.Execute();

			//Assert
			modbusSimulatorClientMock.Verify(n => n.TryWriteAnalogSignalValue(1, 1, 10));
			Assert.True(returnValue);
		}

		[Fact]
		public void WriteValue_SimulatorNotAvailable()
		{
			//Arrange
			var modbusSimulatorClientMock = new Mock<IModbusSimulatorClient>();
			modbusSimulatorClientMock.Setup(x => x.TryWriteAnalogSignalValue(1, 1, 10)).Returns(false);
			ChangeAnalogSignalValueCommand changeAnalogSignalValueCommand =
				new ChangeAnalogSignalValueCommand(modbusSimulatorClientMock.Object, 10, 1, 1);

			//Act
			bool returnValue = changeAnalogSignalValueCommand.Execute();

			//Assert
			modbusSimulatorClientMock.Verify(n => n.TryWriteAnalogSignalValue(1, 1, 10));
			Assert.False(returnValue);
		}


	}
}
