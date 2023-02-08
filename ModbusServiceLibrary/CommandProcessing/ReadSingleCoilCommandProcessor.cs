using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.ModbusClient;
using ModbusServiceLibrary.Model.Signals;
using ModbusServiceLibrary.Model.SignalValues;
using ModbusServiceLibrary.RtuCommands;
using ModbusServiceLibrary.ServiceReader;
using ModbusServiceLibrary.SignalConverter;

namespace ModbusServiceLibrary.CommandProcessing
{
	public class ReadSingleCoilCommandProcessor : ICommandProcessor
	{
		private readonly IModbusClient2 modbusClient;
		private readonly ISignalMapper signalMapper;
		private readonly IRtuConfiguration rtuConfiguration;

		public ReadSingleCoilCommandProcessor(IModbusClient2 modbusClient, ISignalMapper signalMapper, IRtuConfiguration rtuConfiguration)
		{
			this.modbusClient = modbusClient;
			this.signalMapper = signalMapper;
			this.rtuConfiguration = rtuConfiguration;
		}

		public ICommandResult ProcessCommand(IRtuCommand command)
		{
			ReadSingleCoilCommand readSingleCoilCommand = (ReadSingleCoilCommand)command;
			int mappingId = rtuConfiguration.GetMappingIdForDiscreteSignal(readSingleCoilCommand.RtuId, readSingleCoilCommand.SignalId);
			ISignalValue signalValue = rtuConfiguration.GetSignalValue(readSingleCoilCommand.RtuId, readSingleCoilCommand.SignalId);

			if(signalValue.GetType() == typeof(DiscreteSignalValue))
			{
				return ReadSignalValue((DiscreteSignalValue)signalValue, readSingleCoilCommand.RtuId);
			}
			return null;
		}

		private ICommandResult ReadSignalValue(DiscreteSignalValue discreteSignalValue, int rtuId)
		{
			modbusClient.TryReadCoils(rtuId, discreteSignalValue.SignalData.Address, (int)(((DiscreteSignal)discreteSignalValue.SignalData).SignalType + 1), out bool[] values);
			return new ReadSingleCoilResult(rtuId, CommandStatus.Executed, discreteSignalValue.SignalData.Address, ConvertCoilValueToState(discreteSignalValue.SignalData.MappingId, values));
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
