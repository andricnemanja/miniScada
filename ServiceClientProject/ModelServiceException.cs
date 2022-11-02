using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClientProject
{
    public enum FaultCodes
    {
        IdDoesNotExist = 0
    }

    public class ModelServiceException
    {
        public FaultCodes FaultCode { get; set; }

        public ModelServiceException(FaultCodes faultCode)
        {
            FaultCode = faultCode;
        }
        
    }
}
