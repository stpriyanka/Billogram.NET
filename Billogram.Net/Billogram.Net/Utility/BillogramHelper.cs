using Billogram.Net.Model.BilloCustomer;
using Billogram.Net.Model.BillogramHelperModel;
using Newtonsoft.Json;

namespace Billogram.Net.Utility
{
	public class BillogramHelper
	{
		[JsonProperty("customer")]
		public CustomerStructure CustomerStructure { get; set; }

		[JsonProperty("item")]
		public BillogramItems Subscriptions { get; set; }
	}
}