using Newtonsoft.Json;

namespace Billogram.Net.Model.BilloCustomer
{
	public class CustomerPrimary
	{
		[JsonProperty("street_address")]
		public string CustomerPrimaryStreetAddress { get; set; }


		[JsonProperty("careof")]
		public string CustomerPrimaryCareOf { get; set; }


		[JsonProperty("use_careof_as_attention")]
		public bool CustomerPrimaryUseCareOfAsAttention { get; set; }


		[JsonProperty("customerPrimaryZipCode")]
		public string CustomerPrimaryZipCode { get; set; }


		[JsonProperty("zipcode")]
		public string CustomerPrimaryCity { get; set; }


		[JsonProperty("city")]
		public string CustomerPrimaryContactPhone { get; set; }


		[JsonProperty("country")]
		public string CustomerPrimaryCountry { get; set; }

	}
}