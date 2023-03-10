using ModbusServiceLibrary.ModelServiceReference;
using ModbusServiceLibrary.SignalConverter;
using Moq;
using Xunit;

namespace ModbusServiceLibrary.Tests.ModbusTests.SignalMapper
{
	public class SignalMapperTests
	{
		private readonly ISignalMapper signalMapper;

		public SignalMapperTests()
		{
			Mock<IModelService> modelServiceMock = new Mock<IModelService>();
			modelServiceMock.Setup(x => x.GetAnalogSignalMappings()).Returns(MappinTestData.GetAnalogSignalMappingsTestList());
			modelServiceMock.Setup(x => x.GetDiscreteSignalMappings()).Returns(MappinTestData.GetDiscreteSignalMappingsTestList());

			signalMapper = new SignalConverter.SignalMapper(modelServiceMock.Object);
		}

		[Theory]
		[InlineData(10000, 40)]
		[InlineData(1000, -32)]
		[InlineData(100, -39.2)]
		private void ConvertAnalogSignalToRealValue(double analogSignalValue, double expectedRealValue)
		{
			//Arrange
			int mappingId = 1;

			//Act
			double returnValue = signalMapper.ConvertAnalogSignalToRealValue(mappingId, analogSignalValue);

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
			int mappingId = 1;

			//Act
			double returnValue = signalMapper.ConvertRealValueToAnalogSignalValue(mappingId, realValue);

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
			int mappingId = 2;

			//Act
			string returnValue = signalMapper.ConvertDiscreteSignalValueToState(mappingId, realValue);

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
			int mappingId = 2;

			//Act
			byte returnValue = signalMapper.ConvertStateToDiscreteSignalValue(mappingId, signalState);

			//Assert
			Assert.Equal(expectedValue, returnValue);
		}
	}
}
