using ModbusConnection.Commands;
using ModbusConnection.Model;
using ModbusConnection.Model.Signals;
using ModbusConnection.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace ModbusConnection.ViewModel
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
			ModelServiceReference.ModelServiceClient modelService = new();

			foreach(var rtu in modelService.GetStaticDataAsync().Result)
			{
				ObservableCollection<ISignal> discreteSignals = new ObservableCollection<ISignal>();
				ObservableCollection<ISignal> analogSignals = new ObservableCollection<ISignal>();

				foreach (var discreteSignal in rtu.DiscreteSignals)
				{
					discreteSignals.Add(new DiscreteSignal(discreteSignal.Address, discreteSignal.Name, false));
				}
				foreach (var analogSignal in rtu.AnalogSignals)
				{
					analogSignals.Add(new AnalogSignal(analogSignal.Address, analogSignal.Name, 0));
				}

				RTUList.Add(new RTU(new RTUData(rtu.Name, rtu.Address, rtu.Port), 
									new RTUValues(discreteSignals, analogSignals),
									new RTUConnection(null)));

			}
		}

		void timer_Tick(object sender, EventArgs e)
		{
			valuesReadingService.ReadValues(RTUList);
		}
	}
}
