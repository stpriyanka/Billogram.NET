using System;

namespace Billogram.Net.Interface.IBillogram
{
	public interface IBillogramAdditionalInformation
	{
		DateTime? DeliveryDate { get; set; }

		string Message { get; set; }

		DateTime? OrderDate { get; set; }

		string OrderNo { get; set; }

		string OurReference { get; set; }

		string ReferenceNumber { get; set; }

		DateTime? ShippingDate { get; set; }

		string YourReference { get; set; }
	}
}