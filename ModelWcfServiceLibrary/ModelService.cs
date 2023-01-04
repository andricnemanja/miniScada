using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using ModelWcfServiceLibrary.Model.RTU;
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

		/// <summary>
		/// Initializes a new instance of the <see cref="ModelService"/>
		/// </summary>
		/// <param name="rtuRepository">Instance of the <see cref="IRtuRepository"/> class</param>
		/// <param name="analogSignalMappingRepository"></param>
		/// <param name="discreteSignalMappingRepository"></param>
		public ModelService(IRtuRepository rtuRepository, IAnalogSignalMappingRepository analogSignalMappingRepository, IDiscreteSignalMappingRepository discreteSignalMappingRepository)
		{
			this.rtuRepository = rtuRepository;
			this.analogSignalMappingRepository = analogSignalMappingRepository;
			this.discreteSignalMappingRepository = discreteSignalMappingRepository;
		}

		/// <summary>
		/// Get static data for all RTUs
		/// </summary>
		/// <returns>List of RTUs</returns>
		public List<RTU> GetAllRTUs()
		{
			return rtuRepository.RtuList;
		}
		/// <summary>
		/// Get static data for RTU with given ID
		/// </summary>
		/// <param name="id">Unique identifier for RTU</param>
		/// <returns>RTU with given ID</returns>
		public RTU GetRTU(int id)
		{
			RTU rtu = rtuRepository.GetRTUByID(id);
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
		public IEnumerable<DiscreteSignal> GetDiscreteSignalsForRtu(int id)
		{
			return rtuRepository.GetDiscreteSignalsForRtu(id).ToList();
		}
		/// <summary>
		/// Get list of analog signals for RTU with given ID
		/// </summary>
		/// <param name="id">Unique identifier for RTU</param>
		/// <returns>List of analog signals</returns>
		public IEnumerable<AnalogSignal> GetAnalogSignalsForRtu(int id)
		{
			return rtuRepository.GetAnalogSignalsForRtu(id);
		}
		/// <summary>
		/// Get RTUs essential data
		/// </summary>
		/// <returns>List of essential data for all RTUs</returns>
		public IEnumerable<RTUData> GetRTUsEssentialData()
		{
			return rtuRepository.GetRTUsEssentialData();
		}

		/// <summary>
		/// Get all analog signal mappings
		/// </summary>
		/// <returns>List of analog signal mappings</returns>
		public IEnumerable<AnalogSignalMapping> GetAnalogSignalMappings()
		{
			return analogSignalMappingRepository.AnalogSignalMappingList;
		}

		/// <summary>
		/// Get all discrete signal mappings
		/// </summary>
		/// <returns>List of discrete signal mappings</returns>
		public IEnumerable<DiscreteSignalMapping> GetDiscreteSignalMappings()
		{
			return discreteSignalMappingRepository.DiscreteSignalMappingList;
		}
	}
}
