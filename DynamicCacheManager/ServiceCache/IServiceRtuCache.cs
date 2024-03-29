﻿using System.Collections.Generic;
using DynamicCacheManager.Model;

namespace DynamicCacheManager.ServiceCache
{
	public interface IServiceRtuCache
	{
		List<Rtu> RtuList { get; }
		void InitializeData();
		ISignal GetSignal(int rtuId, int signalId);
	}
}