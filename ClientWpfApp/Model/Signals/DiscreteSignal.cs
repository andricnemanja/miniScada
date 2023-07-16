using System.Collections.ObjectModel;
using ClientWpfApp.Model.Flags;

namespace ClientWpfApp.Model.Signals
{
	public class DiscreteSignal
	{
		/// <summary>
		/// Unique identification number for digital signal
		/// </summary>
		public int ID { get; set; }
		/// <summary>
		/// Digital signal address
		/// </summary>
		public int Address { get; set; }
		/// <summary>
		/// Name of the discrete signal
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Indicates whether the signal is read only or read-write
		/// </summary>
		public SignalAccessType AccessType { get; set; }
		public ObservableCollection<Flag> SignalFlags { get; set; } = new ObservableCollection<Flag>();
	}
}
