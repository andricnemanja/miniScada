﻿namespace ModbusServiceLibrary.CommandResult
{
	public interface ICommandResult
	{
		int RtuId { get; }
		CommandStatus CommandStatus { get; }
	}
}
