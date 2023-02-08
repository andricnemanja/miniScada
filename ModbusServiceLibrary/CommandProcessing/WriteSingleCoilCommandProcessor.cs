using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.ModbusClient;
using ModbusServiceLibrary.Model.RTU;
using ModbusServiceLibrary.Model.Signals;
using ModbusServiceLibrary.RtuCommands;
using ModbusServiceLibrary.ServiceReader;
using ModbusServiceLibrary.SignalConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ModbusServiceLibrary.CommandProcessing
{
	public class WriteSingleCoilCommandProcessor: ICommandProcessor
	{
		private readonly IModelServiceReader modelServiceReader;
		private readonly IModbusClient2 modbusClient;
		private readonly ISignalMapper signalMapper;

		public WriteSingleCoilCommandProcessor(IModbusClient2 modbusClient, IModelServiceReader modelServiceReader)
		{
			this.modbusClient = modbusClient;		
			this.modelServiceReader = modelServiceReader;
		}

		public ICommandResult ProcessCommand(object command)
		{
			WriteSingleCoilCommand writeOneBitCoilCommand = (WriteSingleCoilCommand)command;
			DiscreteSignal discreteSignal = FindDiscreteSignal(writeOneBitCoilCommand.RtuId, writeOneBitCoilCommand.SignalId);
			byte stateToByte = ConvertStateToByte(discreteSignal.MappingId, writeOneBitCoilCommand.State);
			bool[] boolArray = ByteToBoolArray(discreteSignal.SignalType, stateToByte);

			modbusClient.TryWriteCoils(writeOneBitCoilCommand.RtuId, discreteSignal.Address, boolArray);

			return new WriteSingleCoilResult(CommandStatus.Executed);
		}
		
		private RTU FindRtu(int rtuId)
		{
			return modelServiceReader.RtuList.SingleOrDefault(r => r.RTUData.ID == rtuId);
		}

		private DiscreteSignal FindDiscreteSignal(int rtuId, int signalId)
		{
			return FindRtu(rtuId).DiscreteSignalValues.FirstOrDefault(s => s.DiscreteSignal.ID == signalId).DiscreteSignal;
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
