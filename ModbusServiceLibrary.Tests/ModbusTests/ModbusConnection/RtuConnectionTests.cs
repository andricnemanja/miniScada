using System;
using ModbusServiceLibrary.DynamicCacheManagerReference;
using ModbusServiceLibrary.Modbus.ModbusConnection;
using ModbusServiceLibrary.Modbus.ModbusConnection.States;
using Moq;
using NModbus;
using Xunit;

namespace ModbusServiceLibrary.Tests.ModbusTests.ModbusConnection
{
	public sealed class RtuConnectionTests
	{
		private readonly Mock<IDynamicCacheManagerService> dynamicCacheManagerServiceMock;
		private readonly Mock<IRtuConnectionStateFactory> rtuConnectionStateFactoryMock;
		private readonly Mock<IRtuConnectionState> rtuConnectionStateMock;
		private readonly Mock<IModbusMaster> modbusMasterMock;
		private readonly int rtuId = 1;
		private readonly RtuConnection rtuConnection;

		public RtuConnectionTests()
		{
			dynamicCacheManagerServiceMock = new Mock<IDynamicCacheManagerService>();
			rtuConnectionStateFactoryMock = new Mock<IRtuConnectionStateFactory>();
			rtuConnectionStateMock = new Mock<IRtuConnectionState>();
			modbusMasterMock = new Mock<IModbusMaster>();

			rtuConnectionStateFactoryMock.Setup(r => r.CreateConnectionState(It.IsAny<RtuConnectionState>(), It.IsAny<IRtuConnection>())).Returns(rtuConnectionStateMock.Object);

			rtuConnection = new RtuConnection(rtuId, dynamicCacheManagerServiceMock.Object, rtuConnectionStateFactoryMock.Object);
		}

		[Fact]
		public void Connect()
		{
			string ipAddress = "127.0.0.1";
			int port = 502;
			rtuConnectionStateMock.Setup(r => r.Connect(It.IsAny<string>(), It.IsAny<int>())).Returns(RtuConnectionResponse.Connecting);

			var result = rtuConnection.Connect(ipAddress, port);

			Assert.Equal(RtuConnectionResponse.Connecting, result);
			rtuConnectionStateMock.Verify(r => r.Connect(ipAddress, port), Times.Once);
		}

		[Fact]
		public void Disconnect()
		{
			rtuConnectionStateMock.Setup(r => r.Disconnect()).Returns(RtuConnectionResponse.Disconnected);

			var result = rtuConnection.Disconnect();

			Assert.Equal(RtuConnectionResponse.Disconnected, result);
			rtuConnectionStateMock.Verify(r => r.Disconnect(), Times.Once);
		}

		[Fact]
		public void ExecuteWriteCommand()
		{
			modbusMasterMock.Setup(m => m.WriteSingleRegister(It.IsAny<byte>(), It.IsAny<ushort>(), It.IsAny<ushort>()));
			rtuConnectionStateMock.Setup(r => r.ExecuteWriteCommand(It.IsAny<Action<byte, ushort, ushort>>(), It.IsAny<ushort>(), It.IsAny<ushort>())).Returns(RtuConnectionResponse.CommandExecuted);
			ushort signalAddress = 1;
			ushort newValue = 1;

			var result = rtuConnection.ExecuteWriteCommand(modbusMasterMock.Object.WriteSingleRegister, signalAddress, newValue);

			Assert.Equal(RtuConnectionResponse.CommandExecuted, result);
			rtuConnectionStateMock.Verify(r => r.ExecuteWriteCommand(modbusMasterMock.Object.WriteSingleRegister, signalAddress, newValue), Times.Once);
		}

		[Fact]
		public void ExecuteReadCommand()
		{
			modbusMasterMock.Setup(m => m.WriteSingleRegister(It.IsAny<byte>(), It.IsAny<ushort>(), It.IsAny<ushort>()));
			ushort signalAddress = 1;
			ushort newValue = 1;

			rtuConnection.ExecuteWriteCommand(modbusMasterMock.Object.WriteSingleRegister, signalAddress, newValue);

			rtuConnectionStateMock.Verify(r => r.ExecuteWriteCommand(modbusMasterMock.Object.WriteSingleRegister, signalAddress, newValue), Times.Once);
		}
	}
}
