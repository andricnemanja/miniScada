using System.Collections.ObjectModel;
using System.Windows.Input;
using ClientWpfApp.Commands;
using ClientWpfApp.Model.RTU;
using ClientWpfApp.Model.SignalValues;
using ClientWpfApp.ServiceClients;

namespace ClientWpfApp.ViewModel
{
	public sealed class MainViewModel
	{
		#region Fields
		private ModbusServiceClient modbusServiceClient;
		private ModelServiceConverter modelServiceConverter;
		private ModbusServiceReference.ModbusDuplexClient modbusDuplexClient;
		#endregion Fields

		#region Commands
		public ICommand ConnectToRtuCommand { get; set; }
		public ICommand SetRegistryValuesCommand { get; set; }
		public ICommand ReadRtuValuesCommand { get; set; }
		public DiscreteSignalCheckboxCommand DiscreteSignalCheckboxCommand { get; set; }
		public SavaAnalogSignalCommand SavaAnalogSignalCommand { get; set; }
		#endregion Commands

		#region Public Properties
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
		#endregion Public Properties

		public MainViewModel()
		{
			ConnectToModelService();
			ReadRTUStaticData();
			ConnectToServices();
			InitializeCommands();
		}

		private void ConnectToModelService()
		{
			modelServiceConverter = new ModelServiceConverter(new ModelServiceReference.ModelServiceClient());
		}
		private void ReadRTUStaticData()
		{
			RTUList = modelServiceConverter.ReadAllRTUs();
		}

		private void ConnectToServices()
		{
			modbusServiceClient = new ModbusServiceClient(modbusDuplexClient, RTUList);
			modbusDuplexClient = modbusServiceClient.ConnectToModbusService();
		}

		private void InitializeCommands()
		{
			ReadRtuValuesCommand = new ReadRtuValuesCommand(modbusServiceClient);
			SetRegistryValuesCommand = new SetRegistryValuesCommand();
			ConnectToRtuCommand = new ConnectToRtuCommand(new RtuConnection(modbusDuplexClient));
			DiscreteSignalCheckboxCommand = new DiscreteSignalCheckboxCommand(modbusServiceClient);
			SavaAnalogSignalCommand = new SavaAnalogSignalCommand(modbusServiceClient);
		}
	}
}
