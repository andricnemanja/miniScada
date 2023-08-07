using ModbusServiceLibrary.Modbus.ModbusClient;
using ModbusServiceLibrary.Modbus.ModbusDataTypes;
using Moq;
using Xunit;

namespace ModbusServiceLibrary.Tests.ModbusTests.ModbusDataTypesTest
{
	public class CoilTests
	{
		private readonly Coil coil;
		private readonly Mock<IModbusClient> modbusClientMock;
		public CoilTests()
		{
			coil = ModbusTypesTestData.GetCoil();
			modbusClientMock = new Mock<IModbusClient>();
		}

		[Fact]
		public void Read_Successful()
		{
			bool[] mockReadValues = { true, true };
			modbusClientMock.Setup(x => x.TryReadCoils(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), out mockReadValues)).Returns(true);

			bool isSuccessful = coil.TryRead(modbusClientMock.Object, out byte readValue);

			Assert.True(isSuccessful);
			Assert.Equal(3, readValue);
			modbusClientMock.Verify(x => x.TryReadCoils(coil.RtuId, coil.Address, coil.Length, out It.Ref<bool[]>.IsAny));
		}

		[Fact]
		public void Read_Failed()
		{
			bool[] mockReadValues = { true, false };
			modbusClientMock.Setup(x => x.TryReadCoils(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), out mockReadValues)).Returns(false);

			bool isSuccessful = coil.TryRead(modbusClientMock.Object, out byte readValue);

			Assert.False(isSuccessful);
			modbusClientMock.Verify(x => x.TryReadCoils(coil.RtuId, coil.Address, coil.Length, out It.Ref<bool[]>.IsAny));
		}

		[Fact]
		public void Write_Successful()
		{
			bool[] newValueBool = { true, false };
			byte newValueByte = 2;
			modbusClientMock.Setup(x => x.TryWriteCoils(coil.RtuId, coil.Address, newValueBool)).Returns(true);

			bool isSuccessful = coil.TryWrite(modbusClientMock.Object, newValueByte);

			Assert.True(isSuccessful);
			modbusClientMock.Verify(x => x.TryWriteCoils(coil.RtuId, coil.Address, newValueBool));
		}

		[Fact]
		public void Write_Failed()
		{
			bool[] newValueBool = { true, false };
			byte newValueByte = 2;
			modbusClientMock.Setup(x => x.TryWriteCoils(coil.RtuId, coil.Address, newValueBool)).Returns(false);

			bool isSuccessful = coil.TryWrite(modbusClientMock.Object, newValueByte);

			Assert.False(isSuccessful);
			modbusClientMock.Verify(x => x.TryWriteCoils(coil.RtuId, coil.Address, newValueBool));
		}
	}
}
