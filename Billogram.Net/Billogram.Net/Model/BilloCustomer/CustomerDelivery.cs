using Newtonsoft.Json;

namespace Billogram.Net.Model.BilloCustomer
{
	public class CustomerDelivery
	{
		[JsonProperty("name")]
		public string CustomerDeliveryName { get; set; }


		[JsonProperty("street_address")]
		public string CustomerDeliveryStreetAddress { get; set; }


		[JsonProperty("careof")]
		public string CustomerDeliveryCareOf { get; set; }


		[JsonProperty("zipcode")]
		public string CustomerDeliveryZipCode { get; set; }


		[JsonProperty("city")]
		public string CustomerDeliveryCity { get; set; }


		[JsonProperty("country")]
		public string CustomerDeliveryCountry { get; set; }
	}
}