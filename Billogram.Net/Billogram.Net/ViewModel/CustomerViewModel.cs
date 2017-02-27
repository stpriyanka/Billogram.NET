namespace Billogram.Net.ViewModel
{
	public class CustomerViewModel
	{
		//Default:automatic sequential numbers
		public int CustomerNo { get; set; }


		//required
		public string CustomerName { get; set; }


		public string CustomerOrganizationNo { get; set; }


		//required [Must be one of the following values. For more information read document https://billogram.com/api/documentation#customers]
		//Default value 'individual' type
		public string CompanyType { get; set; }


		public string CustomerVatNo { get; set; }


		//if missing on creation will duplicate the customer name
		public string CustomerContactName { get; set; }


		public string CustomerContactEmail { get; set; }


		public string CustomerContactPhone { get; set; }


		public string CustomerPrimaryStreetAddress { get; set; }


		public string CustomerPrimaryCareOf { get; set; }


		public string CustomerPrimaryUseCareOfAsAttention { get; set; }


		//required if street_address is specified. If null default set to 'CustomerPrimaryZipCode'
		public string CustomerPrimaryZipCode { get; set; }


		//required if street_address is specified
		public string CustomerPrimaryCity { get; set; }


		//required if street_address is specified
		//value should be always "SE"
		public string CustomerPrimaryCountry { get; set; }


		//required if street_address is specified
		public string CustomerDeliveryName { get; set; }


		public string CustomerDeliveryStreetAddress { get; set; }


		public string CustomerDeliveryCareOf { get; set; }


		//required if street_address is specified. If null default set to 'CustomerPrimaryZipCode'
		public string CustomerDeliveryZipCode { get; set; }


		//required if street_address is specified
		public string CustomerDeliveryCity { get; set; }


		//Country for the address. Must be a two-letter ISO 3166-1 alpha-2 format code if specified. Converted to lowercase in the Billogram system.
		//required if street_address is specified
		public string CustomerDeliveryCountry { get; set; }
	}
}