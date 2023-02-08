using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.ModbusClient;
using ModbusServiceLibrary.RtuCommands;
using ModbusServiceLibrary.SignalConverter;
using System.Windows.Input;

namespace ModbusServiceLibrary.CommandProcessing
{
	public class ReadSingleCoilCommandProcessor : ICommandProcessor
	{
		private readonly IModbusClient2 modbusClient;
		private readonly ISignalMapper signalMapper;

		public ReadSingleCoilCommandProcessor(IModbusClient2 modbusClient, ISignalMapper signalMapper)
		{
			this.modbusClient = modbusClient;
			this.signalMapper = signalMapper;
		}

		public ICommandResult ProcessCommand(object command)
		{
			ReadSingleCoilCommand readSingleCoilCommand = (ReadSingleCoilCommand)command;
			modbusClient.TryReadCoils(readSingleCoilCommand.RtuId, readSingleCoilCommand.CoilAddress, readSingleCoilCommand.NumberOfCoils, out bool[] values);

			return new ReadSingleCoilResult(readSingleCoilCommand.RtuId, CommandStatus.Executed, readSingleCoilCommand.CoilAddress, ConvertCoilValueToState(readSingleCoilCommand.MappingId, values));
		}

		private string ConvertCoilValueToState(int mappingId, bool[] values)
		{
			return signalMapper.ConvertDiscreteSignalValueToState(mappingId, BoolArrayToByte(values));
		}

		private byte BoolArrayToByte(bool[] readValues)
		{
			if (readValues.Length == 1)
				return (byte)(readValues[0] ? 1 : 0);

			return (byte)((readValues[0] ? 2 : 0) + (readValues[1] ? 1 : 0));
		}
	}
}
