using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Billogram.Net.Interface.ICustomer
{
	[Obsolete("Use instead 'CustomerStructure.cs'", true)]
	public interface ICustomer
	{
		IDictionary<string, JToken> CustomerAttributes { get; set; }
		int CustomerNo { get; set; }
	}
}