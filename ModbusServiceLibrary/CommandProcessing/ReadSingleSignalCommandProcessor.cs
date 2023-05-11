﻿using System;
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
		private readonly IModbusRtuConfiguration rtuConfiguration;
		private readonly IProtocolDriver protocolDriver;
		private readonly Dictionary<Type, Func<IModbusSignal, int, CommandResultBase>> SignalReaders;

		public ReadSingleSignalCommandProcessor(IProtocolDriver protocolDriver, IModbusRtuConfiguration rtuConfiguration)
		{
			this.protocolDriver = protocolDriver;
			this.rtuConfiguration = rtuConfiguration;
			this.SignalReaders = new Dictionary<Type, Func<IModbusSignal, int, CommandResultBase>>
			{
				{ typeof(ModbusAnalogSignal), ReadAnalogSignalValue },
				{ typeof(ModbusDiscreteSignal), ReadDiscreteSignalValue },
			};
		}

		public CommandResultBase ProcessCommand(IRtuCommand command)
		{
			ReadSingleSignalCommand readSingleSignalCommand = (ReadSingleSignalCommand)command;
			IModbusSignal signal = rtuConfiguration.GetSignal(readSingleSignalCommand.RtuId, readSingleSignalCommand.SignalId);

			if(SignalReaders.TryGetValue(signal.GetType(), out Func<IModbusSignal, int, CommandResultBase> readFunction))
			{
				return readFunction(signal, readSingleSignalCommand.RtuId);
			}
			return null;
		}

		private CommandResultBase ReadDiscreteSignalValue(IModbusSignal signal, int rtuId)
		{
			if (protocolDriver.TryReadDiscreteSignal(signal.ID, out string signalState))
			{
				return new ReadSingleDiscreteSignalResult(rtuId, signal.ID, signalState);
			}
			return new ReadSingleDiscreteSignalFailedResult(rtuId, signal.ID);
		}

		private CommandResultBase ReadAnalogSignalValue(IModbusSignal signal, int rtuId)
		{
			if(protocolDriver.TryReadAnalogSignal(signal.ID, out double signalValue))
			{
				return new ReadSingleAnalogSignalResult(rtuId, signal.ID, signalValue);
			}
			return new ReadSingleAnalogSignalFailedResult(rtuId, signal.ID);
		}
	}
}
