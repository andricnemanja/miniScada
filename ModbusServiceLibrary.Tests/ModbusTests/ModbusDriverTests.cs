using ModbusServiceLibrary.Modbus;
using ModbusServiceLibrary.Modbus.ModbusClient;
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
			analogPointMock.Setup(x => x.TryRead(It.IsAny<IModbusClient>(), out It.Ref<ushort>.IsAny)).Returns(true);
			dataStaticCacheMock.Setup(x => x.FindAnalogPoint(signalId)).Returns(analogPointMock.Object);
			signalMapperMock.Setup(x => x.ConvertAnalogSignalToRealValue(It.IsAny<int>(), It.IsAny<double>())).Returns(readValueMock);

			bool isSuccessful = modbusDriver.TryReadAnalogSignal(signalId, out double readValue);

			Assert.True(isSuccessful);
			Assert.Equal(readValue, readValueMock);
			dataStaticCacheMock.Verify(x => x.FindAnalogPoint(signalId));
			analogPointMock.Verify(x => x.TryRead(It.IsAny<IModbusClient>(), out It.Ref<ushort>.IsAny));
			signalMapperMock.Verify(x => x.ConvertAnalogSignalToRealValue(It.IsAny<int>(), It.IsAny<double>()));
		}

		[Fact]
		public void TryReadAnalogSignal_Failed()
		{
			double readValueMock = 0;
			int signalId = 5;
			Mock<IAnalogPoint> analogPointMock = new Mock<IAnalogPoint>();
			analogPointMock.Setup(x => x.TryRead(It.IsAny<IModbusClient>(), out It.Ref<ushort>.IsAny)).Returns(false);
			dataStaticCacheMock.Setup(x => x.FindAnalogPoint(signalId)).Returns(analogPointMock.Object);
			signalMapperMock.Setup(x => x.ConvertAnalogSignalToRealValue(It.IsAny<int>(), It.IsAny<double>())).Returns(readValueMock);

			bool isSuccessful = modbusDriver.TryReadAnalogSignal(signalId, out double readValue);

			Assert.False(isSuccessful);
			dataStaticCacheMock.Verify(x => x.FindAnalogPoint(signalId));
			analogPointMock.Verify(x => x.TryRead(It.IsAny<IModbusClient>(), out It.Ref<ushort>.IsAny));
			signalMapperMock.Verify(x => x.ConvertAnalogSignalToRealValue(It.IsAny<int>(), It.IsAny<double>()), Times.Never);
		}

		[Fact]
		public void TryReadDiscreteSignal_Successful()
		{
			int signalId = 5;
			string signalStateMock = "Off";
			Mock<IDigitalPoint> digitalPointMock = new Mock<IDigitalPoint>();
			digitalPointMock.Setup(x => x.TryRead(It.IsAny<IModbusClient>(), out It.Ref<byte>.IsAny)).Returns(true);
			dataStaticCacheMock.Setup(x => x.FindDiscretePoint(signalId)).Returns(digitalPointMock.Object);
			signalMapperMock.Setup(x => x.ConvertDiscreteSignalValueToState(It.IsAny<int>(), It.IsAny<byte>())).Returns(signalStateMock);

			bool isSuccessful = modbusDriver.TryReadDiscreteSignal(signalId, out string readState);

			Assert.True(isSuccessful);
			Assert.Equal(signalStateMock, readState);
			dataStaticCacheMock.Verify(x => x.FindDiscretePoint(signalId));
			digitalPointMock.Verify(x => x.TryRead(It.IsAny<IModbusClient>(), out It.Ref<byte>.IsAny));
			signalMapperMock.Verify(x => x.ConvertDiscreteSignalValueToState(It.IsAny<int>(), It.IsAny<byte>()));
		}

		[Fact]
		public void TryReadDiscreteSignal_Failed()
		{
			int signalId = 5;
			Mock<IDigitalPoint> digitalPointMock = new Mock<IDigitalPoint>();
			digitalPointMock.Setup(x => x.TryRead(It.IsAny<IModbusClient>(), out It.Ref<byte>.IsAny)).Returns(false);
			dataStaticCacheMock.Setup(x => x.FindDiscretePoint(signalId)).Returns(digitalPointMock.Object);
			signalMapperMock.Setup(x => x.ConvertDiscreteSignalValueToState(It.IsAny<int>(), It.IsAny<byte>())).Returns(It.IsAny<string>());

			bool isSuccessful = modbusDriver.TryReadDiscreteSignal(signalId, out string readState);

			Assert.False(isSuccessful);
			dataStaticCacheMock.Verify(x => x.FindDiscretePoint(signalId));
			digitalPointMock.Verify(x => x.TryRead(It.IsAny<IModbusClient>(), out It.Ref<byte>.IsAny));
			signalMapperMock.Verify(x => x.ConvertDiscreteSignalValueToState(It.IsAny<int>(), It.IsAny<byte>()), Times.Never);
		}

		[Fact]
		public void TryWriteAnalogSignal_Successful()
		{
			int signalId = 5;
			Mock<IAnalogPoint> analogPointMock = new Mock<IAnalogPoint>();
			analogPointMock.Setup(x => x.TryWrite(It.IsAny<IModbusClient>(), It.IsAny<int>())).Returns(true);
			dataStaticCacheMock.Setup(x => x.FindAnalogPoint(signalId)).Returns(analogPointMock.Object);
			signalMapperMock.Setup(x => x.ConvertRealValueToAnalogSignalValue(It.IsAny<int>(), It.IsAny<double>())).Returns(It.IsAny<int>());

			bool isSuccessful = modbusDriver.TryWriteAnalogSignal(signalId, It.IsAny<double>());

			Assert.True(isSuccessful);
			dataStaticCacheMock.Verify(x => x.FindAnalogPoint(signalId));
			analogPointMock.Verify(x => x.TryWrite(It.IsAny<IModbusClient>(), It.IsAny<int>()));
			signalMapperMock.Verify(x => x.ConvertRealValueToAnalogSignalValue(It.IsAny<int>(), It.IsAny<double>()));
		}

		[Fact]
		public void TryWriteAnalogSignal_Failed()
		{
			int signalId = 5;
			Mock<IAnalogPoint> analogPointMock = new Mock<IAnalogPoint>();
			analogPointMock.Setup(x => x.TryWrite(It.IsAny<IModbusClient>(), It.IsAny<int>())).Returns(false);
			dataStaticCacheMock.Setup(x => x.FindAnalogPoint(signalId)).Returns(analogPointMock.Object);
			signalMapperMock.Setup(x => x.ConvertRealValueToAnalogSignalValue(It.IsAny<int>(), It.IsAny<double>())).Returns(It.IsAny<int>());

			bool isSuccessful = modbusDriver.TryWriteAnalogSignal(signalId, It.IsAny<double>());

			Assert.False(isSuccessful);
			dataStaticCacheMock.Verify(x => x.FindAnalogPoint(signalId));
			analogPointMock.Verify(x => x.TryWrite(It.IsAny<IModbusClient>(), It.IsAny<int>()));
			signalMapperMock.Verify(x => x.ConvertRealValueToAnalogSignalValue(It.IsAny<int>(), It.IsAny<double>()));
		}

		[Fact]
		public void TryWriteDiscreteSignal_Successful()
		{
			int signalId = 5;
			Mock<IDigitalPoint> digitalPointMock = new Mock<IDigitalPoint>();
			digitalPointMock.Setup(x => x.TryWrite(It.IsAny<IModbusClient>(), It.IsAny<byte>())).Returns(true);
			dataStaticCacheMock.Setup(x => x.FindDiscretePoint(signalId)).Returns(digitalPointMock.Object);
			signalMapperMock.Setup(x => x.ConvertStateToDiscreteSignalValue(It.IsAny<int>(), It.IsAny<string>())).Returns(It.IsAny<byte>());

			bool isSuccessful = modbusDriver.TryWriteDiscreteSignal(signalId, It.IsAny<string>());

			Assert.True(isSuccessful);
			dataStaticCacheMock.Verify(x => x.FindDiscretePoint(signalId));
			digitalPointMock.Verify(x => x.TryWrite(It.IsAny<IModbusClient>(), It.IsAny<byte>()));
			signalMapperMock.Verify(x => x.ConvertStateToDiscreteSignalValue(It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public void TryWriteDiscreteSignal_Failed()
		{
			int signalId = 5;
			Mock<IDigitalPoint> digitalPointMock = new Mock<IDigitalPoint>();
			digitalPointMock.Setup(x => x.TryWrite(It.IsAny<IModbusClient>(), It.IsAny<byte>())).Returns(false);
			dataStaticCacheMock.Setup(x => x.FindDiscretePoint(signalId)).Returns(digitalPointMock.Object);
			signalMapperMock.Setup(x => x.ConvertStateToDiscreteSignalValue(It.IsAny<int>(), It.IsAny<string>())).Returns(It.IsAny<byte>());

			bool isSuccessful = modbusDriver.TryWriteDiscreteSignal(signalId, It.IsAny<string>());

			Assert.False(isSuccessful);
			dataStaticCacheMock.Verify(x => x.FindDiscretePoint(signalId));
			digitalPointMock.Verify(x => x.TryWrite(It.IsAny<IModbusClient>(), It.IsAny<byte>()));
			signalMapperMock.Verify(x => x.ConvertStateToDiscreteSignalValue(It.IsAny<int>(), It.IsAny<string>()));
		}
	}
}
