using System.Collections.Generic;
using ModelWcfServiceLibrary.Model.RTU;
using ModelWcfServiceLibrary.Repository;
<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.ServiceModel;
=======
>>>>>>> 9e27fb551f1a77e880ea5e13e8455ad8bb04d5e8

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

<<<<<<< HEAD
        /// <summary>
        /// Gets the list of RTUs from the repository.
        /// </summary>
        /// <returns>List of RTUs.</returns>
        public List<RTU> GetStaticData()
        {
            return RTURepository.RtuList;
        }

        /// <summary>
        /// Gets the specific RTU via its ID number.
        /// </summary>
        /// <param name="id">Identification number that is unique for every RTU</param>
        /// <returns>RTU with the specified ID.</returns>
        /// <exception cref="System.ServiceModel.FaultException"></exception>
        public RTU GetRTU(int id)
        {
            RTU rtu = RTURepository.GetRTUByID(id);
            if (rtu == null)
            {
                ModelServiceException ex = new ModelServiceException(FaultCodes.IdDoesNotExist);
				throw new FaultException<ModelServiceException>(new ModelServiceException(FaultCodes.IdDoesNotExist));
			} 
                
            return rtu;
        }
    }
=======
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
			return rtuRepository.GetRTUByID(id);
		}
	}
>>>>>>> 9e27fb551f1a77e880ea5e13e8455ad8bb04d5e8
}
