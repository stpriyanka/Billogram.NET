using System;

namespace Billogram.Net.Interface.IBillogram
{
	public interface IBillogramEvents
	{
		DateTime? CreatedAt { get; set; }

		object Data { get; set; }

		string Type { get; set; }
	}
}