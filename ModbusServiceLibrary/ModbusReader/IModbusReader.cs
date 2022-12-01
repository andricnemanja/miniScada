using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusServiceLibrary.ModbusReader
{
	public interface IModbusReader
	{
		int ReadRegister(int id, int signalAddress);

		int ReadAnalogInput(int id, int signalAddress);
		
		bool ReadDiscreteInput(int id, int signalAddress);
		
		bool ReadCoil(int id, int signalAddress);
	}
}
