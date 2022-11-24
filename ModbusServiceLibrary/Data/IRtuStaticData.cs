using ModbusServiceLibrary.Model.RTU;
using System.Collections.Generic;

namespace ModbusServiceLibrary.Data
{
	public interface IRtuStaticData
	{
		List<RTU> RtuList { get; set; }

		void InitializeData();
	}
}