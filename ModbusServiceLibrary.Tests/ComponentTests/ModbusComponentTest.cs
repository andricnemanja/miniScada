using ModbusServiceLibrary.Modbus;
using ModbusServiceLibrary.ModbusClient;
using ModbusServiceLibrary.ModelServiceReference;
using ModbusServiceLibrary.SignalConverter;
using Moq;
using Xunit;

namespace ModbusServiceLibrary.Tests.ComponentTests
{
	public class ModbusComponentTest
	{
		private readonly ModbusDriver modbusDriver;
		private readonly Mock<IModbusClient> modbusClientMock;
		public ModbusComponentTest()
		{
			Mock<IModelService> modelServiceMock = new Mock<IModelService>();
			modelServiceMock.Setup(x => x.GetAllRTUs()).Returns(RtuTestData.GetRtuTestList());
			modelServiceMock.Setup(x => x.GetAnalogSignalMappings()).Returns(MappinTestData.GetAnalogSignalMappingsTestList());
			modelServiceMock.Setup(x => x.GetDiscreteSignalMappings()).Returns(MappinTestData.GetDiscreteSignalMappingsTestList());

			modbusClientMock = new Mock<IModbusClient>();

			SignalMapper signalMapper = new SignalMapper(modelServiceMock.Object);
			ModbusDataStaticCache modbusDataStaticCache = new ModbusDataStaticCache(modelServiceMock.Object);

			modbusDriver = new ModbusDriver(signalMapper, modbusClientMock.Object, modbusDataStaticCache);
		}

		[Fact]
		public void ConnectToRtu_Succesful()
		{
			modbusClientMock.Setup(x => x.TryConnect(1, "192.168.0.1", 502)).Returns(true);

			bool isSuccesfull = modbusDriver.TryConnectToRtu(1, "192.168.0.1", 502);

			Assert.True(isSuccesfull);
		}

		[Fact]
		public void ReadAnalogSignal_Succesful()
		{
			ushort[] values = { 101 };
			modbusClientMock.Setup(x => x.TryReadHoldingRegisters(1, 1, 1, out values)).Returns(true);

			bool isSuccesfull = modbusDriver.TryReadAnalogSignal(1, out double value);

			Assert.Equal(-39.192, value);

			Assert.True(isSuccesfull);
		}
	}
}
