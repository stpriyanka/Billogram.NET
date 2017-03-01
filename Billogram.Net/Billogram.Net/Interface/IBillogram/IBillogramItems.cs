namespace Billogram.Net.Interface.IBillogram
{
	public interface IBillogramItems
	{
		object Bookkeeping { get; set; }

		int Count { get; set; }

		string Description { get; set; }

		int Discount { get; set; }

		string ItemNo { get; set; }

		int Price { get; set; }

		object RegionalSweden { get; set; }

		string Title { get; set; }

		object Unit { get; set; }

		int Vat { get; set; }
	}
}