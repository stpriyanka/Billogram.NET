using System.Collections.Generic;
using System.Threading.Tasks;
using Billogram.Net.Model.BillogramHelper;
using Billogram.Net.Model.Customer;

namespace Billogram.Net.Utility
{
	public interface IBillogramUtility
	{
		Task<BillogramStructure> CreateBillogram(BillogramHelper billogramHelper);

		Task<CustomerStructure> CreateCustomer(CustomerStructure customer);

		Task<BillogramStructure> GetBillogramAsync(string billogramId);

		Task<List<BillogramStructure>> GetBillogramListByCustomerNo(int customerNo);

		Task<List<BillogramStructure>> GetBillogramsByState(string state);

		Task<CustomerStructure> GetCustomerInfo(int customerId);

		Task<dynamic> GetInvoicePdfFile(string billogramId);

		Task SendBillogram(string unattestedBillogramId);

		Task<CustomerStructure> UpdateCustomerAsync(CustomerStructure customer);
	}
}