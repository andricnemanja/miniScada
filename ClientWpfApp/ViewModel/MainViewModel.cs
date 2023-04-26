using System;
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

			foreach(var rtu in RtuCache.RtuList)
			{
				foreach (var signal in rtu.AnalogSignalValues)
				{
					db.HashGet("signal:" + signal.AnalogSignal.ID, "value").TryParse(out double signalValue);
					signal.Value = signalValue;
				}
				foreach (var signal in rtu.DiscreteSignalValues)
				{ 
					signal.State = db.HashGet("signal:" + signal.DiscreteSignal.ID, "value");
				}
			}

			List<Task> listOfSubscriptions = new List<Task>();
			foreach(RTU rtu in RtuCache.RtuList)
			{
				listOfSubscriptions.Add(subscriber.SubscribeAsync("rtu:" + rtu.RTUData.ID + ".*", (channel, value) =>
				{
					ChangedSignalData changedSignalData = ParseSubscriptionChannel(channel);
					RtuCache.UpdateSignalValue(changedSignalData.RtuId, changedSignalData.SignalId, value);
				}));
			}

			
			listOfSubscriptions.Add(subscriber.SubscribeAsync("*:flags", (channel, value) =>
			{
				var signalId = Int32.Parse(channel.ToString().Split(':')[1]);
				foreach(var rtu in RtuCache.RtuList)
				{
					var analogSignal = rtu.AnalogSignalValues.FirstOrDefault(s => s.AnalogSignal.ID == signalId);
					if(analogSignal != null)
					{
						analogSignal.AnalogSignal.SignalFlags.Add(new Model.Flags.Flag(value, "", Model.Flags.FlagType.Warn));
						return;
					}

					var discreteSignal = rtu.DiscreteSignalValues.FirstOrDefault(s => s.DiscreteSignal.ID == signalId);
					if (discreteSignal != null)
					{
						discreteSignal.DiscreteSignal.SignalFlags.Add(new Model.Flags.Flag(value, "", Model.Flags.FlagType.Warn));
						return;
					}
				}
			}));
			

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
