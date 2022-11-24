using ModbusServiceLibrary.Model.RTU;
using System.Collections.Generic;

namespace ModbusServiceLibrary.ServiceReader
{
	public interface IModelServiceReader
	{
		List<RTU> ReadAllRTUs();
	}
}