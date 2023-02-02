using ModbusServiceLibrary.ModbusClient;
using Moq;
using NModbus;
using Xunit;

namespace ModbusServiceLibrary.Tests.ModbusClientTests
{
	public class NModbusClientTests
	{
		private Mock<IModbusMaster> modbusMasterMock;
		private NModbusClient2 modbusClient;
		public NModbusClientTests() 
		{
			modbusMasterMock = new Mock<IModbusMaster>();
			modbusClient = new NModbusClient(modbusMasterMock.Object);
		}

		[Fact]
		private void TryReadSingleHoldingRegister_ClientAvailable()
		{
			//Arrange
			ushort[] actualSignalValue = { 10 };
			modbusMasterMock.Setup(m => m.ReadHoldingRegisters(It.IsAny<byte>(), It.IsAny<ushort>(), It.IsAny<ushort>())).Returns(actualSignalValue);

			//Act
			bool returnValue = modbusClient.TryReadSingleHoldingRegister(1, out int readValue);

			//Assert
			Assert.True(returnValue);
			Assert.Equal(actualSignalValue[0], readValue);
			modbusMasterMock.Verify(m => m.ReadHoldingRegisters(1, 1, 1));
		}

		[Fact]
		private void TryReadSingleHoldingRegister_ClientNotAvailable()
		{
			//Arrange
			ushort[] actualSignalValue = { 10 };
			modbusMasterMock.Setup(m => m.ReadHoldingRegisters(It.IsAny<byte>(), It.IsAny<ushort>(), It.IsAny<ushort>())).Throws(new System.Exception());

			//Act
			bool returnValue = modbusClient.TryReadSingleHoldingRegister(1, out int readValue);

			//Assert
			Assert.False(returnValue);
			Assert.Equal(0, readValue);
			modbusMasterMock.Verify(m => m.ReadHoldingRegisters(1, 1, 1));
		}

		[Fact]
		private void TryWriteSingleHoldingRegister_ClientAvailable()
		{
			//Arrange
			int writeValue = 10;
			modbusMasterMock.Setup(m => m.WriteSingleRegister(It.IsAny<byte>(), It.IsAny<ushort>(), It.IsAny<ushort>()));

			//Act
			bool returnValue = modbusClient.TryWriteSingleHoldingRegister(1, writeValue);

			//Assert
			Assert.True(returnValue);
			modbusMasterMock.Verify(m => m.WriteSingleRegister(It.IsAny<byte>(), It.IsAny<ushort>(), It.IsAny<ushort>()));
		}

		[Fact]
		private void TryWriteSingleHoldingRegister_ClientNotAvailable()
		{
			//Arrange
			int writeValue = 10;
			modbusMasterMock.Setup(m => m.WriteSingleRegister(It.IsAny<byte>(), It.IsAny<ushort>(), It.IsAny<ushort>())).Throws(new System.Exception());

			//Act
			bool returnValue = modbusClient.TryWriteSingleHoldingRegister(1, writeValue);

			//Assert
			Assert.False(returnValue);
			modbusMasterMock.Verify(m => m.WriteSingleRegister(It.IsAny<byte>(), It.IsAny<ushort>(), It.IsAny<ushort>()));
		}

		[Theory]
		[InlineData(new bool[1] { false }, 0)]
		[InlineData(new bool[1] { true }, 1)]
		private void TryReadCoils_OneBitSignal_ClientAvailable(bool[] actualSignalValue, byte expectedReadValue)
		{
			//Arrange
			modbusMasterMock.Setup(m => m.ReadCoils(It.IsAny<byte>(), It.IsAny<ushort>(), It.IsAny<ushort>())).Returns(actualSignalValue);

			//Act
			bool returnValue = modbusClient.TryReadCoils(1, Model.Signals.DiscreteSignalType.OneBit, out byte readValue);

			//Assert
			Assert.True(returnValue);
			Assert.Equal(expectedReadValue, readValue);
			modbusMasterMock.Verify(m => m.ReadCoils(It.IsAny<byte>(), It.IsAny<ushort>(), It.IsAny<ushort>()));
		}

