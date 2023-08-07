using ModbusServiceLibrary.DynamicCacheManagerReference;
using ModbusServiceLibrary.Modbus.ModbusConnection;
using ModbusServiceLibrary.Modbus.ModbusConnection.States;
using Moq;
using Xunit;

namespace ModbusServiceLibrary.Tests.ModbusTests.ModbusConnection
{
	public sealed class RtuConnectionFactoryTests
	{
		private readonly Mock<IDynamicCacheManagerService> dynamicCacheManagerServiceMock;
		private readonly Mock<IRtuConnectionStateFactory> rtuConnectionStateFactoryMock;
		private readonly RtuConnectionFactory rtuConnectionFactory; 

		public RtuConnectionFactoryTests()
		{
			dynamicCacheManagerServiceMock = new Mock<IDynamicCacheManagerService>();
			rtuConnectionStateFactoryMock = new Mock<IRtuConnectionStateFactory>();
			rtuConnectionFactory = new RtuConnectionFactory();
		}

		[Fact]
		public void GetRtuConnection()
		{
			int rtuId = 1;

			var connection = rtuConnectionFactory.GetRtuConnection(rtuId, dynamicCacheManagerServiceMock.Object, rtuConnectionStateFactoryMock.Object);

			Assert.IsType<RtuConnection>(connection);
			Assert.Equal(rtuId, connection.RtuId);
			Assert.Equal(dynamicCacheManagerServiceMock.Object, connection.DynamicCacheManagerServiceClient);
			Assert.Equal(rtuConnectionStateFactoryMock.Object, connection.ConnectionStateFactory);
		}
	}
}
