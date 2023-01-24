﻿using ModbusServiceLibrary.Model.Signals;

namespace ModbusServiceLibrary.Model.SignalValues
{
	/// <summary>
	/// Class <see cref="DiscreteSignalValue"/> models value of the discrete signal.
	/// </summary>
	public class DiscreteSignalValue
	{
		/// <summary>
		/// Discrete signal static data.
		/// </summary>
		public DiscreteSignal DiscreteSignal { get; set; }
	
		/// <summary>
		/// Value of the discrete signal.
		/// </summary>
		public byte Value { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="DiscreteSignalValue"/> class.
		/// </summary>
		/// <param name="discreteSignalStaticData">An instance of the <see cref="ModelServiceReference.DiscreteSignal"/>.
		/// Allows converting Model Service static data to Modbus Service model class</param>
		public DiscreteSignalValue(ModelServiceReference.DiscreteSignal discreteSignalStaticData)
		{
			DiscreteSignal = new DiscreteSignal(discreteSignalStaticData);
		}

		public DiscreteSignalValue() {}
	}
}