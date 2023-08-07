using ModbusServiceLibrary.Modbus;
using ModbusServiceLibrary.Modbus.ModbusClient;
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
			modbusDataStaticCache.Initialize();

			modbusDriver = new ModbusDriver(signalMapper, modbusClientMock.Object, modbusDataStaticCache);
		}

		[Fact]
		public void ConnectToRtu_Succesful()
		{
			modbusClientMock.Setup(x => x.TryConnect(1, "192.168.0.1", 502));

			bool isSuccesfull = modbusDriver.TryConnectToRtu(1, "192.168.0.1", 502);

			Assert.True(isSuccesfull);
		}

		[Theory]
		[InlineData(10000, 40)]
		[InlineData(1000, -32)]
		[InlineData(100, -39.2)]
		public void ReadAnalogSignal_HoldingRegister_Succesful(ushort rawValue, double expectedValue)
		{
			ushort[] values = new ushort[1];
			values[0] = rawValue;
			int signalId = 1;
			modbusClientMock.Setup(x => x.TryReadHoldingRegisters(It.IsAny<int>(), It.IsAny<int>(), 1, out values)).Returns(true);

			bool isSuccesfull = modbusDriver.TryReadAnalogSignal(signalId, out double value);

			Assert.Equal(expectedValue, value);
			Assert.True(isSuccesfull);
		}

		[Theory]
		[InlineData(10000, 40)]
		[InlineData(1000, -32)]
		[InlineData(100, -39.2)]
		public void ReadAnalogSignal_AnalogPoint_Succesful(ushort rawValue, double expectedValue)
		{
			ushort[] readValues = new ushort[1];
			readValues[0] = rawValue;
			int signalId = 2;
			modbusClientMock.Setup(x => x.TryReadInputRegisters(It.IsAny<int>(), It.IsAny<int>(), 1, out readValues)).Returns(true);

			bool isSuccesfull = modbusDriver.TryReadAnalogSignal(signalId, out double value);

			Assert.Equal(expectedValue, value);
			Assert.True(isSuccesfull);
		}

		[Fact]
		public void ReadAnalogSignal_Failed()
		{
			int signalId = 1;
			ushort[] values = new ushort[1];
			modbusClientMock.Setup(x => x.TryReadHoldingRegisters(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), out values)).Returns(false);

			bool isSuccesfull = modbusDriver.TryReadAnalogSignal(signalId, out double value);

			Assert.False(isSuccesfull);
		}

		[Theory]
		[InlineData(new bool[] { false, false }, "Error")]
		[InlineData(new bool[] { false, true }, "On")]
		[InlineData(new bool[] { true, false }, "Off")]
		[InlineData(new bool[] { true, true }, "Transit")]
		public void ReadDiscreteSignal_Coil_Succesful(bool[] readValues, string newState)
		{
			int signalId = 6;
			modbusClientMock.Setup(x => x.TryReadCoils(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), out readValues)).Returns(true);

			bool isSuccesfull = modbusDriver.TryReadDiscreteSignal(signalId, out string state);

			Assert.Equal(newState, state);
			Assert.True(isSuccesfull);
		}

		[Theory]
		[InlineData(new bool[] { false, false }, "Error")]
		[InlineData(new bool[] { false, true }, "On")]
		[InlineData(new bool[] { true, false }, "Off")]
		[InlineData(new bool[] { true, true }, "Transit")]
		public void ReadDiscreteSignal_DigitalPoint_Succesful(bool[] readValues, string newState)
		{
			int signalId = 7;
			modbusClientMock.Setup(x => x.TryReadInputs(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), out readValues)).Returns(true);

			bool isSuccesfull = modbusDriver.TryReadDiscreteSignal(signalId, out string state);

			Assert.Equal(newState, state);
			Assert.True(isSuccesfull);
		}

		[Fact]
		public void ReadDiscreteSignal_Coil_Failed()
		{
			int signalId = 6;
			bool[] readValues = new bool[2];
			modbusClientMock.Setup(x => x.TryReadCoils(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), out readValues)).Returns(false);

			bool isSuccesfull = modbusDriver.TryReadDiscreteSignal(signalId, out string state);

			Assert.False(isSuccesfull);
		}

		[Fact]
		public void ReadDiscreteSignal_DigitalPoint_Failed()
		{
			int signalId = 7;
			bool[] readValues = new bool[2];
			modbusClientMock.Setup(x => x.TryReadInputs(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), out readValues)).Returns(false);

			bool isSuccesfull = modbusDriver.TryReadDiscreteSignal(signalId, out string state);

			Assert.False(isSuccesfull);
		}


		[Theory]
		[InlineData(40, 10000)]
		[InlineData(-32, 1000)]
		[InlineData(-39.2, 100)]
		public void WriteAnalogSignal_HoldingRegister_Succesful(double newValue, ushort rawValue)
		{
			ushort[] values = new ushort[1];
			values[0] = rawValue;
			int signalId = 1;
			modbusClientMock.Setup(x => x.TryWriteSingleHoldingRegister(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(true);

			bool isSuccesfull = modbusDriver.TryWriteAnalogSignal(signalId, newValue);

			modbusClientMock.Verify(x => x.TryWriteSingleHoldingRegister(It.IsAny<int>(), It.IsAny<int>(), rawValue));
			Assert.True(isSuccesfull);
		}

		[Fact]
		public void WriteAnalogSignal_HoldingRegister_Failed()
		{
			int signalId = 1;
			modbusClientMock.Setup(x => x.TryWriteSingleHoldingRegister(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(false);

			bool isSuccesfull = modbusDriver.TryWriteAnalogSignal(signalId, It.IsAny<int>());

			modbusClientMock.Verify(x => x.TryWriteSingleHoldingRegister(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
			Assert.False(isSuccesfull);
		}

		[Fact]
		public void WriteAnalogSignal_AnalogPoint_Failed()
		{
			int signalId = 2;

			bool isSuccesfull = modbusDriver.TryWriteAnalogSignal(signalId, It.IsAny<int>());

			Assert.False(isSuccesfull);
		}

		[Theory]
		[InlineData("On", new bool[] { false, true })]
		[InlineData("Off", new bool[] { true, false })]
		public void WriteDiscreteSignal_Coil_Succesful(string newState, bool[] rawValues)
		{
			int signalId = 6;
			modbusClientMock.Setup(x => x.TryWriteCoils(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<bool[]>())).Returns(true);

			bool isSuccesfull = modbusDriver.TryWriteDiscreteSignal(signalId, newState);

			modbusClientMock.Verify(x => x.TryWriteCoils(It.IsAny<int>(), It.IsAny<int>(), rawValues));
			Assert.True(isSuccesfull);
		}

		[Theory]
		[InlineData("On", new bool[] { false, true })]
		[InlineData("Off", new bool[] { true, false })]
		public void WriteDiscreteSignal_Coil_Failed(string newState, bool[] rawValues)
		{
			int signalId = 6;
			modbusClientMock.Setup(x => x.TryWriteCoils(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<bool[]>())).Returns(false);

			bool isSuccesfull = modbusDriver.TryWriteDiscreteSignal(signalId, newState);

			modbusClientMock.Verify(x => x.TryWriteCoils(It.IsAny<int>(), It.IsAny<int>(), rawValues));
			Assert.False(isSuccesfull);
		}

		[Fact]
		public void WriteDiscreteSignal_DigitalPoint_Failed()
		{
			int signalId = 7;

			bool isSuccesfull = modbusDriver.TryWriteDiscreteSignal(signalId, It.IsAny<string>());

			Assert.False(isSuccesfull);
		}
	}
}
