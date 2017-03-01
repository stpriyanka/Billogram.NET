using Billogram.Net.Interface.IBillogram;
using Newtonsoft.Json;

namespace Billogram.Net.Model.BillogramHelper
{
	public class BillogramCallbacks : IBillogramCallbacks
	{
		[JsonProperty("url")]
		public string Url { get; set; }


		[JsonProperty("custom")]
		public string Custom { get; set; }


		[JsonProperty("sign_key")]
		public string SignKey { get; set; }
	}
}