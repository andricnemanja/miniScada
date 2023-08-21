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
		private ModbusServiceWpfClient modbusServiceWpfClient;
		private ModelServiceConverter modelServiceConverter;
		private ModbusServiceReference.ModbusServiceClient modbusServiceClient;
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
		public IFlagCache FlagCache { get; set; } = new FlagCache();

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
			ReadFlagStaticData();
			ConnectToModbusServices();
			InitializeCommands();
			ConnectToDynamicCache();

		}

		private void ReadRTUStaticData()
		{
			RtuCache.ReadRtuStaticData();
		}

		private void ReadFlagStaticData()
		{
			FlagCache.ReadFlagStaticData();
		}

		private void ConnectToModbusServices()
		{
			modbusServiceWpfClient = new ModbusServiceWpfClient(modbusServiceClient, RtuCache);
			modbusServiceClient = modbusServiceWpfClient.ConnectToModbusService();
		}

		private void InitializeCommands()
		{
			ReadRtuValuesCommand = new ReadRtuValuesCommand(modbusServiceWpfClient);
			ConnectToRtuCommand = new ConnectToRtuCommand(new RtuConnection(modbusServiceWpfClient));
			SavaAnalogSignalCommand = new SavaAnalogSignalCommand(modbusServiceWpfClient);
			ChangeDiscreteSignalFirstStateCommand = new ChangeDiscreteSignalFirstStateCommand(modbusServiceWpfClient);
			ChangeDiscreteSignalSecondStateCommand = new ChangeDiscreteSignalSecondStateCommand(modbusServiceWpfClient);
		}

		private void ConnectToDynamicCache()
		{
			dynamicCache = new DynamicCache(RtuCache, FlagCache);
			Task.Run(dynamicCache.Connect).Wait();
			Task.Run(() => dynamicCache.CheckConnection(new System.Threading.CancellationToken())) ;
			dynamicCache.InitalScan();
			Task.Run(dynamicCache.ListenToSignalChanges);
		}
	}
}
