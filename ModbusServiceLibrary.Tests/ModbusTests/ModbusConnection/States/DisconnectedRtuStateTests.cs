using System;
using ModbusServiceLibrary.Modbus.ModbusConnection;
using ModbusServiceLibrary.Modbus.ModbusConnection.States;
using Moq;
using Xunit;

namespace ModbusServiceLibrary.Tests.ModbusTests.ModbusConnection.States
{
	public sealed class DisconnectedRtuStateTests
	{
		private readonly Mock<IRtuConnection> rtuConnectionMock;
		private readonly DisconnectedRtuState disconnectedRtuState;

		public DisconnectedRtuStateTests()
		{
			rtuConnectionMock = new Mock<IRtuConnection>();
			rtuConnectionMock.Setup(r => r.ConnectionStateFactory.CreateConnectionState(It.IsAny<RtuConnectionState>(), It.IsAny<IRtuConnection>()));
			rtuConnectionMock.Setup(r => r.Connect(It.IsAny<string>(), It.IsAny<int>())).Returns(RtuConnectionResponse.Connecting);
			disconnectedRtuState = new DisconnectedRtuState(rtuConnectionMock.Object);
		}

		[Fact]
		public void Connect()
		{
			string ipAddress = "127.0.0.1";
			int port = 502;
			rtuConnectionMock.Setup(r => r.IpAddress).Returns(ipAddress);
			rtuConnectionMock.Setup(r => r.Port).Returns(port);

			var result = disconnectedRtuState.Connect(ipAddress, port);

			rtuConnectionMock.VerifySet(r => r.IpAddress = ipAddress, Times.Once());
			rtuConnectionMock.VerifySet(r => r.Port = port, Times.Once());
			rtuConnectionMock.Verify(r => r.ConnectionStateFactory.CreateConnectionState(RtuConnectionState.Connecting, rtuConnectionMock.Object), Times.Once());
			rtuConnectionMock.Verify(r => r.Connect(ipAddress, port), Times.Once());
			Assert.Equal(RtuConnectionResponse.Connecting, result);
		}

		[Fact]
		public void Disconnect()
		{
			var result = disconnectedRtuState.Disconnect();

			Assert.Equal(RtuConnectionResponse.Disconnected, result);
		}

		[Fact]
		public void ExecuteReadCommand()
		{
			var result = disconnectedRtuState.ExecuteReadCommand(It.IsAny<Func<byte, ushort, ushort, ushort>>(), It.IsAny<ushort>(), It.IsAny<ushort>(), out ushort readValue);

			Assert.Equal(0, readValue);
			Assert.Equal(RtuConnectionResponse.Disconnected, result);
		}

		[Fact]
		public void ExecuteWriteCommand()
		{
			var result = disconnectedRtuState.ExecuteWriteCommand(It.IsAny<Action<byte, ushort, ushort>>(), It.IsAny<ushort>(), It.IsAny<ushort>());

			Assert.Equal(RtuConnectionResponse.Disconnected, result);
		}
	}
}
