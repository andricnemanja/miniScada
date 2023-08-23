using ModelWcfServiceLibrary.Model.SignalMapping;
using System.Collections.Generic;
using System.Linq;

namespace ModelWcfServiceLibrary.EntityDataModel
{
	public partial class DbMapping
	{
		public ModelAnalogSignalMapping ToModelAnalogMapping()
		{
			return new ModelAnalogSignalMapping()
			{
				Id = this.mapping_id,
				Name = this.mapping_name,
				K = (double)this.K,
				N = (double)this.N
			};
		}

		public ModelDiscreteSignalMapping ToModelDiscreteMapping()
		{
			Dictionary<byte, string> newValueToStateDict = new Dictionary<byte, string>();

			List<DbDiscreteValueToState> valueToStates = this.DbDiscreteValueToStates.ToList();

			foreach (DbDiscreteValueToState valueToState in valueToStates)
			{
				newValueToStateDict.Add(valueToState.discrete_value, valueToState.discrete_state);
			}

			return new ModelDiscreteSignalMapping()
			{
				Id = this.mapping_id,
				Name = this.mapping_name,
				DiscreteValueToState = newValueToStateDict
			};

		}
	}
}
