using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ModelWcfServiceLibrary
{
    public enum FaultCodes
    {
        IdDoesNotExist = 0
    }
    [DataContract]
    public class ModelServiceException
    {
        [DataMember]
        public FaultCodes FaultCode { get; set; }


        public ModelServiceException(FaultCodes faultCode)
        {
            FaultCode = faultCode;           
        }
    }
}
