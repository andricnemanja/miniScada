﻿using ModbusServiceLibrary.DynamicCacheManagerReference;
using ModbusServiceLibrary.Modbus.ModbusConnection.States;

namespace ModbusServiceLibrary.Modbus.ModbusConnection
{
	/// <summary>
	/// <c>IRtuConnectionFactory</c> creates IRtuConnection instances.
	/// </summary>
	public interface IRtuConnectionFactory
	{
		/// <summary>
		/// Create <c>IRtuConnection</c> for RTU.
		/// </summary>
		/// <param name="rtuId">Id of RTU for which connection is created.</param>
		/// <param name="dynamicCacheManagerServiceClient">Client for communication with dynamic cache.</param>
		/// <param name="rtuConnectionStateFactory">Factory for creating Rtu connection states.</param>
		/// <returns><see cref="IRtuConnection"/>New connection for RTU.</returns>
		IRtuConnection GetRtuConnection(int rtuId, IDynamicCacheManagerService dynamicCacheManagerServiceClient, IRtuConnectionStateFactory rtuConnectionStateFactory);
	}
}
