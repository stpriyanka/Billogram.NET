using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Billogram.Net.Interface.IBillogram
{
	[Obsolete("Use instead 'BillogramStructure.cs'", true)]
	public interface IBillogram
	{
		IDictionary<string, JToken> BillogramContent { get; set; }
		string ID { get; set; }
	}
}