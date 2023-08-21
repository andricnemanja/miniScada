using ModbusServiceLibrary.CommandProcessing;
using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.Modbus;
using ModbusServiceLibrary.Model.RTU;
using ModbusServiceLibrary.RtuCommands;
using ModbusServiceLibrary.RtuConfiguration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ModbusServiceLibrary.Tests.CommandProcessingTests
{
	public class ConnectoToRtuCommandProcessorTests
	{
		private Mock<IModbusRtuConfiguration> rtuConfigurationMock;
		private Mock<IProtocolDriver> protocolDriverMock;

		public ConnectoToRtuCommandProcessorTests()
		{
			rtuConfigurationMock = new Mock<IModbusRtuConfiguration>();
			protocolDriverMock = new Mock<IProtocolDriver>();
		}


		[Fact]
		private void ProcessCommand_ConnectionSuccessful_ReturnsConnectToRtuResult()
		{
			//Arrange
			var connectionParameters = new RTUConnectionParameters
			{
				IpAddress = "192.168.1.1",
				Port = 502
			};
			rtuConfigurationMock.Setup(x => x.GetRtuConnectionParameters(1)).Returns(connectionParameters);
			protocolDriverMock.Setup(x => x.ConnectToRtu(1, connectionParameters.IpAddress, connectionParameters.Port)).Returns(true);

			var connectToRtuCommand = new RtuOnScanCommand(1);
			var commandProcessor = new RtuOnScanCommandProcessor(protocolDriverMock.Object, rtuConfigurationMock.Object);

			//Act
			var result = commandProcessor.ProcessCommand(connectToRtuCommand) as ConnectToRtuResult;

			// Assert
			Assert.IsType<ConnectToRtuResult>(result);
			Assert.Equal(connectToRtuCommand.RtuId, result.RtuId);
			protocolDriverMock.Verify(x => x.ConnectToRtu(1, "192.168.1.1", 502));
		}

		[Fact]
		private void ProcessCommand_ConnectionSuccessful_ReturnsConnectionToRtuFailedResult()
		{
			//Arrange
			var connectionParameters = new RTUConnectionParameters
			{
				IpAddress = "192.168.1.1",
				Port = 502
			};
			var connectToRtuCommand = new RtuOnScanCommand(1);
			
			rtuConfigurationMock.Setup(x => x.GetRtuConnectionParameters(connectToRtuCommand.RtuId)).Returns(connectionParameters);
			protocolDriverMock.Setup(x => x.ConnectToRtu(connectToRtuCommand.RtuId, connectionParameters.IpAddress, connectionParameters.Port)).Returns(false);

			var commandProcessor = new RtuOnScanCommandProcessor(protocolDriverMock.Object, rtuConfigurationMock.Object);

			//Act
			var result = commandProcessor.ProcessCommand(connectToRtuCommand) as ConnectToRtuFailedResult;

			//Assert
			Assert.IsType<ConnectToRtuFailedResult>(result);
			Assert.Equal(connectToRtuCommand.RtuId, result.RtuId);
			protocolDriverMock.Verify(x => x.ConnectToRtu(1, "192.168.1.1", 502));
		}


	}
}
