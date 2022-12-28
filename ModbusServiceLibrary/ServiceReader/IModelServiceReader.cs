using System;
using System.Collections.Generic;
using ModbusServiceLibrary.Model.RTU;

namespace ModbusServiceLibrary.ServiceReader
{
	public interface IModelServiceReader
	{
		/// <summary>
		/// Reads all RTUs
		/// </summary>
		/// <returns>List of RTUs</returns>
		List<RTU> ReadAllRTUs();
	}
}