using ModbusServiceLibrary.Modbus;
using ModbusServiceLibrary.Modbus.ModbusClient;
using ModbusServiceLibrary.Modbus.ModbusConnection;
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
			modbusClientMock.Setup(x => x.Connect(1, "192.168.0.1", 502)).Returns(RtuConnectionResponse.Connecting);

			var commandState = modbusDriver.ConnectToRtu(1, "192.168.0.1", 502);

			Assert.Equal(RtuConnectionResponse.Connecting, commandState);
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
			modbusClientMock.Setup(x => x.ReadHoldingRegisters(It.IsAny<int>(), It.IsAny<int>(), 1, out values)).Returns(RtuConnectionResponse.CommandExecuted);

			var commandState = modbusDriver.ReadAnalogSignal(signalId, out double value);

			Assert.Equal(expectedValue, value);
			Assert.Equal(RtuConnectionResponse.CommandExecuted, commandState);
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
			modbusClientMock.Setup(x => x.ReadInputRegisters(It.IsAny<int>(), It.IsAny<int>(), 1, out readValues)).Returns(RtuConnectionResponse.CommandExecuted);

			var commandState = modbusDriver.ReadAnalogSignal(signalId, out double value);

			Assert.Equal(expectedValue, value);
			Assert.Equal(RtuConnectionResponse.CommandExecuted, commandState);
		}

		[Fact]
		public void ReadAnalogSignal_Failed()
		{
			int signalId = 1;
			ushort[] values = new ushort[1];
			modbusClientMock.Setup(x => x.ReadHoldingRegisters(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), out values)).Returns(RtuConnectionResponse.CommandFailed);

			var commandState = modbusDriver.ReadAnalogSignal(signalId, out double value);

			Assert.Equal(RtuConnectionResponse.CommandFailed, commandState);
		}

		[Theory]
		[InlineData(new bool[] { false, false }, "Error")]
		[InlineData(new bool[] { false, true }, "On")]
		[InlineData(new bool[] { true, false }, "Off")]
		[InlineData(new bool[] { true, true }, "Transit")]
		public void ReadDiscreteSignal_Coil_Succesful(bool[] readValues, string newState)
		{
			int signalId = 6;
			modbusClientMock.Setup(x => x.ReadCoils(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), out readValues)).Returns(RtuConnectionResponse.CommandExecuted);

			var commandState = modbusDriver.ReadDiscreteSignal(signalId, out string state);

			Assert.Equal(newState, state);
			Assert.Equal(RtuConnectionResponse.CommandExecuted, commandState);
		}

		[Theory]
		[InlineData(new bool[] { false, false }, "Error")]
		[InlineData(new bool[] { false, true }, "On")]
		[InlineData(new bool[] { true, false }, "Off")]
		[InlineData(new bool[] { true, true }, "Transit")]
		public void ReadDiscreteSignal_DigitalPoint_Succesful(bool[] readValues, string newState)
		{
			int signalId = 7;
			modbusClientMock.Setup(x => x.ReadInputs(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), out readValues)).Returns(RtuConnectionResponse.CommandExecuted);

			var commandState = modbusDriver.ReadDiscreteSignal(signalId, out string state);

			Assert.Equal(newState, state);
			Assert.Equal(RtuConnectionResponse.CommandExecuted, commandState);
		}

		[Fact]
		public void ReadDiscreteSignal_Coil_Failed()
		{
			int signalId = 6;
			bool[] readValues = new bool[2];
			modbusClientMock.Setup(x => x.ReadCoils(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), out readValues)).Returns(RtuConnectionResponse.CommandFailed);

			var commandState = modbusDriver.ReadDiscreteSignal(signalId, out string state);

			Assert.Equal(RtuConnectionResponse.CommandFailed, commandState);
		}

		[Fact]
		public void ReadDiscreteSignal_DigitalPoint_Failed()
		{
			int signalId = 7;
			bool[] readValues = new bool[2];
			modbusClientMock.Setup(x => x.ReadInputs(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), out readValues)).Returns(RtuConnectionResponse.CommandFailed);

			var commandState = modbusDriver.ReadDiscreteSignal(signalId, out string state);

			Assert.Equal(RtuConnectionResponse.CommandFailed, commandState);
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
			modbusClientMock.Setup(x => x.WriteSingleHoldingRegister(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(RtuConnectionResponse.CommandExecuted);

			var commandState = modbusDriver.WriteAnalogSignal(signalId, newValue);

			Assert.Equal(RtuConnectionResponse.CommandExecuted, commandState);
		}

		[Fact]
		public void WriteAnalogSignal_HoldingRegister_Failed()
		{
			int signalId = 1;
			modbusClientMock.Setup(x => x.WriteSingleHoldingRegister(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(RtuConnectionResponse.CommandFailed);

			var commandState = modbusDriver.WriteAnalogSignal(signalId, It.IsAny<int>());

			modbusClientMock.Verify(x => x.WriteSingleHoldingRegister(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
			Assert.Equal(RtuConnectionResponse.CommandFailed, commandState);
		}

		[Fact]
		public void WriteAnalogSignal_AnalogPoint_Failed()
		{
			int signalId = 2;

			var commandState = modbusDriver.WriteAnalogSignal(signalId, It.IsAny<int>());

			Assert.Equal(RtuConnectionResponse.UnsupportedCommand, commandState);
		}

		[Theory]
		[InlineData("On", new bool[] { false, true })]
		[InlineData("Off", new bool[] { true, false })]
		public void WriteDiscreteSignal_Coil_Succesful(string newState, bool[] rawValues)
		{
			int signalId = 6;
			modbusClientMock.Setup(x => x.WriteCoils(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<bool[]>())).Returns(RtuConnectionResponse.CommandExecuted);

			var commandState = modbusDriver.WriteDiscreteSignal(signalId, newState);

			modbusClientMock.Verify(x => x.WriteCoils(It.IsAny<int>(), It.IsAny<int>(), rawValues));
			Assert.Equal(RtuConnectionResponse.CommandExecuted, commandState);
		}

		[Theory]
		[InlineData("On", new bool[] { false, true })]
		[InlineData("Off", new bool[] { true, false })]
		public void WriteDiscreteSignal_Coil_Failed(string newState, bool[] rawValues)
		{
			int signalId = 6;
			modbusClientMock.Setup(x => x.WriteCoils(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<bool[]>())).Returns(RtuConnectionResponse.CommandFailed);

			var commandState = modbusDriver.WriteDiscreteSignal(signalId, newState);

			modbusClientMock.Verify(x => x.WriteCoils(It.IsAny<int>(), It.IsAny<int>(), rawValues));
			Assert.Equal(RtuConnectionResponse.CommandFailed, commandState);
		}

		[Fact]
		public void WriteDiscreteSignal_DigitalPoint_Failed()
		{
			int signalId = 7;

			var commandState = modbusDriver.WriteDiscreteSignal(signalId, It.IsAny<string>());

			Assert.Equal(RtuConnectionResponse.UnsupportedCommand, commandState);
		}
	}
}
