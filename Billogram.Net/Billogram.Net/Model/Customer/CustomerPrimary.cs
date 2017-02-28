using Billogram.Net.Utility;
using Newtonsoft.Json;

namespace Billogram.Net.Model.Customer
{
	public class CustomerPrimary
	{
		[Check(CheckLength = 1)]
		[JsonProperty("street_address")]
		public string CustomerPrimaryStreetAddress { get; set; }


		[JsonProperty("careof")]
		public string CustomerPrimaryCareOf { get; set; }


		[JsonProperty("use_careof_as_attention")]
		public bool CustomerPrimaryUseCareOfAsAttention { get; set; }


		[JsonProperty("zipcode")]
		public string CustomerPrimaryZipCode { get; set; }


		[JsonProperty("city")]
		public string CustomerPrimaryCity { get; set; }


		[JsonProperty("country")]
		public string CustomerPrimaryCountry { get; set; }

	}
}