using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using Billogram.Net.Model.BilloCustomer;
using Billogram.Net.Model.BillogramHelperModel;
using Billogram.Net.Utility;
using Billogram.Net.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Billogram.Net.Test
{
	[TestClass]
	public class BillogramUtilityTest
	{
		private string _clientSecretUser;
		private string _clientSecretKey;
		private BillogramUtility _billogramUtility;

		const string BillogramId = "PyZdJ7u";
		private const int CustomerNo = 1;
		private const int SubscriptionId = 2;


		[TestInitialize]
		public void Initialize()
		{
			var appSettings = ConfigurationManager.AppSettings;
			_clientSecretUser = appSettings["Billogram.AuthUser"];
			_clientSecretKey = appSettings["Billogram.AuthKey"];
			_billogramUtility = new BillogramUtility(_clientSecretUser, _clientSecretKey);
		}


		[TestMethod]
		public void GetBillogramAsync_Test()
		{
			BillogramStructure result = _billogramUtility.GetBillogramAsync(BillogramId).Result;
			Console.WriteLine(result.ID);
		}


		[TestMethod]
		public void GetBillogramsByState_Test()
		{
			List<BillogramStructure> result = _billogramUtility.GetBillogramsByState("unattested").Result;
			Console.WriteLine(result.Count);
		}


		[TestMethod]
		public void GetBillogramsByCustomerNo_Test()
		{
			List<BillogramStructure> result = _billogramUtility.GetBillogramListByCustomerNo(CustomerNo).Result;

			Console.WriteLine(result.Count);
		}



		[TestMethod]
		public void CreateBillogram_Test()
		{
			BillogramHelper billogramHelper = new BillogramHelper()
			{
				CustomerStructure = new CustomerStructure()
				{
					CustomerNo = CustomerNo
				},
				Subscriptions = new BillogramItems()
				{
					ItemNo = SubscriptionId.ToString(),
					Discount = 0,
					Count = 2
				}
			};

			var result = _billogramUtility.CreateBillogram(billogramHelper).Result;

			Console.WriteLine(result.ID);
			Assert.IsNotNull(result.ID);

		}


		[TestMethod]
		public async Task SendBillogram_toEmail()
		{
			await _billogramUtility.SendBillogram("PAsE6WY");

		}


		[TestMethod]
		public void GetCustomer_test()
		{
			var cusData = _billogramUtility.GetCustomerInfo(1).Result;
			Assert.IsNotNull(cusData);
		}



		[TestMethod]
		public void CreateCustomer_Test()
		{
			var model = new CustomerStructure()
			{
				CustomerNo = 813,
				CustomerName = "Wftest",
				CustomerCompanyType = "individual",
				CustomerOrganizationNo = "",
				CustomerVatNo = "",


				CustomerContact = new CustomerContact()
				{
					CustomerContactName = "Wftest Customer",
					CustomerContactEmail = "priyanka@worldfavor.com",
					CustomerContactPhone = "0765707970",

				},
				CustomerDelivery = new CustomerDelivery()
				{
					CustomerDeliveryName = "Wftest Customer",
					CustomerDeliveryCareOf = "Wftest",
					CustomerDeliveryZipCode = "16962",
					CustomerDeliveryStreetAddress = "Regeringsgatan 65",
					CustomerDeliveryCity = "Stockholm",
					CustomerDeliveryCountry = "SE",

				},
				CustomerPrimary = new CustomerPrimary()
				{
					CustomerPrimaryStreetAddress = "Regeringsgatan 65",
					CustomerPrimaryZipCode = "16962",
					CustomerPrimaryCity = "Stockholm",
					CustomerPrimaryCountry = "bd",
					CustomerPrimaryCareOf = "Wftest",
					CustomerPrimaryUseCareOfAsAttention = true,

				}
			};
			CustomerStructure result = _billogramUtility.CreateCustomer(model).Result;
			Assert.IsNotNull(result.CustomerNo);

		}


		//----------------------------------Finish tested the functions below----------------------


		[TestMethod]
		public void GetBillogramPdf_Test()
		{
			string billogramId = "JJsMyRW";

			var result = _billogramUtility.GetInvoicePdfFile(billogramId).Result;
			//Assert.IsNotNull(result);
		}


		[TestMethod]
		public void UpdateCustomer_Test()
		{
			//zipcode required if streeaddress
			var model = new CustomerStructure()
			{
				CustomerNo = 1,
				CustomerContact = new CustomerContact()
				{
					CustomerContactName = "Wftest144"
				}
			};
			var result = _billogramUtility.UpdateCustomerAsync(model).Result;
			//	Assert.IsNotNull(result.CustomerNo);

		}


	}
}