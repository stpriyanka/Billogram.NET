using System;
using System.Collections.Generic;
using System.Configuration;
using Billograms.Net.Model.Billogram;
using Billogram.Net.Utility;
using Billograms.Net.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BillogramsTest
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
			var billogramUtility = new BillogramUtility(_clientSecretUser, _clientSecretKey);
			Billograms.Net.Model.Billogram.Billogram result = billogramUtility.GetBillogramAsync(BillogramId).Result;
			Console.WriteLine(result.ID);
		}


		[TestMethod]
		public void GetBillogramsByState_Test()
		{
			var billogramUtility = new BillogramUtility(_clientSecretUser, _clientSecretKey);
			List<Billograms.Net.Model.Billogram.Billogram> result = billogramUtility.GetBillogramsByState("unattested").Result;
			Console.WriteLine(result.Count);
		}


		[TestMethod]
		public void GetBillogramsByCustomerNo_Test()
		{
			var billogramUtility = new BillogramUtility(_clientSecretUser, _clientSecretKey);
			List<Billograms.Net.Model.Billogram.Billogram> result = billogramUtility.GetBillogramListByCustomerNo(CustomerNo).Result;

			Console.WriteLine(result.Count);
		}


		//----------------------------------Finish tested the functions below----------------------





		[TestMethod]
		public void CreateBillogram_Test()
		{
			var billogramUtility = new BillogramUtility(_clientSecretUser, _clientSecretKey);

			var result = billogramUtility.CreateBillogram(CustomerNo, SubscriptionId).Result;
			//Assert.IsNotNull(result.ID);

		}


		[TestMethod]
		public void CreateCustomer_Test()
		{
			var model = new CustomerViewModel()
			{
				CustomerNo = 810,
				CustomerName = "Wftest",
				CompanyType = "individual",
				CustomerOrganizationNo = "",
				CustomerVatNo = "",

				CustomerContactName = "Wftest Customer",
				CustomerContactEmail = "priyanka@worldfavor.com",
				CustomerContactPhone = "0765707970",

				CustomerPrimaryStreetAddress = "Regeringsgatan 65",
				CustomerPrimaryZipCode = "16962",
				CustomerPrimaryCity = "Stockholm",
				CustomerPrimaryCountry = "bd",
				CustomerPrimaryCareOf = "Wftest",
				CustomerPrimaryUseCareOfAsAttention = "Wftest",

				CustomerDeliveryName = "Wftest Customer",
				CustomerDeliveryCareOf = "Wftest",
				CustomerDeliveryZipCode = "16962",
				CustomerDeliveryStreetAddress = "Regeringsgatan 65",
				CustomerDeliveryCity = "Stockholm",
				CustomerDeliveryCountry = "SE",
			};
			var result = _billogramUtility.CreateCustomer(model).Result;
			Assert.IsNotNull(result.CustomerNo);

		}



		[TestMethod]
		public void UpdateCustomer_Test()
		{
			//zipcode required if streeaddress
			var model = new CustomerViewModel()
			{
				CustomerNo = 810,
				CustomerContactName = "Wftest11",
			};
			var result = _billogramUtility.UpdateCustomerAsync(model).Result;
			//	Assert.IsNotNull(result.CustomerNo);

		}


		[TestMethod]
		public void GetBillogramPdf_Test()
		{
			string billogramId = "JJsMyRW";

			var result = _billogramUtility.GetInvoicePdfFile(billogramId).Result;
			//Assert.IsNotNull(result);
		}
	}
}