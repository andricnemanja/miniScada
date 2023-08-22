using ModbusServiceLibrary.Modbus;
using ModbusServiceLibrary.Modbus.ModbusClient;
using ModbusServiceLibrary.Modbus.ModbusConnection;
using ModbusServiceLibrary.Modbus.ModbusDataTypes;
using ModbusServiceLibrary.SignalConverter;
using Moq;
using Xunit;

namespace ModbusServiceLibrary.Tests.ModbusTests
{
	public class ModbusDriverTests
	{
		private readonly ModbusDriver modbusDriver;
		private readonly Mock<ISignalMapper> signalMapperMock;
		private readonly Mock<IModbusDataStaticCache> dataStaticCacheMock;
		private readonly Mock<IModbusClient> modbusClientMock;
		public ModbusDriverTests()
		{
			signalMapperMock = new Mock<ISignalMapper>();
			modbusClientMock = new Mock<IModbusClient>();
			dataStaticCacheMock = new Mock<IModbusDataStaticCache>();
			modbusDriver = new ModbusDriver(signalMapperMock.Object, modbusClientMock.Object, dataStaticCacheMock.Object);
		}
		
		[Fact]
		public void TryReadAnalogSignal_Successful()
		{
			double readValueMock = 10;
			int signalId = 5;
			Mock<IAnalogPoint> analogPointMock = new Mock<IAnalogPoint>();
			analogPointMock.Setup(x => x.Read(It.IsAny<IModbusClient>(), out It.Ref<ushort>.IsAny)).Returns(RtuConnectionResponse.CommandExecuted);
			dataStaticCacheMock.Setup(x => x.FindAnalogPoint(signalId)).Returns(analogPointMock.Object);
			signalMapperMock.Setup(x => x.ConvertAnalogSignalToRealValue(It.IsAny<int>(), It.IsAny<double>())).Returns(readValueMock);

			var commandState = modbusDriver.ReadAnalogSignal(signalId, out double readValue);

			Assert.Equal(RtuConnectionResponse.CommandExecuted, commandState);
			Assert.Equal(readValue, readValueMock);
			dataStaticCacheMock.Verify(x => x.FindAnalogPoint(signalId));
			analogPointMock.Verify(x => x.Read(It.IsAny<IModbusClient>(), out It.Ref<ushort>.IsAny));
			signalMapperMock.Verify(x => x.ConvertAnalogSignalToRealValue(It.IsAny<int>(), It.IsAny<double>()));
		}

		[Fact]
		public void TryReadAnalogSignal_Failed()
		{
			double readValueMock = 0;
			int signalId = 5;
			Mock<IAnalogPoint> analogPointMock = new Mock<IAnalogPoint>();
			analogPointMock.Setup(x => x.Read(It.IsAny<IModbusClient>(), out It.Ref<ushort>.IsAny)).Returns(RtuConnectionResponse.CommandFailed);
			dataStaticCacheMock.Setup(x => x.FindAnalogPoint(signalId)).Returns(analogPointMock.Object);
			signalMapperMock.Setup(x => x.ConvertAnalogSignalToRealValue(It.IsAny<int>(), It.IsAny<double>())).Returns(readValueMock);

			var commandState = modbusDriver.ReadAnalogSignal(signalId, out double readValue);

			Assert.Equal(RtuConnectionResponse.CommandFailed, commandState);
			dataStaticCacheMock.Verify(x => x.FindAnalogPoint(signalId));
			analogPointMock.Verify(x => x.Read(It.IsAny<IModbusClient>(), out It.Ref<ushort>.IsAny));
			signalMapperMock.Verify(x => x.ConvertAnalogSignalToRealValue(It.IsAny<int>(), It.IsAny<double>()), Times.Never);
		}

		[Fact]
		public void TryReadDiscreteSignal_Successful()
		{
			int signalId = 5;
			string signalStateMock = "Off";
			Mock<IDigitalPoint> digitalPointMock = new Mock<IDigitalPoint>();
			digitalPointMock.Setup(x => x.Read(It.IsAny<IModbusClient>(), out It.Ref<byte>.IsAny)).Returns(RtuConnectionResponse.CommandExecuted);
			dataStaticCacheMock.Setup(x => x.FindDiscretePoint(signalId)).Returns(digitalPointMock.Object);
			signalMapperMock.Setup(x => x.ConvertDiscreteSignalValueToState(It.IsAny<int>(), It.IsAny<byte>())).Returns(signalStateMock);

			var commandState = modbusDriver.ReadDiscreteSignal(signalId, out string readState);

			Assert.Equal(RtuConnectionResponse.CommandExecuted, commandState);
			Assert.Equal(signalStateMock, readState);
			dataStaticCacheMock.Verify(x => x.FindDiscretePoint(signalId));
			digitalPointMock.Verify(x => x.Read(It.IsAny<IModbusClient>(), out It.Ref<byte>.IsAny));
			signalMapperMock.Verify(x => x.ConvertDiscreteSignalValueToState(It.IsAny<int>(), It.IsAny<byte>()));
		}

