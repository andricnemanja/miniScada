using ModbusServiceLibrary.Model.RTU;
using ModbusServiceLibrary.ServiceReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusServiceLibrary.Data
{
	public class RtuStaticData : IRtuStaticData
	{
		public List<RTU> RtuList { get; set; }
		private IModelServiceReader modelServiceReader;

		public RtuStaticData(IModelServiceReader modelServiceReader)
		{
			this.modelServiceReader = modelServiceReader;
		}

		public void InitializeData()
		{
			RtuList = modelServiceReader.ReadAllRTUs();
		}
	}
}
