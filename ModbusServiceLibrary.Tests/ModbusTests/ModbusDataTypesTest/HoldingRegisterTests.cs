using ModbusServiceLibrary.Modbus.ModbusClient;
using ModbusServiceLibrary.Modbus.ModbusConnection;
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
			modbusClientMock.Setup(x => x.ReadHoldingRegisters(holdingRegister.Id, holdingRegister.Address, 1, out mockReadValues)).Returns(RtuConnectionResponse.CommandExecuted);

			var commandState = holdingRegister.Read(modbusClientMock.Object, out ushort readValue);

			Assert.Equal(RtuConnectionResponse.CommandExecuted, commandState);
			Assert.Equal(mockReadValues[0], readValue);
			modbusClientMock.Verify(x => x.ReadHoldingRegisters(holdingRegister.Id, holdingRegister.Address, 1, out mockReadValues));
		}
		[Fact]
		public void Read_Failed()
		{
			ushort[] mockReadValues = { 10 };
			modbusClientMock.Setup(x => x.ReadHoldingRegisters(holdingRegister.Id, holdingRegister.Address, 1, out mockReadValues)).Returns(RtuConnectionResponse.CommandFailed);

			var commandState = holdingRegister.Read(modbusClientMock.Object, out ushort readValue);

			Assert.Equal(RtuConnectionResponse.CommandFailed, commandState);
			modbusClientMock.Verify(x => x.ReadHoldingRegisters(holdingRegister.Id, holdingRegister.Address, 1, out mockReadValues));
		}

		[Fact]
		public void Write_Successful()
		{
			int newValue = 20;
			modbusClientMock.Setup(x => x.WriteSingleHoldingRegister(holdingRegister.Id, holdingRegister.Address, newValue)).Returns(RtuConnectionResponse.CommandExecuted);

			var commandState = holdingRegister.Write(modbusClientMock.Object, newValue);

			Assert.Equal(RtuConnectionResponse.CommandExecuted, commandState);
		}

		[Fact]
		public void Write_Failed()
		{
			int newValue = 20;
			modbusClientMock.Setup(x => x.WriteSingleHoldingRegister(holdingRegister.Id, holdingRegister.Address, newValue)).Returns(RtuConnectionResponse.CommandFailed);

			var commandState = holdingRegister.Write(modbusClientMock.Object, newValue);
	
			Assert.Equal(RtuConnectionResponse.CommandFailed, commandState);
		}
	}
}
