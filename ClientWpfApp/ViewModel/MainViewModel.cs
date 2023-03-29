using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ClientWpfApp.Commands;
using ClientWpfApp.Model;
using ClientWpfApp.Model.RTU;
using ClientWpfApp.Model.SignalValues;
using ClientWpfApp.ServiceClients;
using StackExchange.Redis;

namespace ClientWpfApp.ViewModel
{
	public sealed class MainViewModel
	{
		#region Fields
		private ModbusServiceClient modbusServiceClient;
		private ModelServiceConverter modelServiceConverter;
		private ModbusServiceReference.ModbusDuplexClient modbusDuplexClient;
		private ISubscriber subscriber;
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
			Task.Run(GetMessages);
		}

		public async Task GetMessages()
		{
			var muxer = ConnectionMultiplexer.Connect("localhost:6379");
			var db = muxer.GetDatabase();
			subscriber = muxer.GetSubscriber();

			var signalValue = db.HashGet("signal:1", "value");
			signalValue.TryParse(out double signalDoubleValue);

			RtuCache.RtuList.FirstOrDefault(r => r.RTUData.ID == 1).AnalogSignalValues.FirstOrDefault(s => s.AnalogSignal.ID == 1).Value = signalDoubleValue;

			List<Task> listOfSubscriptions = new List<Task>();
			foreach(RTU rtu in RtuCache.RtuList)
			{
				listOfSubscriptions.Add(subscriber.SubscribeAsync("rtu:" + rtu.RTUData.ID + ".*", (channel, value) =>
				{
					ChangedSignalData changedSignalData = ParseSubscriptionChannel(channel);
					RtuCache.UpdateSignalValue(changedSignalData.RtuId, changedSignalData.SignalId, value);
				}));
			}

			await Task.WhenAll(listOfSubscriptions);
		}

		private ChangedSignalData ParseSubscriptionChannel(string channelName)
		{
			string[] channelNameArr = channelName.Split('.');
			int rtuId = int.Parse(channelNameArr[0].Split(':')[1]);
			int signalId = int.Parse(channelNameArr[2].Split(':')[1]);

			return new ChangedSignalData(rtuId, signalId);
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
	}
}
