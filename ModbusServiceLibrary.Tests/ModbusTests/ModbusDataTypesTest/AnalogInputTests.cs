﻿using ModbusServiceLibrary.Modbus.ModbusClient;
using ModbusServiceLibrary.Modbus.ModbusDataTypes;
using Moq;
using Xunit;

namespace ModbusServiceLibrary.Tests.ModbusTests.ModbusDataTypesTest
{
	public class AnalogInputTests
	{
		private readonly AnalogInput analogInput;
		private readonly Mock<IModbusClient> modbusClientMock;
		public AnalogInputTests()
		{
			analogInput = new AnalogInput(1, 1, 1, 1, 1);
			modbusClientMock = new Mock<IModbusClient>();
		}

		[Fact]
		public void Read_Successful()
		{
			ushort[] mockReadValues = { 1, 2 };
			modbusClientMock.Setup(x => x.ReadInputRegisters(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), out mockReadValues)).Returns(true);

			bool isSuccessful = analogInput.Read(modbusClientMock.Object, out ushort readValue);

			Assert.True(isSuccessful);
			Assert.Equal(mockReadValues[0], readValue);
			modbusClientMock.Verify(x => x.ReadInputRegisters(analogInput.RtuId, analogInput.Address, 1, out It.Ref<ushort[]>.IsAny));
		}
		[Fact]
		public void Read_Failed()
		{
			ushort[] mockReadValues = {};
			modbusClientMock.Setup(x => x.ReadInputRegisters(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), out mockReadValues)).Returns(false);

			bool isSuccessful = analogInput.Read(modbusClientMock.Object, out ushort readValue);

			Assert.False(isSuccessful);
			modbusClientMock.Verify(x => x.ReadInputRegisters(analogInput.RtuId, analogInput.Address, 1, out It.Ref<ushort[]>.IsAny));
		}

		[Fact]
		public void Write_Failed()
		{
			bool isSuccessful = analogInput.Write(modbusClientMock.Object, It.IsAny<int>());
	
			Assert.False(isSuccessful);
		}
	}
}
