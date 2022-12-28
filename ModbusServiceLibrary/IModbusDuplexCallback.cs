using System.ServiceModel;

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
		void UpdateAnalogSignalValue(int rtuId, int signalAddress, int signalValue, string unit);

		/// <summary>
		/// Updates value of the discrete signal
		/// </summary>
		/// <param name="rtuId">ID of the RTU which value we are updating</param>
		/// <param name="signalAddress">Address of the signal we are updating</param>
		/// <param name="signalValue">Updated value</param>
		[OperationContract(IsOneWay = true)]
		void UpdateDiscreteSignalValue(int rtuId, int signalAddress, bool signalValue);

		/// <summary>
		/// Changes conncetion status to false.
		/// </summary>
		/// <param name="rtuId">ID of the RTU.</param>
		[OperationContract(IsOneWay = true)]
		void ChangeConnectionStatusToFalse(int rtuId);
	}
}
