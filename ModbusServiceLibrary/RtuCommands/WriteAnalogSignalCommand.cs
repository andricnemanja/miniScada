﻿using System.Runtime.Serialization;

namespace ModbusServiceLibrary.RtuCommands
{
	/// <summary>
	/// Command that is sent whenever the new state of the analog signal is written.
	/// </summary>
	[DataContract]
	public sealed class WriteAnalogSignalCommand : RtuCommandBase
	{
		[DataMember]
		public int RtuId { get; set; }

		[DataMember]
		public int SignalId { get; set; }

		[DataMember]
		public double ValueToWrite { get; set; }

		public WriteAnalogSignalCommand(int rtuId, int signalId, double valueToWrite)
		{
			RtuId = rtuId;
			SignalId = signalId;
			ValueToWrite = valueToWrite;
		}
	}
}
