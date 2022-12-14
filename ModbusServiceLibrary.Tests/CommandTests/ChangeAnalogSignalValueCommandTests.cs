using System.Linq;
using ModbusServiceLibrary.ModbusCommands;
using ModbusServiceLibrary.ModbusCommunication;
using ModbusServiceLibrary.Model.RTU;
using Moq;
using Xunit;

namespace ModbusServiceLibrary.Tests.CommandTests
{
	public class ChangeAnalogSignalValueCommandTests
	{
		[Theory]
		[InlineData(0, 1)]
		[InlineData(10, 5)]
		[InlineData(150, 7)]
		public void WriteValues_SignalExist(int newValue, int signalAddress)
		{
			RTU rtu = RtuTestData.GetRtuTestList()[0];
			int expectedOldValue = rtu.AnalogSignalValues.Where(s => s.AnalogSignal.Address == signalAddress).FirstOrDefault().Value;
			var modbusConnectionMock = new Mock<IModbusConnection>();
			modbusConnectionMock.Setup(x => x.WriteAnalogSignalValue(1, 1, newValue)).Returns(newValue);
			modbusConnectionMock.Setup(x => x.FindRtu(1)).Returns(rtu);
			ChangeAnalogSignalValueCommand changeAnalogSignalValueCommand =
				new ChangeAnalogSignalValueCommand(modbusConnectionMock.Object, newValue, 1, signalAddress);

			changeAnalogSignalValueCommand.Execute();

		}


	}
}
