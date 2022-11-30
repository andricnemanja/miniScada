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
using System.ServiceModel;
using ClientWpfApp.ModbusCallback;

namespace ClientWpfApp.ViewModel
{
	internal class MainViewModel
	{
		public ICommand CreateConnectionWindowCommand { get; set; }
		public ICommand SetRegistryValuesCommand { get; set; }
		public ICommand ReadRtuValuesCommand { get; set; }
		public ObservableCollection<RTU> RTUList { get; set; } = new ObservableCollection<RTU>();

		private RtuValuesReader valuesReader;
		private ModelServiceReader modelServiceReader;
		private ModbusServiceReference.ModbusDuplexClient modbusServiceClient;

		public MainViewModel()
		{
			CreateConnectionWindowCommand = new CreateConnectionWindowCommand();
			SetRegistryValuesCommand = new SetRegistryValuesCommand();

			modelServiceReader = new ModelServiceReader(new ModelServiceReference.ModelServiceClient());

			ReadRTUData();
			ConnectToModbusService();

			valuesReader = new RtuValuesReader(modbusServiceClient, RTUList);
			ReadRtuValuesCommand = new ReadRtuValuesCommand(valuesReader);

		}

		public void ReadRTUData()
		{
			RTUList = modelServiceReader.ReadAllRTUs();
		}

		public void ConnectToModbusService()
		{
			InstanceContext instanceContext = new InstanceContext(new ModbusServiceCallback(RTUList));
			modbusServiceClient = new ModbusServiceReference.ModbusDuplexClient(instanceContext);
		}

	}
}
