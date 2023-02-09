using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.ModbusClient;
using ModbusServiceLibrary.Model.Signals;
using ModbusServiceLibrary.Model.SignalValues;
using ModbusServiceLibrary.RtuCommands;
using ModbusServiceLibrary.ServiceReader;
using ModbusServiceLibrary.SignalConverter;

namespace ModbusServiceLibrary.CommandProcessing
{
	public class WriteDiscreteSignalCommandProcessor: ICommandProcessor
	{
		private readonly IRtuConfiguration rtuConfiguration;
		private readonly IModbusClient2 modbusClient;
		private readonly ISignalMapper signalMapper;

		public WriteDiscreteSignalCommandProcessor(IModbusClient2 modbusClient, IRtuConfiguration rtuConfiguration, ISignalMapper signalMapper)
		{
			this.modbusClient = modbusClient;
			this.rtuConfiguration = rtuConfiguration;
			this.signalMapper = signalMapper;
		}

		public CommandResultBase ProcessCommand(IRtuCommand command)
		{
			RtuCommands.WriteDiscreteSignalCommand writeDiscreteSignalCommand = (RtuCommands.WriteDiscreteSignalCommand)command;
			DiscreteSignalValue discreteSignal = (DiscreteSignalValue)rtuConfiguration.GetSignalValue(writeDiscreteSignalCommand.RtuId, writeDiscreteSignalCommand.SignalId);
			byte stateToByte = ConvertStateToByte(discreteSignal.SignalData.MappingId, writeDiscreteSignalCommand.State);
			bool[] boolArray = ByteToBoolArray(((DiscreteSignal)discreteSignal.SignalData).SignalType, stateToByte);

			modbusClient.TryWriteCoils(writeDiscreteSignalCommand.RtuId, discreteSignal.SignalData.Address, boolArray);

			return new WriteDiscreteSignalCommandResult(writeDiscreteSignalCommand.RtuId);
		}

		private byte ConvertStateToByte(int mappingId, string value)
		{
			return signalMapper.ConvertStateToDiscreteSignalValue(mappingId, value);
		}


		/// <summary>
		/// Converts numerical representation of discrete signal to array of bools that is needed for changing signal value.
		/// </summary>
		/// <param name="discreteSignalType">Type of discrete signal, 1 or 2 bit.</param>
		/// <param name="value">Numerical representation of discrete signal value.</param>
		/// <returns>Array of bools needed for changing discrete signal value.</returns>
		private bool[] ByteToBoolArray(DiscreteSignalType discreteSignalType, byte value)
		{
			if (discreteSignalType == DiscreteSignalType.OneBit)
			{
				return new bool[1] { value == 1 };
			}

			return new bool[2] { (value & 2) == 2, (value & 1) == 1 };
		}
	}
}
