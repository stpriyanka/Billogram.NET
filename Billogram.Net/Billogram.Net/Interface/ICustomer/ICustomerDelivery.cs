namespace Billogram.Net.Interface.ICustomer
{
	public interface ICustomerDelivery
	{
		string CustomerDeliveryCareOf { get; set; }

		string CustomerDeliveryCity { get; set; }

		string CustomerDeliveryCountry { get; set; }

		string CustomerDeliveryName { get; set; }

		string CustomerDeliveryStreetAddress { get; set; }

		string CustomerDeliveryZipCode { get; set; }
	}
}