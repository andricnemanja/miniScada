using System.Collections.Generic;
using System.ServiceModel;
using ModelWcfServiceLibrary.Model.RTU;
using ModelWcfServiceLibrary.Repository;

namespace ModelWcfServiceLibrary
{
	/// <summary>
	/// Provides endpoints for Model Service
	/// </summary>
	public sealed class ModelService : IModelService
	{
		private readonly IRtuRepository rtuRepository;

		/// <summary>
		/// Initializes a new instance of the <see cref="ModelService"/>
		/// </summary>
		/// <param name="rtuRepository">Instance of the <see cref="IRtuRepository"/> class</param>
		public ModelService(IRtuRepository rtuRepository)
		{
			this.rtuRepository = rtuRepository;
		}

		/// <summary>
		/// Get static data for all RTUs
		/// </summary>
		/// <returns>List of RTUs</returns>
		public List<RTU> GetStaticData()
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
	}
}
