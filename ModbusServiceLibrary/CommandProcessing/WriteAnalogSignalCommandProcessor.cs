﻿using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.ModbusClient;
using ModbusServiceLibrary.Model.Signals;
using ModbusServiceLibrary.RtuCommands;
using ModbusServiceLibrary.ServiceReader;
using ModbusServiceLibrary.SignalConverter;

namespace ModbusServiceLibrary.CommandProcessing
{
	public class WriteAnalogSignalCommandProcessor : ICommandProcessor
	{
		private readonly IModbusClient2 modbusClient;
		private readonly IRtuConfiguration rtuConfiguration;
		private readonly ISignalMapper signalMapper;

		public WriteAnalogSignalCommandProcessor(IModbusClient2 modbusClient, IRtuConfiguration rtuConfiguration, ISignalMapper signalMapper)
		{
			this.modbusClient = modbusClient;
			this.rtuConfiguration = rtuConfiguration;
			this.signalMapper = signalMapper;
		}

		public CommandResultBase ProcessCommand(IRtuCommand command)
		{
			WriteAnalogSignalCommand writeAnalogSignalCommand = (WriteAnalogSignalCommand)command;

			AnalogSignal signal = (AnalogSignal)rtuConfiguration.GetSignal(writeAnalogSignalCommand.RtuId, writeAnalogSignalCommand.SignalId);

			int convertedValue = signalMapper.ConvertRealValueToAnalogSignalValue(signal.MappingId, writeAnalogSignalCommand.ValueToWrite);

			modbusClient.TryWriteSingleHoldingRegister(writeAnalogSignalCommand.RtuId, signal.Address, convertedValue);
			return new WriteAnalogSignalCommandResult(writeAnalogSignalCommand.RtuId);
		}
	}
}
