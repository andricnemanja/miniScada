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
	}
}
