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
		private Mock<IModelServiceReader> modelServiceReaderMock;
		public ModbusSimulatorClientTests()
		{
			modelServiceReaderMock = new Mock<IModelServiceReader>();
			modelServiceReaderMock.Setup(x => x.ReadAllRTUs()).Returns(RtuTestData.GetRtuTestList());
			modbusSimulatorClient = new ModbusSimulatorClient(modelServiceReaderMock.Object);
			modbusSimulatorClient.InitializeData();
		}

		[Fact]
		public void InitializeData()
		{			
			//Act
			modbusSimulatorClient.InitializeData();

			//Assert
			modelServiceReaderMock.Verify(m => m.ReadAllRTUs());
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
			RTU rtu = modbusSimulatorClient.RtuList.Where(r => r.RTUData.ID == 1).FirstOrDefault();
			var nModbusClientMock = new Mock<IModbusClient>();
			int modbusClientReadValue = 101;
			nModbusClientMock.Setup(n => n.TryReadSingleHoldingRegister(1, out modbusClientReadValue)).Returns(true);
			rtu.Connection.Client = nModbusClientMock.Object;

			//Act
			bool returnValue = modbusSimulatorClient.TryReadAnalogInput(1, 1, out int readValue);

			//Assert
			Assert.True(returnValue);
			Assert.Equal(modbusClientReadValue, rtu.AnalogSignalValues.Where(c => c.AnalogSignal.ID == 1).FirstOrDefault().Value);
			nModbusClientMock.Verify(n => n.TryReadSingleHoldingRegister(1, out modbusClientReadValue));
		}
		[Fact]
		private void TryReadAnalogInput_RtuExist_ClientNotAvailable()
		{
			//Arrange
			RTU rtu = modbusSimulatorClient.RtuList.Where(r => r.RTUData.ID == 1).FirstOrDefault();
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
			RTU rtu = modbusSimulatorClient.RtuList.Where(r => r.RTUData.ID == 1).FirstOrDefault();
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
			RTU rtu = modbusSimulatorClient.RtuList.Where(r => r.RTUData.ID == 1).FirstOrDefault();
			var nModbusClientMock = new Mock<IModbusClient>();
			bool modbusClientReadValue = true;
			nModbusClientMock.Setup(n => n.TryReadSingleCoil(1, out modbusClientReadValue)).Returns(true);
			rtu.Connection.Client = nModbusClientMock.Object;

			//Act
			bool returnValue = modbusSimulatorClient.TryReadDiscreteInput(1, 1, out bool readValue);

			//Assert
			Assert.True(returnValue);
			Assert.Equal(modbusClientReadValue, rtu.DiscreteSignalValues.FirstOrDefault(c => c.DiscreteSignal.ID == 1).Value);
			nModbusClientMock.Verify(n => n.TryReadSingleCoil(1, out modbusClientReadValue));
		}

		[Fact]
		private void TryReadDiscreteInput_RtuExist_ClientNotAvailable()
		{
			//Arrange
			RTU rtu = modbusSimulatorClient.RtuList.Where(r => r.RTUData.ID == 1).FirstOrDefault();
			var nModbusClientMock = new Mock<IModbusClient>();
			bool modbusClientReadValue = true;
			nModbusClientMock.Setup(n => n.TryReadSingleCoil(1, out modbusClientReadValue)).Returns(false);
			rtu.Connection.Client = nModbusClientMock.Object;

			//Act
			bool returnValue = modbusSimulatorClient.TryReadDiscreteInput(1, 1, out bool readValue);

			//Assert
			Assert.False(returnValue);
			nModbusClientMock.Verify(n => n.TryReadSingleCoil(1, out modbusClientReadValue));
		}

		[Fact]
		private void TryReadDiscreteInput_RtuDoesnNotExist_ClientAvailable()
		{
			//Arrange
			RTU rtu = modbusSimulatorClient.RtuList.Where(r => r.RTUData.ID == 1).FirstOrDefault();
			var nModbusClientMock = new Mock<IModbusClient>();
			bool modbusClientReadValue = true;
			nModbusClientMock.Setup(n => n.TryReadSingleCoil(1, out modbusClientReadValue)).Returns(true);
			rtu.Connection.Client = nModbusClientMock.Object;

			//Act
			bool returnValue = modbusSimulatorClient.TryReadDiscreteInput(5, 1, out bool readValue);

			//Assert
			Assert.False(returnValue);
			nModbusClientMock.Verify(n => n.TryReadSingleCoil(1, out modbusClientReadValue), Times.Never());
		}
		#endregion
	}
}
