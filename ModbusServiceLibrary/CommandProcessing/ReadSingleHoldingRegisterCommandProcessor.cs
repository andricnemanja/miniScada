using System;
using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.RtuCommands;

namespace ModbusServiceLibrary.CommandProcessing
{
	public class ReadSingleHoldingRegisterCommandProcessor : ICommandProcessor
	{
		public ICommandResult ProcessCommand(IRtuCommand command)
		{
			throw new NotImplementedException();
		}
	}
}
