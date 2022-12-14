using ModbusServiceLibrary.Model.Signals;

namespace ModbusServiceLibrary.Model.SignalValues
{
	public class DiscreteSignalValue
	{

		/// <summary>
		/// Discrete signal
		/// </summary>
		public DiscreteSignal DiscreteSignal { get; set; }
		/// <summary>
		/// Value of the discrete signal
		/// </summary>
		public bool Value { get; set; }

		public DiscreteSignalValue(ModelServiceReference.DiscreteSignal discreteSignalStaticData)
		{
			DiscreteSignal = new DiscreteSignal(discreteSignalStaticData);
			Value = false;
		}
	}
}