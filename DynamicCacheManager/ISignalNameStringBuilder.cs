namespace DynamicCacheManager
{
	public interface ISignalNameStringBuilder
	{
		string GenerateChannelName(int rtuId, string signalType, int signalId);
		string GenerateFlagChannelName(int rtuId, string signalType, int signalId);
		string GenerateSignaFlagListName(int signalId);
		string GenerateSignalKeyName(int signalId);
	}
}