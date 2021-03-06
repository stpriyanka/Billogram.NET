﻿using Billogram.Net.Interface.IBillogram;
using Billogram.Net.Model.Customer;
using Newtonsoft.Json;

namespace Billogram.Net.Model.BillogramHelper
{
	public class BillogramHelper : IBillogramHelper
	{
		[JsonProperty("customer")]
		public CustomerStructure CustomerStructure { get; set; }

		[JsonProperty("item")]
		public BillogramItems Subscriptions { get; set; }
	}
}