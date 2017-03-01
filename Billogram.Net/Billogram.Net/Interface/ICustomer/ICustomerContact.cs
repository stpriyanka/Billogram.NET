namespace Billogram.Net.Interface.ICustomer
{
	public interface ICustomerContact
	{
		string CustomerContactEmail { get; set; }

		string CustomerContactName { get; set; }

		string CustomerContactPhone { get; set; }
	}
}