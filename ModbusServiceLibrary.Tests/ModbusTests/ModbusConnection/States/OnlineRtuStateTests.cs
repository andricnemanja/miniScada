using System.IO;
using System.Net.Sockets;
using ModbusServiceLibrary.Modbus.ModbusConnection;
using ModbusServiceLibrary.Modbus.ModbusConnection.States;
using Moq;
using NModbus;
using Xunit;

namespace ModbusServiceLibrary.Tests.ModbusTests.ModbusConnection.States
{
	public sealed class OnlineRtuStateTests
	{
		private readonly Mock<IRtuConnection> rtuConnectionMock;
		private readonly Mock<IModbusMaster> modbusMasterMock;
		private readonly Mock<IRtuConnectionStateFactory> connectionStateFactoryMock;
		private readonly OnlineRtuState onlineRtuState;

		public OnlineRtuStateTests()
		{
			rtuConnectionMock = new Mock<IRtuConnection>();
			modbusMasterMock = new Mock<IModbusMaster>();
			connectionStateFactoryMock = new Mock<IRtuConnectionStateFactory>();

			connectionStateFactoryMock.Setup(c => c.CreateConnectionState(It.IsAny<RtuConnectionState>(), rtuConnectionMock.Object));

			rtuConnectionMock.Setup(r => r.ConnectionStateFactory.CreateConnectionState(It.IsAny<RtuConnectionState>(), It.IsAny<IRtuConnection>()));
			rtuConnectionMock.Setup(r => r.ModbusMaster).Returns(modbusMasterMock.Object);
			rtuConnectionMock.Setup(r => r.ConnectionStateFactory).Returns(connectionStateFactoryMock.Object);

			onlineRtuState = new OnlineRtuState(rtuConnectionMock.Object);
		}

		[Fact]
		public void Connect()
		{
			string ipAddress = "127.0.0.1";
			int port = 502;

			var result = onlineRtuState.Connect(ipAddress, port);

			Assert.Equal(RtuConnectionResponse.Connected, result);
		}

		[Fact]
		public void Disconnect()
		{
			rtuConnectionMock.Setup(r => r.ModbusMaster.Dispose());

			var result = onlineRtuState.Disconnect();

			rtuConnectionMock.Verify(r => r.ModbusMaster.Dispose(), Times.Once);
			connectionStateFactoryMock.Verify(c => c.CreateConnectionState(RtuConnectionState.Disconnected, rtuConnectionMock.Object), Times.Once);
			Assert.Equal(RtuConnectionResponse.Disconnected, result);
		}

		[Fact]
		public void ExecuteReadCommand_Successful()
		{
			ushort signalAddress = 1;
			ushort numberOfPoints = 1;
			modbusMasterMock.Setup(m => m.ReadHoldingRegisters(It.IsAny<byte>(), It.IsAny<ushort>(), It.IsAny<ushort>())).Returns(new ushort[] { 1, 2, 3 });

			var result = onlineRtuState.ExecuteReadCommand(rtuConnectionMock.Object.ModbusMaster.ReadHoldingRegisters, signalAddress, numberOfPoints, out ushort[] readValues);

			modbusMasterMock.Verify(m => m.ReadHoldingRegisters(1, signalAddress, numberOfPoints), Times.Once);
			Assert.Equal(1, readValues[0]);
			Assert.Equal(RtuConnectionResponse.CommandExecuted, result);
		}

		[Fact]
		public void ExecuteReadCommand_ConnectionFailure()
		{
			ushort signalAddress = 1;
			ushort numberOfPoints = 1;
			modbusMasterMock.Setup(m => m.ReadHoldingRegisters(It.IsAny<byte>(), It.IsAny<ushort>(), It.IsAny<ushort>())).Throws(new IOException("Connection Failed", new SocketException()));

			var result = onlineRtuState.ExecuteReadCommand(rtuConnectionMock.Object.ModbusMaster.ReadHoldingRegisters, signalAddress, numberOfPoints, out ushort[] readValues);

			modbusMasterMock.Verify(m => m.ReadHoldingRegisters(1, signalAddress, numberOfPoints), Times.Once);
			connectionStateFactoryMock.Verify(c => c.CreateConnectionState(RtuConnectionState.Connecting, rtuConnectionMock.Object), Times.Once);
			Assert.Equal(RtuConnectionResponse.ConnectionFailure, result);
		}

		[Fact]
		public void ExecuteWriteCommand_Successful()
		{
			ushort signalAddress = 1;
			ushort newValue = 1;
			modbusMasterMock.Setup(m => m.WriteSingleRegister(It.IsAny<byte>(), It.IsAny<ushort>(), It.IsAny<ushort>()));

			var result = onlineRtuState.ExecuteWriteCommand(rtuConnectionMock.Object.ModbusMaster.WriteSingleRegister, signalAddress, newValue);

			modbusMasterMock.Verify(m => m.WriteSingleRegister(1, signalAddress, newValue), Times.Once);
			Assert.Equal(RtuConnectionResponse.CommandExecuted, result);
		}

		[Fact]
		public void ExecuteWriteCommand_ConnectionFailure()
		{
			ushort signalAddress = 1;
			ushort newValue = 1;
			modbusMasterMock.Setup(m => m.WriteSingleRegister(It.IsAny<byte>(), It.IsAny<ushort>(), It.IsAny<ushort>())).Throws(new IOException("Connection Failed", new SocketException()));

			var result = onlineRtuState.ExecuteWriteCommand(rtuConnectionMock.Object.ModbusMaster.WriteSingleRegister, signalAddress, newValue);

			modbusMasterMock.Verify(m => m.WriteSingleRegister(1, signalAddress, newValue), Times.Once);
			connectionStateFactoryMock.Verify(c => c.CreateConnectionState(RtuConnectionState.Connecting, rtuConnectionMock.Object), Times.Once);
			Assert.Equal(RtuConnectionResponse.ConnectionFailure, result);
		}
	}
}
