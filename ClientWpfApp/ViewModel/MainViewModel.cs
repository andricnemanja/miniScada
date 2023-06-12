using System.Threading.Tasks;
using System.Windows.Input;
using ClientWpfApp.Cache;
using ClientWpfApp.Commands;
using ClientWpfApp.Model;
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
		private DynamicCache dynamicCache;
		#endregion Fields

		#region Commands
		public ICommand ConnectToRtuCommand { get; set; }
		public ICommand ReadRtuValuesCommand { get; set; }
		public SavaAnalogSignalCommand SavaAnalogSignalCommand { get; set; }
		public ChangeDiscreteSignalFirstStateCommand ChangeDiscreteSignalFirstStateCommand { get; set; }
		public ChangeDiscreteSignalSecondStateCommand ChangeDiscreteSignalSecondStateCommand { get; set; }
		#endregion Commands

		#region Public Properties
		public IRtuCache RtuCache { get; set; } = new RtuCache();

		private RTU _selectedRtu;

		public RTU SelectedRtu
		{
			get { return _selectedRtu; }
			set
			{
				_selectedRtu = value;
				ChangeDiscreteSignalFirstStateCommand.SelectedRtu = value;
				ChangeDiscreteSignalSecondStateCommand.SelectedRtu = value;
				SavaAnalogSignalCommand.SelectedRtu = value;
			}
		}

		public DiscreteSignalValue SelectedDiscreteSignal { get; set; }
		#endregion Public Properties

		public MainViewModel()
		{
			ReadRTUStaticData();
			ConnectToModbusServices();
			InitializeCommands();
			ConnectToDynamicCache();

		}

		private void ReadRTUStaticData()
		{
			RtuCache.ReadRtuStaticData();
		}

		private void ConnectToModbusServices()
		{
			modbusServiceClient = new ModbusServiceClient(modbusDuplexClient, RtuCache);
			modbusDuplexClient = modbusServiceClient.ConnectToModbusService();
		}

		private void InitializeCommands()
		{
			ReadRtuValuesCommand = new ReadRtuValuesCommand(modbusServiceClient);
			ConnectToRtuCommand = new ConnectToRtuCommand(new RtuConnection(modbusDuplexClient));
			SavaAnalogSignalCommand = new SavaAnalogSignalCommand(modbusServiceClient);
			ChangeDiscreteSignalFirstStateCommand = new ChangeDiscreteSignalFirstStateCommand(modbusServiceClient);
			ChangeDiscreteSignalSecondStateCommand = new ChangeDiscreteSignalSecondStateCommand(modbusServiceClient);
		}

		private void ConnectToDynamicCache()
		{
			dynamicCache = new DynamicCache(RtuCache);
			dynamicCache.Connect();
			dynamicCache.InitalScan();
			Task.Run(dynamicCache.ListenToSignalChanges);
		}
	}
}
