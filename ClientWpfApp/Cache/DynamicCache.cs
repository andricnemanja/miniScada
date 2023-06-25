using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using ClientWpfApp.Model;
using ClientWpfApp.Model.RTU;
using Contracts;
using Contracts.DTO;
using Polly;

namespace ClientWpfApp.Cache
{
	public sealed class DynamicCache : INotifyPropertyChanged
	{
		[Import(typeof(IDynamicCacheClient))]
		private IDynamicCacheClient dynamicCacheClient;
		private readonly IRtuCache rtuCache;
		private readonly AsyncPolicy<bool> retryPolicy = Policy<bool>
			.HandleResult(x => x.Equals(false))
			.WaitAndRetryForeverAsync(retryAttemp => TimeSpan.FromSeconds(5));

		public DynamicCache(IRtuCache rtuCache)
		{
			var catalog = new DirectoryCatalog(ConfigurationManager.AppSettings["DynamicCacheAdapterDirectory"]);
			var container = new CompositionContainer(catalog);
			container.ComposeParts(this);
			this.rtuCache = rtuCache;
		}

		private bool isCacheAvailable = false;

		public bool IsCacheAvailable
		{
			get { return isCacheAvailable; }
			set 
			{
				if (value != isCacheAvailable)
				{
					isCacheAvailable = value;
					RaisePropertyChanged(nameof(IsCacheAvailable));
				}
			}
		}


		/// <summary>
		/// Connect to dynamic cache. Needs to be called before trying to use any other method.
		/// </summary>
		/// <returns>True if a connection is made, False if not</returns>
		public Task Connect()
		{
			Task.Run(() => retryPolicy.ExecuteAsync(async () => 
			{
				return dynamicCacheClient.Connect();
			})).Wait();
			IsCacheAvailable = true;
			return Task.CompletedTask;
		}

		public Task CheckConnection(CancellationToken cancellationToken)
		{
			while(!cancellationToken.IsCancellationRequested)
			{
				if (!dynamicCacheClient.IsAvailable())
				{
					IsCacheAvailable = false;
					Task connectionTask = Task.Run(Connect);
					connectionTask.Wait();
				}
				Thread.Sleep(1000);
			}
			return Task.CompletedTask;
		}


		/// <summary>
		/// Read data that is currently in dynamic cache
		/// </summary>
		public void InitalScan()
		{
			foreach (var rtu in rtuCache.RtuList)
			{
				foreach (var signal in rtu.AnalogSignalValues)
				{
					SignalValueDTO dto = dynamicCacheClient.GetCurrentSignalValue(signal.AnalogSignal.ID);
					double.TryParse(dto.Value, out double value);
					signal.Value = value;
				}
				foreach (var signal in rtu.DiscreteSignalValues)
				{
					SignalValueDTO dto = dynamicCacheClient.GetCurrentSignalValue(signal.DiscreteSignal.ID);
					signal.State = dto.Value;
				}
			}
		}

		/// <summary>
		/// Listen to signal changes received from dynamic cache.
		/// </summary>
		public async void ListenToSignalChanges()
		{
			List<Task> listOfSubscriptions = new List<Task>();
			foreach (RTU rtu in rtuCache.RtuList)
			{

				listOfSubscriptions.Add(dynamicCacheClient.SubscribeToRtuChangesAsync(rtu.RTUData.ID, (SignalChangeDTO signalChangeDTO) =>
				{
					rtuCache.UpdateSignalValue(signalChangeDTO.RtuId, signalChangeDTO.SignalId, signalChangeDTO.NewValue);
				}));
			}

			await Task.WhenAll(listOfSubscriptions);
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void RaisePropertyChanged(string property)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
		}

	}
}
