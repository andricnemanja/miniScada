using System.Collections.Generic;
using ModbusServiceLibrary.Model.RTU;

namespace ModbusServiceLibrary.ServiceReader
{
	public interface IModelServiceReader
	{
		List<RTU> ReadAllRTUs();
	}
}