using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Threading;
using ClientWpfApp.Commands;
using ClientWpfApp.Services;
using SharedModel.Model.RTU;
using SharedModel.Model.Signals;

namespace ClientWpfApp.ViewModel
{
	internal class MainViewModel
	{
		public ICommand CreateConnectionWindowCommand { get; set; }
		public ICommand SetRegistryValuesCommand { get; set; }
		public ObservableCollection<RTU> RTUList { get; set; } = new ObservableCollection<RTU>();

		private ValuesReadingService valuesReadingService;

		public MainViewModel()
		{
			CreateConnectionWindowCommand = new CreateConnectionWindowCommand();
			SetRegistryValuesCommand = new SetRegistryValuesCommand();

			valuesReadingService = new ValuesReadingService();

			ConnectToModelService();

			DispatcherTimer timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromSeconds(1);
			timer.Tick += timer_Tick;
			timer.Start();
		}

		public void ConnectToModelService()
		{
			ModelServiceReference.ModelServiceClient modelService = new ModelServiceReference.ModelServiceClient();

			ObservableCollection<RTU> rtus = modelService.GetStaticData();
			RTUList = modelService.GetStaticData();
			
		}

		void timer_Tick(object sender, EventArgs e)
		{
			//valuesReadingService.ReadValues(RTUList);
		}
	}
}
