using ModelWcfServiceLibrary.Model.RTU;
using ModelWcfServiceLibrary.Model.Signals;
using System.Collections.Generic;

namespace ModelWcfServiceLibrary.DatabaseRepository
{
	public interface IDatabaseRtuRepository
	{
		List<ModelRTU> RtuList { get; }

		IEnumerable<ModelAnalogSignal> GetAnalogSignalsForRtu(int id);
		IEnumerable<ModelDiscreteSignal> GetDiscreteSignalsForRtu(int id);
		ModelRTU GetRTUbyID(int id);
		IEnumerable<ModelRTUData> GetRTUsEssentialData();
		void MapFromDatabase();
	}
}