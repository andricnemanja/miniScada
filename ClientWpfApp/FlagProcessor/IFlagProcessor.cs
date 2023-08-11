using ClientWpfApp.Model.Flags;

namespace ClientWpfApp.FlagProcessor
{
	public interface IFlagProcessor
	{
		void ProcessFlag(Flag flag, int rtuId);
	}
}
