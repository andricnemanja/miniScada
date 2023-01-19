using ModbusServiceLibrary.ModbusCommunication;
using ModbusServiceLibrary.ServiceReader;
using ModbusServiceLibrary.SignalConverter;
using Moq;
using Xunit;

namespace ModbusServiceLibrary.Tests.SignalConverterTests
{
	public class ValueConverterTests
	{
		private readonly Mock<IModelServiceReader> modelServiceReaderMock;
		private readonly ModbusSimulatorClient modbusSimulatorClient;
		private readonly IValueConverter valueConverter;

		public ValueConverterTests()
		{
			modelServiceReaderMock = new Mock<IModelServiceReader>();
			modelServiceReaderMock.Setup(x => x.ReadAllRTUs()).Returns(RtuTestData.GetRtuTestList());
			modelServiceReaderMock.Setup(x => x.ReadAnalogSignalMappings()).Returns(MappinTestData.GetAnalogSignalMappingsTestList());
			modelServiceReaderMock.Setup(x => x.ReadDiscreteSignalMappings()).Returns(MappinTestData.GetDiscreteSignalMappingsTestList());
			modbusSimulatorClient = new ModbusSimulatorClient(modelServiceReaderMock.Object);
			modbusSimulatorClient.InitializeData();
			valueConverter = new ValueConverter(modelServiceReaderMock.Object, modbusSimulatorClient);
			valueConverter.Initialize();
		}

		[Theory]
		[InlineData(10000, 40)]
		[InlineData(1000, -32)]
		[InlineData(100, -39.2)]
		private void ConvertAnalogSignalToRealValue(double analogSignalValue, double expectedRealValue)
		{
			//Arrange
			int rtuId = 1;
			int analogSignalAddress = 1;

			//Act
			double returnValue = valueConverter.ConvertAnalogSignalToRealValue(rtuId, analogSignalAddress, analogSignalValue);

			//Assert
			Assert.Equal(expectedRealValue, returnValue);
		}


		[Theory]
		[InlineData(40, 10000)]
		[InlineData(-32, 1000)]
		[InlineData(-39.2, 100)]
		private void ConvertRealValueToAnalogSignal(double realValue, double expectedAnalogSignalValue)
		{
			//Arrange
			int rtuId = 1;
			int analogSignalAddress = 1;

			//Act
			double returnValue = valueConverter.ConvertRealValueToAnalogSignal(rtuId, analogSignalAddress, realValue);

			//Assert
			Assert.Equal(expectedAnalogSignalValue, returnValue);
		}

		[Theory]
		[InlineData(0, "Error")]
		[InlineData(1, "On")]
		[InlineData(2, "Off")]
		[InlineData(3, "Transit")]
		private void ConvertDiscreteSignalToRealValue(byte realValue, string expectedSignalState)
		{
			//Arrange
			int rtuId = 1;
			int discreteSignalAddress = 1;

			//Act
			string returnValue = valueConverter.ConvertDiscreteSignalToRealValue(rtuId, discreteSignalAddress, realValue);

			//Assert
			Assert.Equal(expectedSignalState, returnValue);
		}

		[Theory]
		[InlineData("Error", 0)]
		[InlineData("On", 1)]
		[InlineData("Off", 2)]
		[InlineData("Transit", 3)]
		private void ConvertRealValueToDiscreteSignal(string signalState, byte expectedValue)
		{
			//Arrange
			int rtuId = 1;
			int discreteSignalAddress = 1;

			//Act
			byte returnValue = valueConverter.ConvertRealValueToDiscreteSignal(rtuId, discreteSignalAddress, signalState);

			//Assert
			Assert.Equal(expectedValue, returnValue);
		}


	}
}
