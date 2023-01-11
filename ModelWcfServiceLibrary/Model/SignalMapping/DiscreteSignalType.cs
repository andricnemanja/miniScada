using System.Runtime.Serialization;

namespace ModelWcfServiceLibrary.Model.SignalMapping
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
