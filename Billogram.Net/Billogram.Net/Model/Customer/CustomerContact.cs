using Billogram.Net.Interface.ICustomer;
using Newtonsoft.Json;

namespace Billogram.Net.Model.Customer
{
	public class CustomerContact : ICustomerContact
	{
		[JsonProperty("name")]
		public string CustomerContactName { get; set; }


		[JsonProperty("email")]
		public string CustomerContactEmail { get; set; }


		[JsonProperty("phone")]
		public string CustomerContactPhone { get; set; }
	}
}