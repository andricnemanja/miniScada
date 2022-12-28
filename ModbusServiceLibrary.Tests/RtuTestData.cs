using System.Collections.Generic;
using ModbusServiceLibrary.Model;
using ModbusServiceLibrary.Model.RTU;
using ModbusServiceLibrary.Model.Signals;
using ModbusServiceLibrary.Model.SignalValues;

namespace ModbusServiceLibrary.Tests
{
	public static class RtuTestData
	{
		public static List<RTU> GetRtuTestList()
		{
			List<RTU> rtuList = new List<RTU>()
			{
				new RTU()
				{
					Connection = new RTUConnection(null),
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
							DiscreteSignal = new DiscreteSignal(2, 1, "DiscreteSignal 1"),
							Value = true
						},
						new DiscreteSignalValue()
						{
							DiscreteSignal = new DiscreteSignal(3, 2, "DiscreteSignal 1"),
							Value = false
						}
					}
				},
				new RTU()
				{
					Connection = new RTUConnection(null),
					RTUData = new RTUData
					{
						ID = 2,
						Name = "RTU 2",
						IpAddress = "127.0.0.1",
						Port = 503
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
							DiscreteSignal = new DiscreteSignal(2, 1, "DiscreteSignal 1"),
							Value = true
						},
						new DiscreteSignalValue()
						{
							DiscreteSignal = new DiscreteSignal(3, 2, "DiscreteSignal 1"),
							Value = false
						}
					}
				},
				new RTU()
				{
					Connection = new RTUConnection(null),
					RTUData = new RTUData
					{
						ID = 3,
						Name = "RTU 3",
						IpAddress = "127.0.0.1",
						Port = 504
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
							DiscreteSignal = new DiscreteSignal(2, 1, "DiscreteSignal 1"),
							Value = true
						},
						new DiscreteSignalValue()
						{
							DiscreteSignal = new DiscreteSignal(3, 2, "DiscreteSignal 1"),
							Value = false
						}
					}
				}
			};

			return rtuList;
		}
	}
}
