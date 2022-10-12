using ModelWcfServiceLibrary.Model.RTU;
using ModelWcfServiceLibrary.Model.Signals;
using ModelWcfServiceLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ModelWcfServiceLibrary
{       //fali service contract
    public class ModelService : IModelService
    {
        public RTURepository RTURepository { get; set; }

        public ModelService()
        {
            InitializeService();
        }

        public List<RTU> GetStaticData()
        {            
            return RTURepository.RtuList;
        }

        public void InitializeService()
        {
            RTURepository = new RTURepository();
            RTURepository.Deserialize();
        }

        public RTU GetRTU(int id)
        {
            return  RTURepository.GetRTUByID(id);
        }
    }
}
