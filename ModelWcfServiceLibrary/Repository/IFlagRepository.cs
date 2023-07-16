using System.Collections.Generic;
using ModelWcfServiceLibrary.Model.Flags;

namespace ModelWcfServiceLibrary.Repository
{
	public interface IFlagRepository
	{
		List<Flag> FlagList { get; }

		void Deserialize();
		void Serialize();
	}
}