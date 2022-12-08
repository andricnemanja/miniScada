using System.Collections.Generic;
using ModbusServiceLibrary.Model.RTU;
using ModbusServiceLibrary.Model.Signals;
using ModbusServiceLibrary.Model.SignalValues;

namespace ModbusServiceLibrary.Tests.CommandTests
{
	public class RtuTestData
	{
		public static List<RTU> GetRtuTestList()
		{
			RTU rtu = new RTU()
			{
				Connection = null,
				RTUData = new RTUData
				{
					ID = 1,
					Name = "RTU 1",
					IpAddress = "127.0.0.1",
					Port = 502
				},
				AnalogSignalValues = new List<AnalogSignalValue>()
				{
					new AnalogSignalValue()
					{
						AnalogSignal = new AnalogSignal(1, 1, "AnalogSignal 1"),
						Value = 0
					},
					new AnalogSignalValue()
					{
						AnalogSignal = new AnalogSignal(2, 5, "AnalogSignal 2"),
						Value = 10
					},
					new AnalogSignalValue()
					{
						AnalogSignal = new AnalogSignal(3, 7, "AnalogSignal 3"),
						Value = 14
					}
				},
				DiscreteSignalValues = new List<DiscreteSignalValue>()
				{
					new DiscreteSignalValue()
					{
						DiscreteSignal = new DiscreteSignal(1, 0, "DiscreteSignal 1"),
						Value = false
					},
					new DiscreteSignalValue()
					{
						DiscreteSignal = new DiscreteSignal(2, 2, "DiscreteSignal 1"),
						Value = true
					},
					new DiscreteSignalValue()
					{
						DiscreteSignal = new DiscreteSignal(3, 5, "DiscreteSignal 1"),
						Value = false
					}
				}
			};

			return new List<RTU> { rtu };
		}
	}
}
