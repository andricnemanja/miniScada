using System.Collections.Generic;

namespace ModbusServiceLibrary.Modbus.ModbusDataTypes
{
	public delegate bool AnalogInputReadOperation(int rtuId, int startAddress, int numberOfPoints, out ushort[] values);

	public sealed class AnalogInputRange
	{
		private readonly SortedList<int, IAnalogInput> analogInputs = new SortedList<int, IAnalogInput>();
		private readonly AnalogInputReadOperation readOperation;

		public AnalogInputRange(int rtuId, AnalogInputReadOperation readOperation)
		{
			RtuId = rtuId;
			this.readOperation = readOperation;
		}

		public int RtuId { get; }

		public void AddInput(IAnalogInput input)
		{
			analogInputs.Add(input.Address, input);
		}

		public void ReadRage()
		{
			int startAddress = analogInputs[0].Address;
			int endAddress = analogInputs[analogInputs.Count - 1].Address;
			int numberOfPoints = endAddress - startAddress + 1;

			ushort[] readValue;
			if (!readOperation(RtuId, startAddress, numberOfPoints, out readValue))
			{
				AcquisitionQueue.Instance.Enqueue(new RemoteOperationFailed());
				return;
			}

			AnalogInputResult result = new AnalogInputResult(RtuId);
			foreach (var address in analogInputs.Keys)
			{
				result.Values[address] = readValue[address - startAddress];
			}

			AcquisitionQueue.Instance.Enqueue(result);
		}
	}
}
