namespace Billogram.Net.Interface.IBillogram
{
	public interface IBillogramCallbacks
	{
		string Custom { get; set; }

		string SignKey { get; set; }

		string Url { get; set; }
	}
}