using ModbusServiceLibrary.Model.RTU;
using System.Collections.Generic;

namespace ModbusServiceLibrary.Data
{
	public interface IRtuDataList
	{
		List<RTU> RtuList { get; }
		void InitializeData();
	}
}