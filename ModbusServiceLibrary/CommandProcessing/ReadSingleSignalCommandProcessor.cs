using System;
using System.Collections.Generic;
using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.ModbusClient;
using ModbusServiceLibrary.Model.Signals;
using ModbusServiceLibrary.RtuCommands;
using ModbusServiceLibrary.ServiceReader;
using ModbusServiceLibrary.SignalConverter;

namespace ModbusServiceLibrary.CommandProcessing
{
	public class ReadSingleSignalCommandProcessor : ICommandProcessor
	{
		private readonly IModbusClient2 modbusClient;
		private readonly ISignalMapper signalMapper;
		private readonly IRtuConfiguration rtuConfiguration;
		private Dictionary<Type, Func<ISignal, int, CommandResultBase>> SignalReaders;

		public ReadSingleSignalCommandProcessor(IModbusClient2 modbusClient, ISignalMapper signalMapper, IRtuConfiguration rtuConfiguration)
		{
			this.modbusClient = modbusClient;
			this.signalMapper = signalMapper;
			this.rtuConfiguration = rtuConfiguration;
			this.SignalReaders = new Dictionary<Type, Func<ISignal, int, CommandResultBase>>
			{
				{ typeof(AnalogSignal), ReadAnalogSignalValue },
				{ typeof(DiscreteSignal), ReadDiscreteSignalValue },
			};
		}

		public CommandResultBase ProcessCommand(IRtuCommand command)
		{
			ReadSingleSignalCommand readSingleSignalCommand = (ReadSingleSignalCommand)command;
			ISignal signal = rtuConfiguration.GetSignal(readSingleSignalCommand.RtuId, readSingleSignalCommand.SignalId);

			if(SignalReaders.TryGetValue(signal.GetType(), out Func<ISignal, int, CommandResultBase> readFunction))
			{
				return readFunction(signal, readSingleSignalCommand.RtuId);
			}
			return null;
		}

		private CommandResultBase ReadDiscreteSignalValue(ISignal signal, int rtuId)
		{
			DiscreteSignal discreteSignal = (DiscreteSignal)signal;
			bool[] readValues;

			if (discreteSignal.AccessType == SignalAccessType.Output)
				modbusClient.TryReadCoils(rtuId, discreteSignal.Address, (int)(discreteSignal.SignalType + 1), out readValues);
			else
				modbusClient.TryReadInputs(rtuId, discreteSignal.Address, (int)(discreteSignal.SignalType + 1), out readValues);

			string signalState = ConvertDiscreteSignalValueToState(discreteSignal.MappingId, readValues);

			return new ReadSingleDiscreteSignalResult(rtuId, discreteSignal.ID, signalState);
		}

		private CommandResultBase ReadAnalogSignalValue(ISignal signal, int rtuId)
		{
			AnalogSignal analogSignal = (AnalogSignal)signal;
			ushort[] readValue;

			if (analogSignal.AccessType == SignalAccessType.Output)
				modbusClient.TryReadHoldingRegisters(rtuId, analogSignal.Address, 1, out readValue);
			else
				modbusClient.TryReadInputRegisters(rtuId, analogSignal.Address, 1, out readValue);

			double signalRealValue = ConvertAnalogSignalToRealValue(analogSignal.MappingId, readValue[0]);

			return new ReadSingleAnalogSignalResult(rtuId, analogSignal.ID, signalRealValue);
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
