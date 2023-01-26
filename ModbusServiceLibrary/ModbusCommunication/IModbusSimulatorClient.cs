using ModbusServiceLibrary.Model.RTU;

namespace ModbusServiceLibrary.ModbusCommunication
{
	public interface IModbusSimulatorClient
	{
		/// <summary>
		/// Try to make a connection with specific RTU.
		/// </summary>
		/// <param name="rtudId">Id of RTU to connect to.</param>
		/// <returns>True if connection is made, false if there is error that prevents connecting</returns>
		bool TryConnectToRtu(int rtudId);

		bool TryFindRtu(int rtuId, out RTU rtu);
		/// <summary>
		/// Try to read single register from the RTU
		/// </summary>
		/// <param name="rtuId">Id of RTU to read from</param>
		/// <param name="signalAddress">Address of the register</param>
		/// <param name="value">Function output - value of the read signal</param>
		/// <returns>True if signal is read, false if an error occurred during reading</retu
		bool TryReadAnalogInput(int rtuId, int signalAddress, out int value);
		/// <summary>
		/// Try to read single discrete input from 
		/// </summary>
		/// <param name="rtuId">Id of RTU to read from</param>
		/// <param name="signalAddress">Address of the discrete input</param>
		/// <param name="discreteValue">Function output - value of the read signal</param>
		/// <returns>True if signal is read, false if an error occurred during reading</returns>
		bool TryReadDiscreteInput(int rtuId, int signalAddress, out byte discreteValue);
		/// <summary>
		/// Try to write value of the single analog signal.
		/// </summary>
		/// <param name="rtuId">Id of RTU to write to.</param>
		/// <param name="signalAddress">Address of the register.</param>
		/// <param name="value">New value.</param>
		/// <returns>True if the signal is written, false if an error occurred during writing.</returns>
		bool TryWriteAnalogSignalValue(int rtuId, int signalAddress, int value);
		/// <summary>
		/// Try to write value of the single discrete signal.
		/// </summary>
		/// <param name="rtuId">Id of RTU to write to.</param>
		/// <param name="signalAddress">Address of the register.</param>
		/// <param name="discreteValue">New value.</param>
		/// <returns>True if the signal is written, false if an error occurred during writing.</returns>
		bool TryWriteDiscreteSignalValue(int rtuId, int signalAddress, byte value);
	}
}