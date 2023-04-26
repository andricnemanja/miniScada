﻿using System.Collections.Generic;
using DynamicCacheManager.Model;
using DynamicCacheManager.ModelServiceReference;

namespace DynamicCacheManager
{
	public sealed class StaticDataLoader : IStaticDataLoader
	{
		private readonly IModelService modelService;
		private readonly IDynamicCacheClient dynamicCacheClient;

		public StaticDataLoader(IModelService modelService, IDynamicCacheClient dynamicCacheClient)
		{
			this.modelService = modelService;
			this.dynamicCacheClient = dynamicCacheClient;
			this.dynamicCacheClient.ConnectToDynamicCache();
		}

		public List<Rtu> InitializeData()
		{
			List<Rtu> rtus = new List<Rtu>();

			modelService.GetAllFlags();
			foreach (var rtu in modelService.GetAllRTUs())
			{
				List<AnalogSignal> analogSignals = new List<AnalogSignal>();
				foreach (var analogSignal in rtu.AnalogSignals)
				{
					AnalogSignal newAnalogSignal = new AnalogSignal(analogSignal.ID, rtu.RTUData.ID, analogSignal.Deadband, analogSignal.StaleTime);
					dynamicCacheClient.SaveSignalToCache(newAnalogSignal);
					analogSignals.Add(newAnalogSignal);
				}

				List<DiscreteSignal> discreteSignals = new List<DiscreteSignal>();
				foreach (var discreteSignal in rtu.DiscreteSignals)
				{
					DiscreteSignal newDiscreteSignal = new DiscreteSignal(discreteSignal.ID, rtu.RTUData.ID, discreteSignal.StaleTime);
					dynamicCacheClient.SaveSignalToCache(newDiscreteSignal);
					discreteSignals.Add(newDiscreteSignal);
				}

				rtus.Add(new Rtu(rtu.RTUData.ID, analogSignals, discreteSignals));
			}

			return rtus;
		}
	}
}