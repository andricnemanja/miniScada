using System;
using System.Collections.Generic;
using System.Linq;
using ModbusServiceLibrary.ModbusCommunication;
using ModbusServiceLibrary.Model.RTU;
using ModbusServiceLibrary.Model.SignalMapping;
using ModbusServiceLibrary.Model.SignalValues;
using ModbusServiceLibrary.ServiceReader;

namespace ModbusServiceLibrary.SignalConverter
{
	/// <summary>
	/// Class that contains methods that convert values from Real to Sensor values and the other way around.
	/// </summary>
	public class ValueConverter : IValueConverter
	{
		private readonly IRtuConfiguration modelServiceReader;
		private readonly IModbusSimulatorClient modbusSimulatorClient;
		private List<AnalogSignalMapping> analogSignalMappingList;
		private List<DiscreteSignalMapping> discreteSignalMappingList;

		/// <summary>
		/// Initializes a instance of class <see cref="ValueConverter"/>.
		/// </summary>
		/// <param name="modelServiceReader">Instance of the <see cref="IRtuConfiguration"/> class</param>
		/// <param name="modbusSimulatorClient">Instance of the <see cref="IModbusSimulatorClient"/> class</param>
		public ValueConverter(IRtuConfiguration modelServiceReader, IModbusSimulatorClient modbusSimulatorClient)
		{
			this.modelServiceReader = modelServiceReader;
			this.modbusSimulatorClient = modbusSimulatorClient;
		}

		/// <summary>
		/// Reads analog and discrete signal mappings from Model Service. Needs to be called before using class methods./>.
		/// </summary>
		public void Initialize()
		{
			analogSignalMappingList = modelServiceReader.ReadAnalogSignalMappings();
			discreteSignalMappingList = modelServiceReader.ReadDiscreteSignalMappings();
		}

		/// <summary>
		/// Convert sensor values to real values that have physical meaning.
		/// </summary>
		/// <param name="rtuId">ID of the RTU.</param>
		/// <param name="analogSignalAddress">Address of the analog signal.</param>
		/// <param name="value">Value that is being converted.</param>
		/// <returns>Value with it's phyisical connotation.</returns>
		public double ConvertAnalogSignalToRealValue(int rtuId, int analogSignalAddress, double value)
		{
			AnalogSignalMapping analogSignalMapping = FindAnalogSignalMapping(rtuId, analogSignalAddress);

			return value * analogSignalMapping.K + analogSignalMapping.N;
		}

		/// <summary>
		/// Convert real values to sensor values.
		/// </summary>
		/// <param name="rtuId">ID of the RTU.</param>
		/// <param name="analogSignalAddress">Address of the analog signal.</param>
		/// <param name="value">Value that is being converted.</param>
		/// <returns>Value represented in it's sensor form.</returns>
		public int ConvertRealValueToAnalogSignal(int rtuId, int analogSignalAddress, double value)
		{
			AnalogSignalMapping analogSignalMapping = FindAnalogSignalMapping(rtuId, analogSignalAddress);
			return (int)Math.Round((value - analogSignalMapping.N) / analogSignalMapping.K);
		}

		/// <summary>
		/// Convert sensor values to discrete signal state.
		/// </summary>
		/// <param name="rtuId">ID of the RTU.</param>
		/// <param name="discreteSignalAddress">Address of the discrete signal.</param>
		/// <param name="value">Value that is being converted.</param>
		/// <returns>Discrete signal state.</returns>
		public string ConvertDiscreteSignalToRealValue(int rtuId, int discreteSignalAddress, byte value)
		{
			DiscreteSignalMapping discreteSignalMapping = FindDiscreteSignalMapping(rtuId, discreteSignalAddress);
			return discreteSignalMapping.DiscreteValueToState[value];

		}

		/// <summary>
		/// Convert discrete signal state to sensor values.
		/// </summary>
		/// <param name="rtuId">ID of the RTU.</param>
		/// <param name="discreteSignalAddress">Address of the discrete signal.</param>
		/// <param name="value">Value that is being converted.</param>
		/// <returns>Value represented in it's sensor form.</returns>
		public byte ConvertRealValueToDiscreteSignal(int rtuId, int discreteSignalAddress, string value)
		{
			DiscreteSignalMapping discreteSignalMapping = FindDiscreteSignalMapping(rtuId, discreteSignalAddress);
			return discreteSignalMapping.DiscreteValueToState.SingleOrDefault(x => x.Value == value).Key;
		}

		/// <summary>
		/// Finds mapping for discrete signal.
		/// </summary>
		/// <param name="rtuId">ID of the RTU.</param>
		/// <param name="discreteSignalAddress">Address of the discrete signal.</param>
		/// <returns>Discrete signal mapping for signal with given address.</returns>
		private DiscreteSignalMapping FindDiscreteSignalMapping(int rtuId, int discreteSignalAddress)
		{
			RTU rtu = modelServiceReader.RtuList.FirstOrDefault(r => r.RTUData.ID == rtuId);
			ISignalValue discreteSignalValue = rtu.DiscreteSignalValues.FirstOrDefault(s => s.SignalData.Address == discreteSignalAddress);
			return discreteSignalMappingList.FirstOrDefault(m => m.Id == discreteSignalValue.SignalData.MappingId);
		}

		/// <summary>
		/// Finds mapping for analog signal.
		/// </summary>
		/// <param name="rtuId">ID of the RTU.</param>
		/// <param name="analogSignalAddress">Address of the analog signal.</param>
		/// <returns>Discrete signal mapping for signal with given address.</returns>
		private AnalogSignalMapping FindAnalogSignalMapping(int rtuId, int analogSignalAddress)
		{
			RTU rtu = modelServiceReader.RtuList.FirstOrDefault(r => r.RTUData.ID == rtuId);
			AnalogSignalValue analogSignalValue = rtu.AnalogSignalValues.FirstOrDefault(s => s.AnalogSignal.Address == analogSignalAddress);
			return analogSignalMappingList.FirstOrDefault(m => m.Id == analogSignalValue.AnalogSignal.MappingId);
		}
	}
}
