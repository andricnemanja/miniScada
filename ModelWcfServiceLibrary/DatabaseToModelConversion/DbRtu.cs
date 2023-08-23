using ModelWcfServiceLibrary.Model.RTU;
using ModelWcfServiceLibrary.Model.Signals;
using System.Linq;

namespace ModelWcfServiceLibrary.EntityDataModel
{

	public partial class DbRtu
	{
		/// <summary>
		/// Method that converts entity data to model service data.
		/// </summary>
		/// <returns>ModelRTU data.</returns>
		public ModelRTU ToModel()
		{
			return new ModelRTU
			{
				RTUData = new ModelRTUData()
				{
					ID = this.rtu_id,
					Name = this.rtu_name,
					IpAddress = this.ip_address,
					Port = this.rtu_port
				},
				AnalogSignals = this.DbSignals
						.Where(signal => signal.discrete_signal_type == null)
						.Select(signal => new ModelAnalogSignal
						{
							ID = signal.signal_id,
							Name = signal.signal_name,
							Address = signal.signal_address,
							AccessType = (ModelSignalAccessType)signal.access_type,
							Deadband = signal.deadband,
							StaleTime = signal.stale_time,
							MappingId = signal.mapping_id
						})
						.ToList(),
				DiscreteSignals = this.DbSignals
						.Where(signal => signal.discrete_signal_type != null)
						.Select(signal => new ModelDiscreteSignal
						{
							ID = signal.signal_id,
							Name = signal.signal_name,
							Address = signal.signal_address,
							AccessType = (ModelSignalAccessType)signal.access_type,
							Deadband = signal.deadband,
							StaleTime = signal.stale_time,
							SignalType = (ModelDiscreteSignalType)signal.discrete_signal_type,
							MappingId = signal.mapping_id
						})
						.ToList()
			};
		}
	}
}
