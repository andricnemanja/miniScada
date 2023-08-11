using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ClientWpfApp.Model.Flags;
using ClientWpfApp.Model.RTU;
using ClientWpfApp.Model.Signals;
using ClientWpfApp.Model.SignalValues;

namespace ClientWpfApp.ServiceClients
{
	public sealed class ModelServiceConverter
	{
		private readonly ModelServiceReference.ModelServiceClient modelService;

		public ModelServiceConverter(ModelServiceReference.ModelServiceClient modelService)
		{
			this.modelService = modelService;
		}

		public ObservableCollection<RTU> ReadAllRTUs()
		{
			ObservableCollection<RTU> rtus = new ObservableCollection<RTU>();

			foreach (var rtu in modelService.GetRTUsEssentialData())
			{
				RTU newRTU = new RTU()
				{
					RTUData = new RTUData()
					{
						ID = rtu.ID,
						IpAddress = rtu.IpAddress,
						Name = rtu.Name,
						Port = rtu.Port
					},
					IsConnected = false,
					OnScan = true,
					AnalogSignalValues = GetAnalogSignalValuesForRTU(rtu.ID),
					DiscreteSignalValues = GetDiscreteSignalValuesForRTU(rtu.ID)
				};
				rtus.Add(newRTU);
			}

			return rtus;
		}
		public List<Flag> ReadAllFlags()
		{
			List<Flag> flags = new List<Flag>();

			foreach (var modelFlag in modelService.GetAllFlags())
			{
				Flag newFlag = new Flag(modelFlag);
				flags.Add(newFlag);
			}

			return flags;
		}

		private ObservableCollection<AnalogSignalValue> GetAnalogSignalValuesForRTU(int rtuID)
		{
			ObservableCollection<AnalogSignalValue> analogSignalValues = new ObservableCollection<AnalogSignalValue>();

			foreach (var analogSignal in modelService.GetAnalogSignalsForRtu(rtuID))
			{
				analogSignalValues.Add(new AnalogSignalValue()
				{
					AnalogSignal = new AnalogSignal
					{
						Address = analogSignal.Address,
						ID = analogSignal.ID,
						Name = analogSignal.Name,
						AccessType = (SignalAccessType)analogSignal.AccessType
					},
					Value = 0
				});
			}

			return analogSignalValues;
		}

		private ObservableCollection<DiscreteSignalValue> GetDiscreteSignalValuesForRTU(int rtuID)
		{
			ObservableCollection<DiscreteSignalValue> discreteSignalValues = new ObservableCollection<DiscreteSignalValue>();

			foreach (var discreteSignal in modelService.GetDiscreteSignalsForRtu(rtuID))
			{
				discreteSignalValues.Add(new DiscreteSignalValue()
				{
					DiscreteSignal = new DiscreteSignal
					{
						Address = discreteSignal.Address,
						ID = discreteSignal.ID,
						Name = discreteSignal.Name,
						AccessType = (SignalAccessType)discreteSignal.AccessType
					},
					State = "",
					PossibleStates = modelService.GetDiscreteSignalPossibleStates(rtuID, discreteSignal.ID).ToArray()
				});
			}

			return discreteSignalValues;
		}
	}
}
