using System.Linq;
using ModbusServiceLibrary.ModbusClient;
using ModbusServiceLibrary.ModbusCommunication;
using ModbusServiceLibrary.Model.RTU;
using ModbusServiceLibrary.ServiceReader;
using Moq;
using Xunit;

namespace ModbusServiceLibrary.Tests.ModbusConnecitonTests
{
	public class ModbusSimulatorClientTests
	{
		private ModbusSimulatorClient modbusSimulatorClient;
		private Mock<IRtuConfiguration> modelServiceReaderMock;
		public ModbusSimulatorClientTests()
		{
			modelServiceReaderMock = new Mock<IRtuConfiguration>();
			modelServiceReaderMock.Setup(x => x.RtuList).Returns(RtuTestData.GetRtuTestList());
			modbusSimulatorClient = new ModbusSimulatorClient(modelServiceReaderMock.Object);
			modelServiceReaderMock.Object.InitializeData();
		}

		[Theory]
		[InlineData(1)]
		[InlineData(2)]
		[InlineData(3)]
		public void FindRtu_RtuExist(int rtuId)
		{
			//Arrange
			RTU expectedRtu = RtuTestData.GetRtuTestList().Where(r => r.RTUData.ID == rtuId).FirstOrDefault();

			//Act
			modbusSimulatorClient.TryFindRtu(rtuId, out RTU findRtu);

			//Assert
			Assert.Equal(expectedRtu.RTUData.ID, findRtu.RTUData.ID);
		}

		#region TryReadAnalogInput
		[Fact]
		private void TryReadAnalogInput_RtuExist_ClientAvailable()
		{
			//Arrange
			RTU rtu = modelServiceReaderMock.Object.RtuList.Where(r => r.RTUData.ID == 1).FirstOrDefault();
			var nModbusClientMock = new Mock<IModbusClient>();
			int modbusClientReadValue = 101;
			nModbusClientMock.Setup(n => n.TryReadSingleHoldingRegister(1, out modbusClientReadValue)).Returns(true);
			rtu.Connection.Client = nModbusClientMock.Object;

			//Act
			bool returnValue = modbusSimulatorClient.TryReadAnalogInput(1, 1, out int readValue);

			//Assert
			Assert.True(returnValue);
			Assert.Equal(modbusClientReadValue, rtu.AnalogSignalValues.Where(c => c.AnalogSignal.Address == 1).FirstOrDefault().Value);
			nModbusClientMock.Verify(n => n.TryReadSingleHoldingRegister(1, out modbusClientReadValue));
		}
		[Fact]
		private void TryReadAnalogInput_RtuExist_ClientNotAvailable()
		{
			//Arrange
			RTU rtu = modelServiceReaderMock.Object.RtuList.Where(r => r.RTUData.ID == 1).FirstOrDefault();
			var nModbusClientMock = new Mock<IModbusClient>();
			int modbusClientReadValue = 10;
			nModbusClientMock.Setup(n => n.TryReadSingleHoldingRegister(1, out modbusClientReadValue)).Returns(false);
			rtu.Connection.Client = nModbusClientMock.Object;

			//Act
			bool returnValue = modbusSimulatorClient.TryReadAnalogInput(1, 1, out int readValue);

			//Assert
			Assert.False(returnValue);
			nModbusClientMock.Verify(n => n.TryReadSingleHoldingRegister(1, out modbusClientReadValue));
		}
		[Fact]
		private void TryReadAnalogInput_RtuDoesNotExist_ClientAvailable()
		{
			//Arrange
			RTU rtu = modelServiceReaderMock.Object.RtuList.Where(r => r.RTUData.ID == 1).FirstOrDefault();
			var nModbusClientMock = new Mock<IModbusClient>();
			int modbusClientReadValue = 10;
			nModbusClientMock.Setup(n => n.TryReadSingleHoldingRegister(1, out modbusClientReadValue)).Returns(true);
			rtu.Connection.Client = nModbusClientMock.Object;

			//Act
			bool returnValue = modbusSimulatorClient.TryReadAnalogInput(5, 1, out int readValue);

			//Assert
			Assert.False(returnValue);
			nModbusClientMock.Verify(n => n.TryReadSingleHoldingRegister(1, out modbusClientReadValue), Times.Never());
		}
		#endregion

