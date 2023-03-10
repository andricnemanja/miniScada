using System;
using System.Collections.Generic;
using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.Modbus;
using ModbusServiceLibrary.Model.Signals;
using ModbusServiceLibrary.RtuCommands;
using ModbusServiceLibrary.RtuConfiguration;

namespace ModbusServiceLibrary.CommandProcessing
{
	public class ReadSingleSignalCommandProcessor : ICommandProcessor
	{
		private readonly IRtuConfiguration rtuConfiguration;
		private readonly IProtocolDriver protocolDriver;
		private readonly Dictionary<Type, Func<ISignal, int, CommandResultBase>> SignalReaders;

		public ReadSingleSignalCommandProcessor(IProtocolDriver protocolDriver, IRtuConfiguration rtuConfiguration)
		{
			this.protocolDriver = protocolDriver;
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
			if (protocolDriver.TryReadDiscreteSignal(signal.ID, out string signalState))
			{
				return new ReadSingleDiscreteSignalResult(rtuId, signal.ID, signalState);
			}
			return new ReadSingleDiscreteSignalFailedResult(rtuId, signal.ID);
		}

		private CommandResultBase ReadAnalogSignalValue(ISignal signal, int rtuId)
		{
			if(protocolDriver.TryReadAnalogSignal(signal.ID, out double signalValue))
			{
				return new ReadSingleAnalogSignalResult(rtuId, signal.ID, signalValue);
			}
			return new ReadSingleAnalogSignalFailedResult(rtuId, signal.ID);
		}
	}
}
