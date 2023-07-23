using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using ModelWcfServiceLibrary.Model.CronExpressionMappings;
using ModelWcfServiceLibrary.Model.Flags;
using ModelWcfServiceLibrary.Model.RTU;
using ModelWcfServiceLibrary.Model.ScanPeriodMapping;
using ModelWcfServiceLibrary.Model.SignalMapping;
using ModelWcfServiceLibrary.Model.Signals;
using ModelWcfServiceLibrary.Repository;

namespace ModelWcfServiceLibrary
{
	/// <summary>
	/// Provides endpoints for Model Service
	/// </summary>
	public sealed class ModelService : IModelService
	{
		private readonly IRtuRepository rtuRepository;
		private readonly IDiscreteSignalMappingRepository discreteSignalMappingRepository;
		private readonly IAnalogSignalMappingRepository analogSignalMappingRepository;
		private readonly ISignalScanPeriodMappingRepository signalScanPeriodMappingRepository;
		private readonly IFlagRepository flagRepository;
		private readonly ICronExpressionMappingRepository cronExpressionMappingRepository;

		/// <summary>
		/// Initializes a new instance of the <see cref="ModelService"/>
		/// </summary>
		/// <param name="rtuRepository">Instance of the <see cref="IRtuRepository"/> class</param>
		/// <param name="analogSignalMappingRepository"></param>
		/// <param name="discreteSignalMappingRepository"></param>
		/// <param name="cronExpressionMappingRepository"></param>
		public ModelService(IRtuRepository rtuRepository, IAnalogSignalMappingRepository analogSignalMappingRepository, 
			IDiscreteSignalMappingRepository discreteSignalMappingRepository, ISignalScanPeriodMappingRepository signalScanPeriodMappingRepository, 
			IFlagRepository flagRepository, ICronExpressionMappingRepository cronExpressionMappingRepository)
		{
			this.rtuRepository = rtuRepository;
			this.analogSignalMappingRepository = analogSignalMappingRepository;
			this.discreteSignalMappingRepository = discreteSignalMappingRepository;
			this.signalScanPeriodMappingRepository = signalScanPeriodMappingRepository;
			this.flagRepository = flagRepository;
			this.cronExpressionMappingRepository = cronExpressionMappingRepository;
		}

		/// <summary>
		/// Get static data for all RTUs
		/// </summary>
		/// <returns>List of RTUs</returns>
		public List<ModelRTU> GetAllRTUs()
		{
			return rtuRepository.RtuList;
		}
		/// <summary>
		/// Get static data for RTU with given ID
		/// </summary>
		/// <param name="id">Unique identifier for RTU</param>
		/// <returns>RTU with given ID</returns>
		public ModelRTU GetRTU(int id)
		{
			ModelRTU rtu = rtuRepository.GetRTUByID(id);
			if (rtu == null)
			{
				ModelServiceException ex = new ModelServiceException(FaultCodes.IdDoesNotExist);
				throw new FaultException<ModelServiceException>(new ModelServiceException(FaultCodes.IdDoesNotExist));
			}

			return rtu;
		}
		/// <summary>
		/// Get list of discrete signals for RTU with given ID
		/// </summary>
		/// <param name="id">Unique identifier for RTU</param>
		/// <returns>List of discrete signals</returns>
		public IEnumerable<ModelDiscreteSignal> GetDiscreteSignalsForRtu(int id)
		{
			return rtuRepository.GetDiscreteSignalsForRtu(id).ToList();
		}
		/// <summary>
		/// Get list of analog signals for RTU with given ID
		/// </summary>
		/// <param name="id">Unique identifier for RTU</param>
		/// <returns>List of analog signals</returns>
		public IEnumerable<ModelAnalogSignal> GetAnalogSignalsForRtu(int id)
		{
			return rtuRepository.GetAnalogSignalsForRtu(id);
		}
		/// <summary>
		/// Get RTUs essential data
		/// </summary>
		/// <returns>List of essential data for all RTUs</returns>
		public IEnumerable<ModelRTUData> GetRTUsEssentialData()
		{
			return rtuRepository.GetRTUsEssentialData();
		}

		/// <summary>
		/// Get all analog signal mappings
		/// </summary>
		/// <returns>List of analog signal mappings</returns>
		public IEnumerable<ModelAnalogSignalMapping> GetAnalogSignalMappings()
		{
			return analogSignalMappingRepository.AnalogSignalMappingList;
		}

		/// <summary>
		/// Get all discrete signal mappings
		/// </summary>
		/// <returns>List of discrete signal mappings</returns>
		public IEnumerable<ModelDiscreteSignalMapping> GetDiscreteSignalMappings()
		{
			return discreteSignalMappingRepository.DiscreteSignalMappingList;
		}

		/// <summary>
		/// Get possible states for discrete signal
		/// </summary>
		/// <returns>List of discrete signal mappings</returns>
		public string[] GetDiscreteSignalPossibleStates(int rtuId, int signalAddress)
		{
			ModelRTU rtu = rtuRepository.GetRTUByID(rtuId);
			ModelDiscreteSignal signal = rtu.DiscreteSignals.FirstOrDefault(s => s.Address == signalAddress);
			return discreteSignalMappingRepository.GetDiscreteSignalPossibleStates(signal.MappingId);
		}

		/// <summary>
		/// Gets signal scan period mappings.
		/// </summary>
		/// <returns>List of the SignalScanPeriodMappings.</returns>
		public IEnumerable<SignalScanPeriodMapping> GetSignalScanPeriodMappings()
		{
			return signalScanPeriodMappingRepository.SignalScanPeriodMappingList;
		}
		
		/// <summary>
		/// Gets all the flags.
		/// </summary>
		/// <returns>List of flags.</returns>
		public IEnumerable<Flag> GetAllFlags()
		{
			return flagRepository.FlagList;
		}

		public IEnumerable<CronExpressionMapping> GetCronExpressionMappings()
		{
			return cronExpressionMappingRepository.CronExpressionMappingList;
		}
	}
}
