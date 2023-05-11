using System.Runtime.Serialization;

namespace ModelWcfServiceLibrary.Model.Signals
{
	[DataContract(Name = "DiscreteSignalType")]
	public enum ModelDiscreteSignalType
	{
		[EnumMember]
		OneBit,
		[EnumMember]
		TwoBit
	}
}
