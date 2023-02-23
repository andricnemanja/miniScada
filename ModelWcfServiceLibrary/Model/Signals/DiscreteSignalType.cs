using System.Runtime.Serialization;

namespace ModelWcfServiceLibrary.Model.Signals
{
	[DataContract(Name = "DiscreteSignalType")]
	public enum DiscreteSignalType
	{
		[EnumMember]
		OneBit,
		[EnumMember]
		TwoBit
	}
}
