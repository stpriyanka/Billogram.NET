using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Billogram.Net.Model.BillogramHelper
{
	public class BillogramItems
	{
		[JsonProperty("item_no")]
		public string ItemNo { get; set; }


		[JsonProperty("count")]
		public int Count { get; set; }


		[StringLength(30, ErrorMessage = "* 30 character in length.")]
		[JsonProperty("title")]
		public string Title { get; set; }


		[StringLength(200, ErrorMessage = "* 200 character in length.")]
		[JsonProperty("description")]
		public string Description { get; set; }


		[JsonProperty("unit")]
		public object Unit { get; set; }


		[JsonProperty("price")]
		public int Price { get; set; }


		[JsonProperty("vat")]
		public int Vat { get; set; }


		[JsonProperty("bookkeeping")]
		public object Bookkeeping { get; set; }


		[JsonProperty("discount")]
		public int Discount { get; set; }


		[JsonProperty("regional_sweden")]
		public object RegionalSweden { get; set; }
	}
}