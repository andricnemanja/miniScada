using System.Linq;
using ModbusServiceLibrary.ModbusCommands;
using ModbusServiceLibrary.ModbusCommunication;
using ModbusServiceLibrary.Model.RTU;
using Moq;
using Xunit;

namespace ModbusServiceLibrary.Tests.CommandTests
{
	public class ChangeDiscreteSignalValueCommandTests
	{
		[Theory]
		[InlineData(true, 0)]
		[InlineData(false, 2)]
		[InlineData(true, 5)]
		public void WriteValues_SignalExist(bool newValue, int signalAddress)
		{
			RTU rtu = RtuTestData.GetRtuTestList()[0];
			bool expectedOldValue = rtu.DiscreteSignalValues.Where(s => s.DiscreteSignal.Address == signalAddress).FirstOrDefault().Value;
			var modbusConnectionMock = new Mock<IModbusConnection>();
			modbusConnectionMock.Setup(x => x.WriteDiscreteSignalValue(1, 1, newValue)).Returns(newValue);
			modbusConnectionMock.Setup(x => x.FindRtu(1)).Returns(rtu);
			ChangeDiscreteSignalValueCommand changeAnalogSignalValueCommand =
				new ChangeDiscreteSignalValueCommand(modbusConnectionMock.Object, newValue, 1, signalAddress);

			changeAnalogSignalValueCommand.Execute();

			Assert.Equal(newValue, changeAnalogSignalValueCommand.NewValue);
			Assert.Equal(expectedOldValue, changeAnalogSignalValueCommand.PreviousValue);
		}


	}
}
