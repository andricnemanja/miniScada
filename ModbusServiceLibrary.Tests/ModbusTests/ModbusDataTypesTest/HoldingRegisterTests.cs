using ModbusServiceLibrary.Modbus.ModbusClient;
using ModbusServiceLibrary.Modbus.ModbusDataTypes;
using Moq;
using Xunit;

namespace ModbusServiceLibrary.Tests.ModbusTests.ModbusDataTypesTest
{
	public class HoldingRegisterTests
	{
		private readonly HoldingRegister holdingRegister;
		private readonly Mock<IModbusClient> modbusClientMock;
		public HoldingRegisterTests()
		{
			holdingRegister = ModbusTypesTestData.GetHoldingRegister();
			modbusClientMock = new Mock<IModbusClient>();
		}

		[Fact]
		public void Read_Successful()
		{
			ushort[] mockReadValues = { 10 };
			modbusClientMock.Setup(x => x.ReadHoldingRegisters(holdingRegister.Id, holdingRegister.Address, 1, out mockReadValues)).Returns(true);

			bool isSuccessful = holdingRegister.Read(modbusClientMock.Object, out ushort readValue);

			Assert.True(isSuccessful);
			Assert.Equal(mockReadValues[0], readValue);
			modbusClientMock.Verify(x => x.ReadHoldingRegisters(holdingRegister.Id, holdingRegister.Address, 1, out mockReadValues));
		}
		[Fact]
		public void Read_Failed()
		{
			ushort[] mockReadValues = { 10 };
			modbusClientMock.Setup(x => x.ReadHoldingRegisters(holdingRegister.Id, holdingRegister.Address, 1, out mockReadValues)).Returns(false);

			bool isSuccessful = holdingRegister.Read(modbusClientMock.Object, out ushort readValue);

			Assert.False(isSuccessful);
			modbusClientMock.Verify(x => x.ReadHoldingRegisters(holdingRegister.Id, holdingRegister.Address, 1, out mockReadValues));
		}

		[Fact]
		public void Write_Successful()
		{
			int newValue = 20;
			modbusClientMock.Setup(x => x.WriteSingleHoldingRegister(holdingRegister.Id, holdingRegister.Address, newValue)).Returns(true);

			bool isSuccessful = holdingRegister.Write(modbusClientMock.Object, newValue);

			Assert.True(isSuccessful);
		}

		[Fact]
		public void Write_Failed()
		{
			int newValue = 20;
			modbusClientMock.Setup(x => x.WriteSingleHoldingRegister(holdingRegister.Id, holdingRegister.Address, newValue)).Returns(false);

			bool isSuccessful = holdingRegister.Write(modbusClientMock.Object, newValue);
	
			Assert.False(isSuccessful);
		}
	}
}
