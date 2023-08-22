using ModbusServiceLibrary.CommandProcessing;
using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.Modbus;
using ModbusServiceLibrary.Modbus.ModbusConnection;
using ModbusServiceLibrary.Model.RTU;
using ModbusServiceLibrary.RtuCommands;
using ModbusServiceLibrary.RtuConfiguration;
using Moq;
using Xunit;

namespace ModbusServiceLibrary.Tests.CommandProcessingTests
{
	public class OnScanCommandProcessorTests
	{
		private readonly Mock<IModbusRtuConfiguration> rtuConfigurationMock;
		private readonly Mock<IProtocolDriver> protocolDriverMock;

		public OnScanCommandProcessorTests()
		{
			rtuConfigurationMock = new Mock<IModbusRtuConfiguration>();
			protocolDriverMock = new Mock<IProtocolDriver>();
		}


		[Fact]
		private void ProcessCommand_ConnectionSuccessful_ReturnsOnScanResult()
		{
			//Arrange
			var connectionParameters = new RTUConnectionParameters
			{
				IpAddress = "192.168.1.1",
				Port = 502
			};
			rtuConfigurationMock.Setup(x => x.GetRtuConnectionParameters(1)).Returns(connectionParameters);
			protocolDriverMock.Setup(x => x.ConnectToRtu(1, connectionParameters.IpAddress, connectionParameters.Port)).Returns(RtuConnectionResponse.Connecting);

			var connectToRtuCommand = new RtuOnScanCommand(1);
			var commandProcessor = new RtuOnScanCommandProcessor(protocolDriverMock.Object, rtuConfigurationMock.Object);

			//Act
			var result = commandProcessor.ProcessCommand(connectToRtuCommand) as RtuOnScanResult;

			// Assert
			Assert.IsType<RtuOnScanResult>(result);
			Assert.Equal(connectToRtuCommand.RtuId, result.RtuId);
			protocolDriverMock.Verify(x => x.ConnectToRtu(1, "192.168.1.1", 502));
		}
	}
}
