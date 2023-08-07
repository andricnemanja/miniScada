using ModbusServiceLibrary.Modbus.ModbusConnection;
using ModbusServiceLibrary.Modbus.ModbusConnection.States;
using Moq;
using Xunit;

namespace ModbusServiceLibrary.Tests.ModbusTests.ModbusConnection.States
{
	public sealed class RtuConnectionStateFactoryTests
	{
		private readonly Mock<IRtuConnection> rtuConnectionMock;
		private readonly RtuConnectionStateFactory rtuConnectionStateFactory;
		public RtuConnectionStateFactoryTests()
		{
			rtuConnectionMock = new Mock<IRtuConnection>();
			rtuConnectionStateFactory = new RtuConnectionStateFactory();
		}

		[Fact]
		public void CreateConnectionState_OnlineState()
		{
			var state = rtuConnectionStateFactory.CreateConnectionState(RtuConnectionState.Online, rtuConnectionMock.Object);

			Assert.IsType<OnlineRtuState>(state);
		}

		[Fact]
		public void CreateConnectionState_DisconnectedState()
		{
			var state = rtuConnectionStateFactory.CreateConnectionState(RtuConnectionState.Disconnected, rtuConnectionMock.Object);

			Assert.IsType<DisconnectedRtuState>(state);
		}

		[Fact]
		public void CreateConnectionState_ConnectingState()
		{
			var state = rtuConnectionStateFactory.CreateConnectionState(RtuConnectionState.Connecting, rtuConnectionMock.Object);

			Assert.IsType<ConnectingRtuState>(state);
		}
	}
}
