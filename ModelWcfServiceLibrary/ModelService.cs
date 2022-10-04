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
{
    public class ModelService : IModelService
    {
        public RTURepository RTURepository { get; set; }

        public ModelService()
        {
            InitializeService();
        }

        public string GetData(int value)
        {            
            return string.Format("You entered: {0}", value);
        }

        public void InitializeService()
        {
            RTURepository = new RTURepository();
            RTURepository.Deserialize();
        }
    }
}
