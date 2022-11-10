using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Threading;
using ClientWpfApp.Commands;
using ClientWpfApp.Services;
using ClientWpfApp.Model.RTU;
using ClientWpfApp.Model.Signals;
using ClientWpfApp.ServiceReader;

namespace ClientWpfApp.ViewModel
{
	internal class MainViewModel
	{
		public ICommand CreateConnectionWindowCommand { get; set; }
		public ICommand SetRegistryValuesCommand { get; set; }
		public ObservableCollection<RTU> RTUList { get; set; } = new ObservableCollection<RTU>();
		private ValuesReader valuesReader;
		private ModelServiceReader modelServiceReader;

		public MainViewModel()
		{
			CreateConnectionWindowCommand = new CreateConnectionWindowCommand();
			SetRegistryValuesCommand = new SetRegistryValuesCommand();

			valuesReader = new ValuesReader();
			modelServiceReader = new ModelServiceReader(new ModelServiceReference.ModelServiceClient());

			ReadRTUData();

			DispatcherTimer timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromSeconds(1);
			timer.Tick += timer_Tick;
			timer.Start();
		}

		public void ReadRTUData()
		{
			RTUList = modelServiceReader.ReadAllRTUs();
		}

		void timer_Tick(object sender, EventArgs e)
		{
			valuesReader.ReadValues(RTUList);
		}
	}
}
