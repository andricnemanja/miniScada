using System;
using System.Collections.Generic;
using ModbusServiceLibrary.CommandProcessing;
using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.ModbusClient;
using ModbusServiceLibrary.RtuCommands;
using ModbusServiceLibrary.ServiceReader;
using ModbusServiceLibrary.SignalConverter;

namespace ModbusServiceLibrary
{
	public class CommandReceiver : ICommandReceiver
	{

		private readonly Dictionary<Type, ICommandProcessor> commandProcessors;

		public CommandReceiver(IModbusClient2 modbusClient, ISignalMapper signalMapper, IModelServiceReader modelServiceReader)
		{

			this.commandProcessors = new Dictionary<Type, ICommandProcessor>()
			{
				{typeof(ConnectToRtuCommand), new ConnectoToRtuCommandProcessor(modbusClient) },
				{typeof(ReadSingleCoilCommand), new ReadSingleCoilCommandProcessor(modbusClient, signalMapper) },
				{typeof(ReadSingleHoldingRegisterCommand), new ReadSingleHoldingRegisterCommandProcessor() },
				{typeof(WriteSingleCoilCommand), new WriteSingleCoilCommandProcessor(modbusClient, modelServiceReader) }
			};
		}

		public ICommandResult ReceiveCommand(IRtuCommand command)
		{
			return commandProcessors[command.GetType()].ProcessCommand(command);
		}
	}
}