		[Fact]
		private void TryReadCoils_OneBitSignal_ClientNotAvailable()
		{
			//Arrange
			modbusMasterMock.Setup(m => m.ReadCoils(It.IsAny<byte>(), It.IsAny<ushort>(), It.IsAny<ushort>())).Throws(new System.Exception());

			//Act
			bool returnValue = modbusClient.TryReadCoils(1, Model.Signals.DiscreteSignalType.OneBit, out byte readValue);

			//Assert
			Assert.False(returnValue);
			modbusMasterMock.Verify(m => m.ReadCoils(It.IsAny<byte>(), It.IsAny<ushort>(), It.IsAny<ushort>()));
		}

		[Theory]
		[InlineData(new bool[2] { false, false }, 0)]
		[InlineData(new bool[2] { false, true }, 1)]
		[InlineData(new bool[2] { true, false }, 2)]
		[InlineData(new bool[2] { true, true }, 3)]
		private void TryReadCoils_TwoBitSignal_ClientAvailable(bool[] actualSignalValue, byte expectedReadValue)
		{
			//Arrange
			modbusMasterMock.Setup(m => m.ReadCoils(It.IsAny<byte>(), It.IsAny<ushort>(), It.IsAny<ushort>())).Returns(actualSignalValue);

			//Act
			bool returnValue = modbusClient.TryReadCoils(1, Model.Signals.DiscreteSignalType.TwoBit, out byte readValue);

			//Assert
			Assert.True(returnValue);
			Assert.Equal(expectedReadValue, readValue);
			modbusMasterMock.Verify(m => m.ReadCoils(It.IsAny<byte>(), It.IsAny<ushort>(), It.IsAny<ushort>()));
		}


		[Fact]
		private void TryReadCoils_TwoBitSignal_ClientNotAvailable()
		{
			//Arrange
			modbusMasterMock.Setup(m => m.ReadCoils(It.IsAny<byte>(), It.IsAny<ushort>(), It.IsAny<ushort>())).Throws(new System.Exception());

			//Act
			bool returnValue = modbusClient.TryReadCoils(1, Model.Signals.DiscreteSignalType.TwoBit, out byte readValue);

			//Assert
			Assert.False(returnValue);
			modbusMasterMock.Verify(m => m.ReadCoils(It.IsAny<byte>(), It.IsAny<ushort>(), It.IsAny<ushort>()));
		}


		[Fact]
		private void TryWriteCoils_ClientAvailable()
		{
			//Arrange
			modbusMasterMock.Setup(m => m.WriteMultipleCoils(It.IsAny<byte>(), It.IsAny<ushort>(), It.IsAny<bool[]>()));

			//Act
			bool returnValue = modbusClient.TryWriteCoils(1, Model.Signals.DiscreteSignalType.OneBit, 1);

			//Assert
			Assert.True(returnValue);
			modbusMasterMock.Verify(m => m.WriteMultipleCoils(It.IsAny<byte>(), It.IsAny<ushort>(), It.IsAny<bool[]>()));
		}

		[Fact]
		private void TryWriteCoils_ClientNotAvailable()
		{
			//Arrange
			modbusMasterMock.Setup(m => m.WriteMultipleCoils(It.IsAny<byte>(), It.IsAny<ushort>(), It.IsAny<bool[]>())).Throws(new System.Exception());

			//Act
			bool returnValue = modbusClient.TryWriteCoils(1, Model.Signals.DiscreteSignalType.OneBit, 1);

			//Assert
			Assert.False(returnValue);
			modbusMasterMock.Verify(m => m.WriteMultipleCoils(It.IsAny<byte>(), It.IsAny<ushort>(), It.IsAny<bool[]>()));
		}

		[Fact]
		private void Disconect()
		{
			//Arrange
			modbusMasterMock.Setup(m => m.Dispose());

			//Act
			modbusClient.Disconnect();

			//Assert
			modbusMasterMock.Verify(m => m.Dispose());
		}

	}
}
