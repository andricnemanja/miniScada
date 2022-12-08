using System.Linq;
using ModbusServiceLibrary.ModbusCommands;
using ModbusServiceLibrary.ModbusCommunication;
using ModbusServiceLibrary.Model.RTU;
using Moq;
using Xunit;

namespace ModbusServiceLibrary.Tests.CommandTests
{
	public class ReadDiscreteSignalValueCommandTests
	{
		[Theory]
		[InlineData(true, 0)]
		[InlineData(false, 2)]
		[InlineData(true, 5)]
		public void ReadValue_SignalExist(bool readValue, int signalAddress)
		{
			RTU rtu = RtuTestData.GetRtuTestList()[0];
			bool expectedOldValue = rtu.DiscreteSignalValues.Where(s => s.DiscreteSignal.Address == signalAddress).FirstOrDefault().Value;
			var modbusConnectionMock = new Mock<IModbusConnection>();
			modbusConnectionMock.Setup(x => x.ReadCoil(1, signalAddress)).Returns(readValue);
			modbusConnectionMock.Setup(x => x.FindRtu(1)).Returns(rtu);
			ReadDiscreteSignalValueCommand readDiscreteSignalValueCommandTests =
				new ReadDiscreteSignalValueCommand(modbusConnectionMock.Object, 1, signalAddress);

			readDiscreteSignalValueCommandTests.Execute();

			Assert.Equal(readValue, readDiscreteSignalValueCommandTests.NewValue);
			Assert.Equal(expectedOldValue, readDiscreteSignalValueCommandTests.PreviousValue);
		}


	}
}