		#region TryReadDiscreteInput
		[Fact]
		private void TryReadDiscreteInput_RtuExist_ClientAvailable()
		{
			//Arrange
			RTU rtu = modelServiceReaderMock.Object.RtuList.Where(r => r.RTUData.ID == 1).FirstOrDefault();
			var nModbusClientMock = new Mock<IModbusClient>();
			byte modbusClientReadValue = 0;
			nModbusClientMock.Setup(n => n.TryReadCoils(1, Model.Signals.DiscreteSignalType.OneBit, out modbusClientReadValue)).Returns(true);
			rtu.Connection.Client = nModbusClientMock.Object;

			//Act
			bool returnValue = modbusSimulatorClient.TryReadDiscreteInput(1, 1, out byte readValue);

			//Assert
			Assert.True(returnValue);
			Assert.Equal(modbusClientReadValue, rtu.DiscreteSignalValues.FirstOrDefault(c => c.DiscreteSignal.Address == 1).Value);
			nModbusClientMock.Verify(n => n.TryReadCoils(1, Model.Signals.DiscreteSignalType.OneBit, out modbusClientReadValue));
		}

		[Fact]
		private void TryReadDiscreteInput_RtuExist_ClientNotAvailable()
		{
			//Arrange
			RTU rtu = modelServiceReaderMock.Object.RtuList.Where(r => r.RTUData.ID == 1).FirstOrDefault();
			var nModbusClientMock = new Mock<IModbusClient>();
			byte modbusClientReadValue = 0;
			nModbusClientMock.Setup(n => n.TryReadCoils(1, Model.Signals.DiscreteSignalType.OneBit, out modbusClientReadValue)).Returns(false);
			rtu.Connection.Client = nModbusClientMock.Object;

			//Act
			bool returnValue = modbusSimulatorClient.TryReadDiscreteInput(1, 1, out byte readValue);

			//Assert
			Assert.False(returnValue);
			nModbusClientMock.Verify(n => n.TryReadCoils(1, Model.Signals.DiscreteSignalType.OneBit, out modbusClientReadValue));
		}

		[Fact]
		private void TryReadDiscreteInput_RtuDoesNotExist_ClientAvailable()
		{
			//Arrange
			RTU rtu = modelServiceReaderMock.Object.RtuList.Where(r => r.RTUData.ID == 1).FirstOrDefault();
			var nModbusClientMock = new Mock<IModbusClient>();
			byte modbusClientReadValue = 0;
			nModbusClientMock.Setup(n => n.TryReadCoils(1, Model.Signals.DiscreteSignalType.OneBit, out modbusClientReadValue)).Returns(true);
			rtu.Connection.Client = nModbusClientMock.Object;

			//Act
			bool returnValue = modbusSimulatorClient.TryReadDiscreteInput(5, 1, out byte readValue);

			//Assert
			Assert.False(returnValue);
			nModbusClientMock.Verify(n => n.TryReadCoils(1, Model.Signals.DiscreteSignalType.OneBit, out modbusClientReadValue), Times.Never());
		}
		#endregion

		#region TryWriteAnalogSignalValue
		[Fact]
		private void TryWriteAnalogSignalValue_RtuExist_ClientAvailable()
		{
			//Arrange
			RTU rtu = modelServiceReaderMock.Object.RtuList.Where(r => r.RTUData.ID == 1).FirstOrDefault();
			var nModbusClientMock = new Mock<IModbusClient>();
			int valueToWrite = 101;
			nModbusClientMock.Setup(n => n.TryWriteSingleHoldingRegister(1, valueToWrite)).Returns(true);
			rtu.Connection.Client = nModbusClientMock.Object;

			//Act
			bool returnValue = modbusSimulatorClient.TryWriteAnalogSignalValue(1, 1, valueToWrite);

			//Assert
			Assert.True(returnValue);
			Assert.Equal(valueToWrite, rtu.AnalogSignalValues.Where(c => c.AnalogSignal.Address == 1).FirstOrDefault().Value);
			nModbusClientMock.Verify(n => n.TryWriteSingleHoldingRegister(1, valueToWrite));
		}

