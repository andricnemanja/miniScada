using System.Linq;
using ModbusServiceLibrary.ModbusCommands;
using ModbusServiceLibrary.ModbusCommunication;
using ModbusServiceLibrary.Model.RTU;
using Moq;
using Xunit;

namespace ModbusServiceLibrary.Tests.CommandTests
{
	public class ReadAnalogSignalValueCommandTests
	{
		[Theory]
		[InlineData(0, 1)]
		[InlineData(10, 5)]
		[InlineData(150, 7)]
		public void ReadValue_SignalExist(int readValue, int signalAddress)
		{
			RTU rtu = RtuTestData.GetRtuTestList()[0];
			int expectedOldValue = rtu.AnalogSignalValues.Where(s => s.AnalogSignal.Address == signalAddress).FirstOrDefault().Value;
			var modbusConnectionMock = new Mock<IModbusSimulatorClient>();
			modbusConnectionMock.Setup(x => x.ReadRegister(1, signalAddress)).Returns(readValue);
			modbusConnectionMock.Setup(x => x.FindRtu(1)).Returns(rtu);
			ReadAnalogSignalValueCommand readAnalogSignalValueCommand =
				new ReadAnalogSignalValueCommand(modbusConnectionMock.Object, 1, signalAddress);

			readAnalogSignalValueCommand.Execute();
		}


	}
}
