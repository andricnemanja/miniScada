using System.Collections.Generic;
using ModbusServiceLibrary.Model.SignalMapping;

namespace ModbusServiceLibrary.Tests
{
	public static class MappinTestData
	{
		public static List<AnalogSignalMapping> GetAnalogSignalMappingsTestList()
		{
			return new List<AnalogSignalMapping>()
			{
				new AnalogSignalMapping()
				{
					Id = 1,
					K = 0.008,
					N = -40
				},
				new AnalogSignalMapping()
				{
					Id = 2,
					K = 0.1,
					N = -300
				},
				new AnalogSignalMapping()
				{
					Id = 3,
					K = 0.02,
					N = -100
				},
				new AnalogSignalMapping()
				{
					Id = 4,
					K = 0.01,
					N = -100
				},
				new AnalogSignalMapping()
				{
					Id = 5,
					K = 0.008,
					N = -40
				}

			};
		}

		public static List<DiscreteSignalMapping> GetDiscreteSignalMappingsTestList()
		{
			return new List<DiscreteSignalMapping>()
			{
				new DiscreteSignalMapping()
				{
					Id = 1,
					Name = "test",
					DiscreteValueToState = new Dictionary<byte, string>()
					{
						{ 0, "Error" },
						{ 1, "Open" },
						{ 2, "Close" },
						{ 3, "Transit" }
					}
				},
				new DiscreteSignalMapping()
				{
					Id = 2,
					Name = "test2",
					DiscreteValueToState = new Dictionary<byte, string>()
					{
						{ 0, "Error" },
						{ 1, "On" },
						{ 2, "Off" },
						{ 3, "Transit" }
					}
				},
				new DiscreteSignalMapping()
				{
					Id = 1,
					Name = "test",
					DiscreteValueToState = new Dictionary<byte, string>()
					{
						{ 0, "On" },
						{ 1, "Off" },
					}
				},
			};
		}
	}
}
