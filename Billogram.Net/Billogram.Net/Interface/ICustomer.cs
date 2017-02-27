using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Billograms.Net.Interface
{
	public interface ICustomer
	{
		IDictionary<string, JToken> CustomerAttributes { get; set; }
		int CustomerNo { get; set; }
	}
}