using System.Runtime.Serialization;
using System.ServiceModel;
using ModbusServiceLibrary.CommandResult;
using ModbusServiceLibrary.RtuCommands;

namespace ModbusServiceLibrary
{
	/// <summary>
	/// 
	/// </summary>
	[ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IModbusDuplexCallback))]
	public interface IModbusDuplex
	{
		[OperationContract (IsOneWay = true)]
		void Subscribe();
		/// <summary>
		/// Read value of the analog signal from the RTU and update it through callback channel.
		/// </summary>
		/// <param name="rtuId">RTU identification number.</param>
		/// <param name="signalAddress">Address of the signal.</param>
		[OperationContract(IsOneWay = true)]
		void ReadAnalogSignal(int rtuId, int signalAddress);

		/// <summary>
		/// Read value of the discrete signal from the RTU and update it through callback channel.
		/// </summary>
		/// <param name="rtuId">RTU identification number.</param>
		/// <param name="signalAddress">Address of the signal.</param>
		[OperationContract(IsOneWay = true)]
		void ReadDiscreteSignal(int rtuId, int signalAddress);

		/// <summary>
		/// Write new analog signal value.
		/// </summary>
		/// <param name="rtuId">RTU identification number.</param>
		/// <param name="signalAddress">Address of the signal.</param>
		/// <param name="newValue">New value of the analog signal.</param>
		[OperationContract(IsOneWay = true)]
		void WriteAnalogSignal(int rtuId, int signalAddress, double newValue);

		/// <summary>
		/// Write new discrete signal value.
		/// </summary>
		/// <param name="rtuId">RTU identification number.</param>
		/// <param name="signalAddress">Address of the signal.</param>
		/// <param name="newValue">New value of the discrete signal.</param>
		[OperationContract(IsOneWay = true)]
		void WriteDiscreteSignal(int rtuId, int signalAddress, string newValue);

		/// <summary>
		/// Make a connection with the RTU.
		/// </summary>
		/// <param name="rtuId">RTU identification number.</param>
		/// <returns>True if the connection is made, false otherwise.</returns>
		[OperationContract(IsOneWay = false)]
		CommandResultBase ConnectToRtu(int rtuId);


		[OperationContract(IsOneWay = true)]
		void ReceiveCommand(RtuCommandBase commandResult);

	}
}
