namespace Billogram.Net.Interface.ICustomer
{
	public interface ICustomerPrimary
	{
		string CustomerPrimaryCareOf { get; set; }

		string CustomerPrimaryCity { get; set; }

		string CustomerPrimaryCountry { get; set; }

		string CustomerPrimaryStreetAddress { get; set; }

		bool CustomerPrimaryUseCareOfAsAttention { get; set; }

		string CustomerPrimaryZipCode { get; set; }
	}
}