using System;
using Billogram.Net.Model.Customer;

namespace Billogram.Net.Interface.ICustomer
{
	public interface ICustomerStructure
	{
		string CustomerCompanyType { get; set; }

		CustomerContact CustomerContact { get; set; }

		DateTime? CustomerCreatedAt { get; set; }

		CustomerDelivery CustomerDelivery { get; set; }

		string CustomerName { get; set; }

		int CustomerNo { get; set; }

		string CustomerNotes { get; set; }

		string CustomerOrganizationNo { get; set; }

		CustomerPrimary CustomerPrimary { get; set; }

		DateTime? CustomerUpdatedAt { get; set; }

		string CustomerVatNo { get; set; }
	}
}