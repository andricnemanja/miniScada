using System;
using System.ServiceModel;
using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.RtuCommands;

namespace ModbusServiceLibrary
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
	public sealed class ModbusService : IModbusDuplex
	{
		private readonly IRtuCommandInvoker rtuCommandInvoker;
		/// <summary>
		/// Initializes a new instance of the <see cref="ModbusService"/>
		/// </summary>
		/// <param name="rtuCommandInvoker">Instance of the <see cref="IRtuCommandInvoker"/> class</param>

		public ModbusService(IRtuCommandInvoker rtuCommandInvoker)
		{
			this.rtuCommandInvoker = rtuCommandInvoker;
		}

		/// <summary>
		/// Read value of the analog signal from the RTU and update it through callback channel.
		/// </summary>
		/// <param name="rtuId">RTU identification number.</param>
		/// <param name="signalAddress">Address of the signal.</param>
		public void ReadAnalogSignal(int rtuId, int signalAddress)
		{
			IModbusDuplexCallback callback = OperationContext.Current.GetCallbackChannel<IModbusDuplexCallback>();
			callback.ReceiveCommandResult(rtuCommandInvoker.ReadSingleSignalCommand(rtuId, signalAddress));
		}

		/// <summary>
		/// Read value of the discrete signal from the RTU and update it through callback channel.
		/// </summary>
		/// <param name="rtuId">RTU identification number.</param>
		/// <param name="signalAddress">Address of the signal.</param>
		public void ReadDiscreteSignal(int rtuId, int signalAddress)
		{
			IModbusDuplexCallback callback = OperationContext.Current.GetCallbackChannel<IModbusDuplexCallback>();
			callback.ReceiveCommandResult(rtuCommandInvoker.ReadSingleSignalCommand(rtuId, signalAddress));
		}

		/// <summary>
		/// Write new analog signal value.
		/// </summary>
		/// <param name="rtuId">RTU identification number.</param>
		/// <param name="signalAddress">Address of the signal.</param>
		/// <param name="newValue">New value of the analog signal.</param>
		public void WriteAnalogSignal(int rtuId, int signalAddress, double newValue)
		{
			IModbusDuplexCallback callback = OperationContext.Current.GetCallbackChannel<IModbusDuplexCallback>();
			callback.ReceiveCommandResult(rtuCommandInvoker.WriteAnalogSignalCommand(rtuId, signalAddress, newValue));
		}

		/// <summary>
		/// Write new discrete signal value.
		/// </summary>
		/// <param name="rtuId">RTU identification number.</param>
		/// <param name="signalAddress">Address of the signal.</param>
		/// <param name="newValue">New value of the discrete signal.</param>
		public void WriteDiscreteSignal(int rtuId, int signalAddress, string newValue)
		{
			IModbusDuplexCallback callback = OperationContext.Current.GetCallbackChannel<IModbusDuplexCallback>();
			callback.ReceiveCommandResult(rtuCommandInvoker.WriteDiscreteSignalCommand(rtuId, signalAddress, newValue));
		}

		/// <summary>
		/// Make a connection with the RTU.
		/// </summary>
		/// <param name="rtuId">RTU identification number.</param>
		/// <returns>True if the connection is made, false otherwise.</returns>
		public CommandResultBase ConnectToRtu(int rtuId)
		{
			return rtuCommandInvoker.ConnectToRtu(rtuId);
		}

		/// <summary>
		/// Method that recieves command sent from the Scheduler library.
		/// </summary>
		/// <param name="command">Commmand sent from Scheduler service.</param>
		public void ReceiveCommand(RtuCommandBase command)
		{
			try
			{
				Console.WriteLine(((ReadSingleSignalCommand)command).RtuId);
				Console.WriteLine(((ReadSingleSignalCommand)command).SignalId);
				rtuCommandInvoker.ReadSingleSignalScheduler(command);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

		}

	}
}
