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
		/// <summary>
		/// Repository that contains all data required for converting.
		/// </summary>
		private readonly IModelServiceReader modelServiceReader;
		private readonly IModbusSimulatorClient modbusSimulatorClient;
		private List<AnalogSignalMapping> analogSignalMappingList;
		private List<DiscreteSignalMapping> discreteSignalMappingList;

		/// <summary>
		/// Initializes a instance of class <see cref="ValueConverter"/>.
		/// </summary>
		/// <param name="signalRepo">Signal Mapping repository.</param>
		public ValueConverter(IModelServiceReader modelServiceReader, IModbusSimulatorClient modbusSimulatorClient)
		{
			this.modelServiceReader = modelServiceReader;
			this.modbusSimulatorClient = modbusSimulatorClient;
		}

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
		/// Convert sensor values to real values that have physical meaning.
		/// </summary>
		/// <param name="rtuId">ID of the RTU.</param>
		/// <param name="discreteSignalAddress">Address of the discrete signal.</param>
		/// <param name="value">Value that is being converted.</param>
		/// <returns>Value with it's phyisical connotation.</returns>
		public string ConvertDiscreteSignalToRealValue(int rtuId, int discreteSignalAddress, byte value)
		{
			DiscreteSignalMapping discreteSignalMapping = FindDiscreteSignalMapping(rtuId, discreteSignalAddress);
			return discreteSignalMapping.DiscreteValueToState[value];

		}

		/// <summary>
		/// Convert real values to sensor values.
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

		private DiscreteSignalMapping FindDiscreteSignalMapping(int rtuId, int discreteSignalAddress)
		{
			RTU rtu = modbusSimulatorClient.RtuList.FirstOrDefault(r => r.RTUData.ID == rtuId);
			DiscreteSignalValue discreteSignalValue = rtu.DiscreteSignalValues.FirstOrDefault(s => s.DiscreteSignal.Address == discreteSignalAddress);
			return discreteSignalMappingList.FirstOrDefault(m => m.Id == discreteSignalValue.DiscreteSignal.MappingId);
		}

		private AnalogSignalMapping FindAnalogSignalMapping(int rtuId, int analogSignalAddress)
		{
			RTU rtu = modbusSimulatorClient.RtuList.FirstOrDefault(r => r.RTUData.ID == rtuId);
			AnalogSignalValue analogSignalValue = rtu.AnalogSignalValues.FirstOrDefault(s => s.AnalogSignal.Address == analogSignalAddress);
			return analogSignalMappingList.FirstOrDefault(m => m.Id == analogSignalValue.AnalogSignal.MappingId);
		}
	}
}