		[Fact]
		public void TryReadDiscreteSignal_Failed()
		{
			int signalId = 5;
			Mock<IDigitalPoint> digitalPointMock = new Mock<IDigitalPoint>();
			digitalPointMock.Setup(x => x.Read(It.IsAny<IModbusClient>(), out It.Ref<byte>.IsAny)).Returns(RtuConnectionResponse.CommandFailed);
			dataStaticCacheMock.Setup(x => x.FindDiscretePoint(signalId)).Returns(digitalPointMock.Object);
			signalMapperMock.Setup(x => x.ConvertDiscreteSignalValueToState(It.IsAny<int>(), It.IsAny<byte>())).Returns(It.IsAny<string>());

			var commandState = modbusDriver.ReadDiscreteSignal(signalId, out string readState);

			Assert.Equal(RtuConnectionResponse.CommandFailed, commandState);
			dataStaticCacheMock.Verify(x => x.FindDiscretePoint(signalId));
			digitalPointMock.Verify(x => x.Read(It.IsAny<IModbusClient>(), out It.Ref<byte>.IsAny));
			signalMapperMock.Verify(x => x.ConvertDiscreteSignalValueToState(It.IsAny<int>(), It.IsAny<byte>()), Times.Never);
		}

		[Fact]
		public void TryWriteAnalogSignal_Successful()
		{
			int signalId = 5;
			Mock<IAnalogPoint> analogPointMock = new Mock<IAnalogPoint>();
			analogPointMock.Setup(x => x.Write(It.IsAny<IModbusClient>(), It.IsAny<int>())).Returns(RtuConnectionResponse.CommandExecuted);
			dataStaticCacheMock.Setup(x => x.FindAnalogPoint(signalId)).Returns(analogPointMock.Object);
			signalMapperMock.Setup(x => x.ConvertRealValueToAnalogSignalValue(It.IsAny<int>(), It.IsAny<double>())).Returns(It.IsAny<int>());

			var commandState = modbusDriver.WriteAnalogSignal(signalId, It.IsAny<double>());

			Assert.Equal(RtuConnectionResponse.CommandExecuted, commandState);
			dataStaticCacheMock.Verify(x => x.FindAnalogPoint(signalId));
			analogPointMock.Verify(x => x.Write(It.IsAny<IModbusClient>(), It.IsAny<int>()));
			signalMapperMock.Verify(x => x.ConvertRealValueToAnalogSignalValue(It.IsAny<int>(), It.IsAny<double>()));
		}

		[Fact]
		public void TryWriteAnalogSignal_Failed()
		{
			int signalId = 5;
			Mock<IAnalogPoint> analogPointMock = new Mock<IAnalogPoint>();
			analogPointMock.Setup(x => x.Write(It.IsAny<IModbusClient>(), It.IsAny<int>())).Returns(RtuConnectionResponse.CommandFailed);
			dataStaticCacheMock.Setup(x => x.FindAnalogPoint(signalId)).Returns(analogPointMock.Object);
			signalMapperMock.Setup(x => x.ConvertRealValueToAnalogSignalValue(It.IsAny<int>(), It.IsAny<double>())).Returns(It.IsAny<int>());

			var commandState = modbusDriver.WriteAnalogSignal(signalId, It.IsAny<double>());

			Assert.Equal(RtuConnectionResponse.CommandFailed, commandState);
			dataStaticCacheMock.Verify(x => x.FindAnalogPoint(signalId));
			analogPointMock.Verify(x => x.Write(It.IsAny<IModbusClient>(), It.IsAny<int>()));
			signalMapperMock.Verify(x => x.ConvertRealValueToAnalogSignalValue(It.IsAny<int>(), It.IsAny<double>()));
		}

		[Fact]
		public void TryWriteDiscreteSignal_Successful()
		{
			int signalId = 5;
			Mock<IDigitalPoint> digitalPointMock = new Mock<IDigitalPoint>();
			digitalPointMock.Setup(x => x.Write(It.IsAny<IModbusClient>(), It.IsAny<byte>())).Returns(RtuConnectionResponse.CommandExecuted);
			dataStaticCacheMock.Setup(x => x.FindDiscretePoint(signalId)).Returns(digitalPointMock.Object);
			signalMapperMock.Setup(x => x.ConvertStateToDiscreteSignalValue(It.IsAny<int>(), It.IsAny<string>())).Returns(It.IsAny<byte>());

			var commandState = modbusDriver.WriteDiscreteSignal(signalId, It.IsAny<string>());

			Assert.Equal(RtuConnectionResponse.CommandExecuted, commandState);
			dataStaticCacheMock.Verify(x => x.FindDiscretePoint(signalId));
			digitalPointMock.Verify(x => x.Write(It.IsAny<IModbusClient>(), It.IsAny<byte>()));
			signalMapperMock.Verify(x => x.ConvertStateToDiscreteSignalValue(It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public void TryWriteDiscreteSignal_Failed()
		{
			int signalId = 5;
			Mock<IDigitalPoint> digitalPointMock = new Mock<IDigitalPoint>();
			digitalPointMock.Setup(x => x.Write(It.IsAny<IModbusClient>(), It.IsAny<byte>())).Returns(RtuConnectionResponse.CommandFailed);
			dataStaticCacheMock.Setup(x => x.FindDiscretePoint(signalId)).Returns(digitalPointMock.Object);
			signalMapperMock.Setup(x => x.ConvertStateToDiscreteSignalValue(It.IsAny<int>(), It.IsAny<string>())).Returns(It.IsAny<byte>());

			var commandState = modbusDriver.WriteDiscreteSignal(signalId, It.IsAny<string>());

			Assert.Equal(RtuConnectionResponse.CommandFailed, commandState);
			dataStaticCacheMock.Verify(x => x.FindDiscretePoint(signalId));
			digitalPointMock.Verify(x => x.Write(It.IsAny<IModbusClient>(), It.IsAny<byte>()));
			signalMapperMock.Verify(x => x.ConvertStateToDiscreteSignalValue(It.IsAny<int>(), It.IsAny<string>()));
		}
	}
}
