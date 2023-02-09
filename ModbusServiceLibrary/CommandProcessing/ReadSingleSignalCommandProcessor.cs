using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.ModbusClient;
using ModbusServiceLibrary.Model.Signals;
using ModbusServiceLibrary.Model.SignalValues;
using ModbusServiceLibrary.RtuCommands;
using ModbusServiceLibrary.ServiceReader;
using ModbusServiceLibrary.SignalConverter;
using System.Windows.Input;

namespace ModbusServiceLibrary.CommandProcessing
{
	public class ReadSingleSignalCommandProcessor : ICommandProcessor
	{
		private readonly IModbusClient2 modbusClient;
		private readonly ISignalMapper signalMapper;
		private readonly IRtuConfiguration rtuConfiguration;

		public ReadSingleSignalCommandProcessor(IModbusClient2 modbusClient, ISignalMapper signalMapper, IRtuConfiguration rtuConfiguration)
		{
			this.modbusClient = modbusClient;
			this.signalMapper = signalMapper;
			this.rtuConfiguration = rtuConfiguration;
		}

		public CommandResultBase ProcessCommand(IRtuCommand command)
		{
			ReadSingleSignalCommand readSingleCoilCommand = (ReadSingleSignalCommand)command;
			ISignalValue signalValue = rtuConfiguration.GetSignalValue(readSingleCoilCommand.RtuId, readSingleCoilCommand.SignalId);

			if(signalValue.GetType() == typeof(DiscreteSignalValue))
			{
				return ReadSignalValue((DiscreteSignalValue)signalValue, readSingleCoilCommand.RtuId);
			}
			else if (signalValue.GetType() == typeof(AnalogSignalValue))
			{
				return ReadSignalValue((AnalogSignalValue)signalValue, readSingleCoilCommand.RtuId);
			}
			return null;
		}

		private CommandResultBase ReadSignalValue(DiscreteSignalValue discreteSignalValue, int rtuId)
		{
			modbusClient.TryReadCoils(rtuId, discreteSignalValue.SignalData.Address, (int)(((DiscreteSignal)discreteSignalValue.SignalData).SignalType + 1), out bool[] values);
			return new ReadSingleDiscreteSignalResult(rtuId, CommandStatus.Executed, discreteSignalValue.SignalData.ID, ConvertDiscreteSignalValueToState(discreteSignalValue.SignalData.MappingId, values));
		}

		private CommandResultBase ReadSignalValue(AnalogSignalValue analogSignalValue, int rtuId)
		{
			modbusClient.TryReadHoldingRegisters(rtuId, analogSignalValue.SignalData.Address, 1, out ushort[] values);
			return new ReadSingleAnalogSignalResult(rtuId, CommandStatus.Executed, analogSignalValue.SignalData.ID, ConvertAnalogSignalToRealValue(analogSignalValue.SignalData.MappingId, values[0]));
		}

		private string ConvertDiscreteSignalValueToState(int mappingId, bool[] values)
		{
			return signalMapper.ConvertDiscreteSignalValueToState(mappingId, BoolArrayToByte(values));
		}

		private double ConvertAnalogSignalToRealValue(int mappingId, double value)
		{
			return signalMapper.ConvertAnalogSignalToRealValue(mappingId, value);
		}

		private byte BoolArrayToByte(bool[] readValues)
		{
			if (readValues.Length == 1)
				return (byte)(readValues[0] ? 1 : 0);

			return (byte)((readValues[0] ? 2 : 0) + (readValues[1] ? 1 : 0));
		}
	}
}
