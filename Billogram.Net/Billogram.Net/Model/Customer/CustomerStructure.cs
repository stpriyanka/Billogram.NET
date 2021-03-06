using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Billogram.Net.Interface.ICustomer;

namespace Billogram.Net.Model.Customer
{
	public class CustomerStructure : ICustomerStructure
	{
		[JsonProperty("customer_no")]
		public int CustomerNo { get; set; }

		[Required]
		[JsonProperty("name")]
		public string CustomerName { get; set; }


		[JsonProperty("notes")]
		public string CustomerNotes { get; set; }


		[JsonProperty("org_no")]
		public string CustomerOrganizationNo { get; set; }


		[JsonProperty("vat_no")]
		public string CustomerVatNo { get; set; }


		[JsonProperty("contact")]
		public CustomerContact CustomerContact { get; set; }


		[JsonProperty("address")]
		public CustomerPrimary CustomerPrimary { get; set; }


		[JsonProperty("delivery_address")]
		public CustomerDelivery CustomerDelivery { get; set; }


		[JsonProperty("created_at")]
		public DateTime? CustomerCreatedAt { get; set; }


		[JsonProperty("updated_at")]
		public DateTime? CustomerUpdatedAt { get; set; }


		[JsonProperty("company_type")]
		public string CustomerCompanyType { get; set; }

	}
}