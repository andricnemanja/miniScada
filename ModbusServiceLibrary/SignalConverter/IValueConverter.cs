namespace ModbusServiceLibrary.SignalConverter
{
	public interface IValueConverter
	{
		/// <summary>
		/// Convert sensor values to real values that have physical meaning.
		/// </summary>
		/// <param name="rtuId">ID of the RTU.</param>
		/// <param name="analogSignalAddress">Address of the analog signal.</param>
		/// <param name="value">Value that is being converted.</param>
		/// <returns>Value with it's phyisical connotation.</returns>
		double ConvertAnalogSignalToRealValue(int rtuId, int analogSignalAddress, double value);
		/// <summary>
		/// Convert real values to sensor values.
		/// </summary>
		/// <param name="rtuId">ID of the RTU.</param>
		/// <param name="analogSignalAddress">Address of the analog signal.</param>
		/// <param name="value">Value that is being converted.</param>
		/// <returns>Value represented in it's sensor form.</returns>
		int ConvertRealValueToAnalogSignal(int rtuId, int analogSignalAddress, double value);
		/// <summary>
		/// Convert sensor values to discrete signal state.
		/// </summary>
		/// <param name="rtuId">ID of the RTU.</param>
		/// <param name="discreteSignalAddress">Address of the discrete signal.</param>
		/// <param name="value">Value that is being converted.</param>
		/// <returns>Discrete signal state.</returns>
		string ConvertDiscreteSignalToRealValue(int rtuId, int discreteSignalAddress, byte value);
		/// <summary>
		/// Convert discrete signal state to sensor values.
		/// </summary>
		/// <param name="rtuId">ID of the RTU.</param>
		/// <param name="discreteSignalAddress">Address of the discrete signal.</param>
		/// <param name="value">Value that is being converted.</param>
		/// <returns>Value represented in it's sensor form.</returns>
		byte ConvertRealValueToDiscreteSignal(int rtuId, int discreteSignalAddress, string value);
		/// <summary>
		/// Reads analog and discrete signal mappings from Model Service. Needs to be called before using class methods./>.
		/// </summary>
		void Initialize();
	}
}