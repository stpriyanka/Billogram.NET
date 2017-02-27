using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Billogram.Net.Model.BillogramHelperModel
{
	public class BillogramAdditionalInformation
	{
		[StringLength(30, ErrorMessage = "* 30 character in length.")]
		[JsonProperty("order_no")]
		public string OrderNo { get; set; }


		[JsonProperty("order_date")]
		public DateTime? OrderDate { get; set; }


		[StringLength(35, ErrorMessage = "* 35 character in length.")]
		[JsonProperty("our_reference")]
		public string OurReference { get; set; }


		[StringLength(35, ErrorMessage = "* 35 character in length.")]
		[JsonProperty("your_reference")]
		public string YourReference { get; set; }


		[JsonProperty("shipping_date")]
		public DateTime? ShippingDate { get; set; }


		[JsonProperty("delivery_date")]
		public DateTime? DeliveryDate { get; set; }


		[StringLength(30, ErrorMessage = "* 30 character in length.")]
		[JsonProperty("reference_number")]
		public string ReferenceNumber { get; set; }


		[StringLength(350, ErrorMessage = "* 350 character in length.")]
		[JsonProperty("message")]
		public string Message { get; set; }
	}
}