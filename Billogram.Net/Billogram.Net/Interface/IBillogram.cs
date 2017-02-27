using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Billograms.Net.Interface
{
	public interface IBillogram
	{
		IDictionary<string, JToken> BillogramContent { get; set; }
		string ID { get; set; }

	}
}