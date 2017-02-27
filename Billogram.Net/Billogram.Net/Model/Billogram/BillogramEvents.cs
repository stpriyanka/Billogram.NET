using System;
using Newtonsoft.Json;

namespace Billograms.Net.Model.Billogram
{
	public class BillogramEvents
	{
		[JsonProperty("created_at")]
		public DateTime? CreatedAt { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("data")]
		public object Data { get; set; }
	}
}