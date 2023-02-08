using System.ServiceModel;
using ModbusServiceLibrary.CommandResult;

namespace ModbusServiceLibrary
{
	[ServiceContract]
	public interface IModbusDuplexCallback
	{
		/// <summary>
		/// Updates value of the analog signal
		/// </summary>
		/// <param name="rtuId">ID of the RTU which value we are updating</param>
		/// <param name="signalAddress">Address of the signal we are updating</param>
		/// <param name="signalValue">Updated value</param>
		[OperationContract(IsOneWay = true)]
		void UpdateAnalogSignalValue(int rtuId, int signalAddress, double signalValue);

		/// <summary>
		/// Updates value of the discrete signal
		/// </summary>
		/// <param name="rtuId">ID of the RTU which value we are updating</param>
		/// <param name="signalAddress">Address of the signal we are updating</param>
		/// <param name="signalValue">Updated value</param>
		[OperationContract(IsOneWay = true)]
		void UpdateDiscreteSignalValue(ICommandResult readSingleCoilResult);

		/// <summary>
		/// Changes connection status to false when connection is terminated.
		/// </summary>
		/// <param name="rtuId">ID of the RTU that lost connection</param>
		[OperationContract(IsOneWay = true)]
		void ChangeConnectionStatusToFalse(int rtuId);
	}
}
