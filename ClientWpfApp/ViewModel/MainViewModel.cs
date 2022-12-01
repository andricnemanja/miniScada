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
using ClientWpfApp.Model.SignalValues;

namespace ClientWpfApp.ViewModel
{
	internal class MainViewModel
	{
		public ICommand ConnectToRtuCommand { get; set; }
		public ICommand SetRegistryValuesCommand { get; set; }
		public ICommand ReadRtuValuesCommand { get; set; }
		public DiscreteSignalCheckboxCommand DiscreteSignalCheckboxCommand { get; set; }
		public SavaAnalogSignalCommand SavaAnalogSignalCommand { get; set; }
		public ObservableCollection<RTU> RTUList { get; set; } = new ObservableCollection<RTU>();

		private RTU _selectedRtu;

		public RTU SelectedRtu
		{
			get { return _selectedRtu; }
			set 
			{ 
				_selectedRtu = value; 
				DiscreteSignalCheckboxCommand.SelectedRtu = value;
				SavaAnalogSignalCommand.SelectedRtu = value;
			}
		}

		public DiscreteSignalValue SelectedDiscreteSignal { get; set; }


		private RtuValuesReader valuesReader;
		private ModelServiceReader modelServiceReader;
		private RtuValueWriter rtuValueWriter;
		private RtuConnection rtuConnection;

		private ModbusServiceReference.ModbusDuplexClient modbusServiceClient;

		public MainViewModel()
		{
			modelServiceReader = new ModelServiceReader(new ModelServiceReference.ModelServiceClient());

			ReadRTUData();
			ConnectToModbusService();

			valuesReader = new RtuValuesReader(modbusServiceClient, RTUList);
			rtuValueWriter = new RtuValueWriter(modbusServiceClient);
			rtuConnection = new RtuConnection(modbusServiceClient);

			ReadRtuValuesCommand = new ReadRtuValuesCommand(valuesReader);
			SetRegistryValuesCommand = new SetRegistryValuesCommand();

			ConnectToRtuCommand = new ConnectToRtuCommand(rtuConnection);

			DiscreteSignalCheckboxCommand = new DiscreteSignalCheckboxCommand(rtuValueWriter);
			SavaAnalogSignalCommand = new SavaAnalogSignalCommand(rtuValueWriter);
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
