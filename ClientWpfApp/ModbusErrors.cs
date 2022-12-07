using System.Collections.Generic;

namespace ClientWpfApp
{
	public static class ModbusErrors
	{
		public static Dictionary<int, string> errorCodeExplanation = new Dictionary<int, string>
		{
			{2, "Adresa nije dostupna"},
			{3, "Vrednost nije validna" },
			{4, "Greska na uredjaju" },
			{6, "Uredjaj trenutno zauzet" }
		};
	}
}
