using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.ModbusClient;
using ModbusServiceLibrary.Model.SignalValues;
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
			AnalogSignalValue signalValue = (AnalogSignalValue)rtuConfiguration.GetSignalValue(writeAnalogSignalCommand.RtuId, writeAnalogSignalCommand.SignalId);

			int convertedValue = signalMapper.ConvertRealValueToAnalogSignalValue(signalValue.SignalData.MappingId, writeAnalogSignalCommand.ValueToWrite);

			modbusClient.TryWriteSingleHoldingRegister(writeAnalogSignalCommand.RtuId, signalValue.SignalData.Address, convertedValue);
			return new CommandResultBase(writeAnalogSignalCommand.RtuId);
		}
	}
}
