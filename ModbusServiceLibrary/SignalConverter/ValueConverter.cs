using ModbusServiceLibrary.Model.SignalMapping;
using ModbusServiceLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ModbusServiceLibrary.SignalConverter
{
	/// <summary>
	/// Class that contains methods that convert values from Real to Sensor values and the other way around.
	/// </summary>
	public class ValueConverter: IValueConverter
	{
		/// <summary>
		/// Repository that contains all data required for converting.
		/// </summary>
		private readonly ISignalMappingRepository SignalMappingRepository;

		/// <summary>
		/// Initializes a instance of class <see cref="ValueConverter"/>.
		/// </summary>
		/// <param name="signalRepo">Signal Mapping repository.</param>
		public ValueConverter(ISignalMappingRepository signalRepo)
		{
			SignalMappingRepository = signalRepo;
		}

		/// <summary>
		/// Convert sensor values to real values that have physical meaning.
		/// </summary>
		/// <param name="rtuId">ID of the RTU.</param>
		/// <param name="analogSignalId">ID of the analog signal.</param>
		/// <param name="value">Value that is being converted.</param>
		/// <returns>Value with it's phyisical connotation.</returns>
		public int ConvertToRealValue(int rtuId, int analogSignalAddress, int value)
		{
			SignalMapping signalMap = SignalMappingRepository.GetSignalMappingForSignal(rtuId, analogSignalAddress);

			float offsettedMaxValue = signalMap.MaxRealValue - signalMap.MinRealValue;
			float resolution = offsettedMaxValue / (signalMap.MaxSensorValue - signalMap.MinSensorValue);
			
			return (int)(resolution * value + signalMap.MinRealValue);
		}

		/// <summary>
		/// Convert real values to sensor values.
		/// </summary>
		/// <param name="rtuId">ID of the RTU.</param>
		/// <param name="analogSignalId">ID of the analog signal.</param>
		/// <param name="value">Value that is being converted.</param>
		/// <returns>Value represented in it's sensor form.</returns>
		public int ConvertToSensorValue(int rtuId, int analogSignalAddress, int value)
		{
			SignalMapping signalMap = SignalMappingRepository.GetSignalMappingForSignal(rtuId, analogSignalAddress);

			float offsettedMaxValue = signalMap.MaxRealValue - signalMap.MinRealValue;
			float offsettedValue = value - signalMap.MinRealValue;
			float resolution = (signalMap.MaxSensorValue - signalMap.MinSensorValue) / offsettedMaxValue;
			
			return (int)(resolution * offsettedValue);
		}
	}
}
