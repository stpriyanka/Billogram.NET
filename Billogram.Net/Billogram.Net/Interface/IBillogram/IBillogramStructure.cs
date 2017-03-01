using System;
using System.Collections.Generic;
using Billogram.Net.Model.BillogramHelper;
using Billogram.Net.Model.Customer;

namespace Billogram.Net.Interface.IBillogram
{
	public interface IBillogramStructure
	{
		string Attachment { get; set; }

		DateTime? AttestedAt { get; set; }

		object AutomaticCollection { get; set; }

		bool AutomaticReminders { get; set; }

		object[] AutomaticRemindersSettings { get; set; }

		BillogramCallbacks Callbacks { get; set; }

		DateTime? CreatedAt { get; set; }

		string Currency { get; set; }

		CustomerStructure CustomerStructure { get; set; }

		string DeliveryMethod { get; set; }

		object DetailedSums { get; set; }

		DateTime? DueDate { get; set; }

		int DueDays { get; set; }

		List<BillogramEvents> Events { get; set; }

		object Flags { get; set; }

		string ID { get; set; }

		BillogramAdditionalInformation Info { get; set; }

		int InterestFee { get; set; }

		int InterestRate { get; set; }

		DateTime? InvoiceDate { get; set; }

		int InvoiceFee { get; set; }

		int InvoiceFeeVat { get; set; }

		int? InvoiceNo { get; set; }

		List<BillogramItems> Items { get; set; }

		string OcrNumber { get; set; }

		object RegionalSweden { get; set; }

		int RemainingSum { get; set; }

		int ReminderCount { get; set; }

		int ReminderFee { get; set; }

		string State { get; set; }

		int Totalsum { get; set; }

		DateTime? UpdatedAt { get; set; }

		string Url { get; set; }
	}
}