		[Fact]
		private void TryWriteAnalogSignalValue_RtuDoesNotExist_ClientAvailable()
		{
			//Arrange
			RTU rtu = modelServiceReaderMock.Object.RtuList.Where(r => r.RTUData.ID == 1).FirstOrDefault();
			var nModbusClientMock = new Mock<IModbusClient>();
			int valueToWrite = 101;
			nModbusClientMock.Setup(n => n.TryWriteSingleHoldingRegister(1, valueToWrite)).Returns(true);
			rtu.Connection.Client = nModbusClientMock.Object;

			//Act
			bool returnValue = modbusSimulatorClient.TryWriteAnalogSignalValue(5, 1, valueToWrite);

			//Assert
			Assert.False(returnValue);
			nModbusClientMock.Verify(n => n.TryWriteSingleHoldingRegister(1, valueToWrite), Times.Never());
		}

		[Fact]
		private void TryWriteAnalogSignalValue_RtuExist_ClientNotAvailable()
		{
			//Arrange
			RTU rtu = modelServiceReaderMock.Object.RtuList.Where(r => r.RTUData.ID == 1).FirstOrDefault();
			var nModbusClientMock = new Mock<IModbusClient>();
			int valueToWrite = 101;
			nModbusClientMock.Setup(n => n.TryWriteSingleHoldingRegister(1, valueToWrite)).Returns(false);
			rtu.Connection.Client = nModbusClientMock.Object;

			//Act
			bool returnValue = modbusSimulatorClient.TryWriteAnalogSignalValue(1, 1, valueToWrite);

			//Assert
			Assert.False(returnValue);
			nModbusClientMock.Verify(n => n.TryWriteSingleHoldingRegister(1, valueToWrite));
		}
		#endregion

		#region TryWriteDiscreteSignalValue
		[Fact]
		private void TryWriteDiscreteSignal_RtuExist_ClientAvailable()
		{
			//Arrange
			RTU rtu = modelServiceReaderMock.Object.RtuList.Where(r => r.RTUData.ID == 1).FirstOrDefault();
			var nModbusClientMock = new Mock<IModbusClient>();
			byte valueToWrite = 1;
			nModbusClientMock.Setup(n => n.TryWriteCoils(1, Model.Signals.DiscreteSignalType.OneBit ,valueToWrite)).Returns(true);
			rtu.Connection.Client = nModbusClientMock.Object;

			//Act
			bool returnValue = modbusSimulatorClient.TryWriteDiscreteSignalValue(1, 1, valueToWrite);

			//Assert
			Assert.True(returnValue);
			Assert.Equal(valueToWrite, rtu.DiscreteSignalValues.Where(c => c.DiscreteSignal.Address == 1).FirstOrDefault().Value);
			nModbusClientMock.Verify(n => n.TryWriteCoils(1, Model.Signals.DiscreteSignalType.OneBit, valueToWrite));
		}

		[Fact]
		private void TryWriteDiscreteSignal_RtuDoesNotExist_ClientAvailable()
		{
			//Arrange
			RTU rtu = modelServiceReaderMock.Object.RtuList.Where(r => r.RTUData.ID == 1).FirstOrDefault();
			var nModbusClientMock = new Mock<IModbusClient>();
			byte valueToWrite = 1;
			nModbusClientMock.Setup(n => n.TryWriteCoils(1, Model.Signals.DiscreteSignalType.OneBit, valueToWrite)).Returns(false);
			rtu.Connection.Client = nModbusClientMock.Object;

			//Act
			bool returnValue = modbusSimulatorClient.TryWriteDiscreteSignalValue(5, 1, valueToWrite);

			//Assert
			Assert.False(returnValue);
			nModbusClientMock.Verify(n => n.TryWriteCoils(1, Model.Signals.DiscreteSignalType.OneBit, valueToWrite), Times.Never());
		}

		[Fact]
		private void TryWriteDiscreteSignal_RtuExist_ClientNotAvailable()
		{
			//Arrange
			RTU rtu = modelServiceReaderMock.Object.RtuList.Where(r => r.RTUData.ID == 1).FirstOrDefault();
			var nModbusClientMock = new Mock<IModbusClient>();
			byte valueToWrite = 1;
			nModbusClientMock.Setup(n => n.TryWriteCoils(1, Model.Signals.DiscreteSignalType.OneBit, valueToWrite)).Returns(false);
			rtu.Connection.Client = nModbusClientMock.Object;

			//Act
			bool returnValue = modbusSimulatorClient.TryWriteDiscreteSignalValue(1, 1, valueToWrite);

			//Assert
			Assert.False(returnValue);
			nModbusClientMock.Verify(n => n.TryWriteCoils(1, Model.Signals.DiscreteSignalType.OneBit, valueToWrite));
		}
		#endregion

	}
}
