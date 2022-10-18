using ModelWcfServiceLibrary.Model.RTU;
using ModelWcfServiceLibrary.Repository;
using System.Collections.Generic;


namespace ModelWcfServiceLibrary
{
    public class ModelService : IModelService
    {
        public IRtuRepository RTURepository { get; set; }

        public ModelService(IRtuRepository rtuRepository)
        {
            RTURepository = rtuRepository;
        }

        public List<RTU> GetStaticData()
        {
            return RTURepository.RtuList;
        }

        public RTU GetRTU(int id)
        {
            return RTURepository.GetRTUByID(id);
        }
    }
}
