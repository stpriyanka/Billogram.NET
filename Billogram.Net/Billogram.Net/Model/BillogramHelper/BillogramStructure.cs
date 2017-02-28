using System;
using System.Collections.Generic;
using Billogram.Net.Model.Customer;
using Newtonsoft.Json;

namespace Billogram.Net.Model.BillogramHelper
{
	public class BillogramStructure
	{
		[JsonProperty("id")]
		public string ID { get; set; }


		[JsonProperty("invoice_no")]
		public int? InvoiceNo { get; set; }


		[JsonProperty("ocr_number")]
		public string OcrNumber { get; set; }


		[JsonProperty("customer")]
		public CustomerStructure CustomerStructure { get; set; }


		[JsonProperty("items")]
		public List<BillogramItems> Items { get; set; }


		[JsonProperty("invoice_date")]
		public DateTime? InvoiceDate { get; set; }


		[JsonProperty("due_date")]
		public DateTime? DueDate { get; set; }


		[JsonProperty("due_days")]
		public int DueDays { get; set; }


		[JsonProperty("invoice_fee")]
		public int InvoiceFee { get; set; }


		[JsonProperty("invoice_fee_vat")]
		public int InvoiceFeeVat { get; set; }


		[JsonProperty("reminder_fee")]
		public int ReminderFee { get; set; }


		[JsonProperty("interest_rate")]
		public int InterestRate { get; set; }


		[JsonProperty("interest_fee")]
		public int InterestFee { get; set; }


		[JsonProperty("currency")]
		public string Currency { get; set; }


		[JsonProperty("info")]
		public BillogramAdditionalInformation Info { get; set; }


		[JsonProperty("regional_sweden")]
		public object RegionalSweden { get; set; }


		[JsonProperty("delivery_method")]
		public string DeliveryMethod { get; set; }


		[JsonProperty("state")]
		public string State { get; set; }


		[JsonProperty("url")]
		public string Url { get; set; }


		[JsonProperty("flags")]
		public object Flags { get; set; }


		[JsonProperty("events")]
		public List<BillogramEvents> Events { get; set; }


		[JsonProperty("remaining_sum")]
		public int RemainingSum { get; set; }


		[JsonProperty("total_sum")]
		public int Totalsum { get; set; }


		[JsonProperty("automatic_reminders_settings")]
		public object[] AutomaticRemindersSettings { get; set; }


		[JsonProperty("automatic_reminders")]
		public bool AutomaticReminders { get; set; }


		[JsonProperty("reminder_count")]
		public int ReminderCount { get; set; }


		[JsonProperty("created_at")]
		public DateTime? CreatedAt { get; set; }


		[JsonProperty("attested_at")]
		public DateTime? AttestedAt { get; set; }


		[JsonProperty("updated_at")]
		public DateTime? UpdatedAt { get; set; }


		[JsonProperty("callbacks")]
		public BillogramCallbacks Callbacks { get; set; }


		[JsonProperty("detailed_sums")]
		public object DetailedSums { get; set; }


		[JsonProperty("attachment")]
		public string Attachment { get; set; }


		[JsonProperty("automatic_collection")]
		public object AutomaticCollection { get; set; }
	}
}