using ModbusServiceLibrary.Modbus.ModbusClient;
using ModbusServiceLibrary.Modbus.ModbusConnection;
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
			modbusClientMock.Setup(x => x.ReadInputs(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), out mockReadValues)).Returns(RtuConnectionResponse.CommandExecuted);

			var commandState = digitalInput.Read(modbusClientMock.Object, out byte readValue);

			Assert.Equal(RtuConnectionResponse.CommandExecuted, commandState);
			Assert.Equal(3, readValue);
			modbusClientMock.Verify(x => x.ReadInputs(digitalInput.RtuId, digitalInput.Address, digitalInput.Length, out It.Ref<bool[]>.IsAny));
		}

		[Fact]
		public void Read_Failed()
		{
			bool[] mockReadValues = { true, false };
			modbusClientMock.Setup(x => x.ReadInputs(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), out mockReadValues)).Returns(RtuConnectionResponse.CommandFailed);

			var commandState = digitalInput.Read(modbusClientMock.Object, out byte readValue);

			Assert.Equal(RtuConnectionResponse.CommandFailed, commandState);
			modbusClientMock.Verify(x => x.ReadInputs(digitalInput.RtuId, digitalInput.Address, digitalInput.Length, out It.Ref<bool[]>.IsAny));
		}

		[Fact]
		public void Write_Failed()
		{
			byte newValueByte = 2;

			var commandState = digitalInput.Write(modbusClientMock.Object, newValueByte);

			Assert.Equal(RtuConnectionResponse.UnsupportedCommand, commandState);
		}
	}
}
