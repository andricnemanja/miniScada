using ModbusServiceLibrary.Modbus.ModbusClient;
using ModbusServiceLibrary.Modbus.ModbusDataTypes;
using Moq;
using Xunit;

namespace ModbusServiceLibrary.Tests.ModbusTests.ModbusDataTypesTest
{
	public class DigitalInputTests
	{
		private readonly DigitalInput digitalInput;
		private readonly Mock<IModbusClient> modbusClientMock;
		public DigitalInputTests()
		{
			digitalInput = ModbusTypesTestData.GetDigitalInput();
			modbusClientMock = new Mock<IModbusClient>();
		}

		[Fact]
		public void Read_Successful()
		{
			bool[] mockReadValues = { true, true };
			modbusClientMock.Setup(x => x.ReadInputs(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), out mockReadValues)).Returns(true);

			bool isSuccessful = digitalInput.Read(modbusClientMock.Object, out byte readValue);

			Assert.True(isSuccessful);
			Assert.Equal(3, readValue);
			modbusClientMock.Verify(x => x.ReadInputs(digitalInput.RtuId, digitalInput.Address, digitalInput.Length, out It.Ref<bool[]>.IsAny));
		}

		[Fact]
		public void Read_Failed()
		{
			bool[] mockReadValues = { true, false };
			modbusClientMock.Setup(x => x.ReadInputs(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), out mockReadValues)).Returns(false);

			bool isSuccessful = digitalInput.Read(modbusClientMock.Object, out byte readValue);

			Assert.False(isSuccessful);
			modbusClientMock.Verify(x => x.ReadInputs(digitalInput.RtuId, digitalInput.Address, digitalInput.Length, out It.Ref<bool[]>.IsAny));
		}

		[Fact]
		public void Write_Failed()
		{
			byte newValueByte = 2;

			bool isSuccessful = digitalInput.Write(modbusClientMock.Object, newValueByte);

			Assert.False(isSuccessful);
		}
	}
}
