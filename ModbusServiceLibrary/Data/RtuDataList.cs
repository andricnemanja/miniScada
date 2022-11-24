using ModbusServiceLibrary.Model.RTU;
using ModbusServiceLibrary.ServiceReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusServiceLibrary.Data
{
	public class RtuDataList : IRtuDataList
	{
		public List<RTU> RtuList { get; private set; }
		private readonly IModelServiceReader modelServiceReader;

		public RtuDataList(IModelServiceReader modelServiceReader)
		{
			this.modelServiceReader = modelServiceReader;
		}

		public void InitializeData()
		{
			RtuList = modelServiceReader.ReadAllRTUs();
		}
	}
}
