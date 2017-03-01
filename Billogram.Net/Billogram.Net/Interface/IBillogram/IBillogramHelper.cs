using Billogram.Net.Model.BillogramHelper;
using Billogram.Net.Model.Customer;

namespace Billogram.Net.Interface.IBillogram
{
	public interface IBillogramHelper
	{
		CustomerStructure CustomerStructure { get; set; }

		BillogramItems Subscriptions { get; set; }
	}
}