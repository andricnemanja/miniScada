namespace DynamicCacheManager
{
	public interface ISignalNameStringBuilder
	{
		string GenerateChannelName(int rtuId, string signalType, int signalId);
		string GenerateFlagChannelName(int rtuId, string signalType, int signalId);
		string GenerateFlagChannelName(int rtuId);
		string GenerateRemovedFlagChannelName(int rtuId);
		string GenerateSignaFlagListName(int signalId);
		string GenerateSignalKeyName(int signalId);
	}
}