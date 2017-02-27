using Newtonsoft.Json;

namespace Billograms.Net.Model.Customer
{
	public class CustomerContact
	{
		[JsonProperty("name")]
		public string CustomerContactName { get; set; }


		[JsonProperty("email")]
		public string CustomerContactEmail { get; set; }


		[JsonProperty("phone")]
		public string CustomerContactPhone { get; set; }
	}
}