using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Billogram.Net.Model.BilloCustomer;
using Billogram.Net.Model.BillogramHelperModel;
using Billogram.Net.ViewModel;
using Newtonsoft.Json.Linq;

namespace Billogram.Net.Utility
{
	public class BillogramUtility
	{
		public string ClientSecretUser;
		public string ClientSecretKey;
		private readonly HttpClient _client;
		private readonly string _baseUrl;

		private BillogramStructure _billogram;

		private CustomerStructure _customer;
		/// <summary>
		/// Use this constructor if production environment should be run 
		/// OR use another constructor if the environment should be passed by parameter
		/// </summary>
		/// <param name="authUser"></param>
		/// <param name="authKey"></param>
		public BillogramUtility(string authUser, string authKey)
		{
			ClientSecretUser = authUser;
			ClientSecretKey = authKey;

			_client = new HttpClient();
			byte[] byteArray = Encoding.ASCII.GetBytes(authUser + ":" + authKey);
			_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
				Convert.ToBase64String(byteArray));
			_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			_baseUrl = "https://sandbox.billogram.com/api/v2/";
		}



		/// <summary>
		/// Pass base url "https://sandbox.billogram.com/api/v2/" for testing
		/// Or "https://billogram.com/api/v2" for production use
		/// </summary>
		/// <param name="authUser"></param>
		/// <param name="authKey"></param>
		/// <param name="baseUrl"></param>
		public BillogramUtility(string authUser, string authKey, string baseUrl)
		{
			ClientSecretUser = authUser;
			ClientSecretKey = authKey;
			_baseUrl = baseUrl;

			_client = new HttpClient();
			byte[] byteArray = Encoding.ASCII.GetBytes(authUser + ":" + authKey);
			_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
				Convert.ToBase64String(byteArray));
			_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

		}




		/// <summary>
		/// Get a single billogram
		/// </summary>
		/// <param name="billogramId"></param>
		/// <returns></returns>
		public async Task<BillogramStructure> GetBillogramAsync(string billogramId)
		{
			try
			{
				HttpResponseMessage response = await _client.GetAsync(_baseUrl + "billogram/" + billogramId);

				if (!response.IsSuccessStatusCode)
					return _billogram;
				response.EnsureSuccessStatusCode();
				string responseBody = await response.Content.ReadAsStringAsync();

				JObject jObject = JObject.Parse(responseBody);
				JToken billogramData = jObject["data"];
				_billogram = billogramData.ToObject<BillogramStructure>();
			}
			catch (Exception e)
			{
				Exception catchedException = e;
			}
			return _billogram;
		}



		/// <summary>
		/// Get billogram by different state
		/// </summary>
		/// <param name="state"></param>
		/// <returns></returns>
		public async Task<List<BillogramStructure>> GetBillogramsByState(string state)
		{
			var billograms = new List<BillogramStructure>();

			var query = HttpUtility.ParseQueryString(string.Empty);
			query["page"] = "1";
			query["page_size"] = "50";
			query["filter_type"] = "field";
			query["filter_field"] = "state";
			query["filter_value"] = state;
			string queryString = query.ToString();

			HttpResponseMessage response = await _client.GetAsync(_baseUrl + "billogram/" + "?" + queryString);
			response.EnsureSuccessStatusCode();
			var responseBody = await response.Content.ReadAsStringAsync();

			var obj = JObject.Parse(responseBody);

			foreach (var jToken in obj["data"])
			{
				JObject element = (JObject)jToken;

				BillogramStructure output = element.ToObject<BillogramStructure>();
				billograms.Add(output);
			}

			return billograms;
		}



		/// <summary>
		/// Get billogram list by customer no.
		/// </summary>
		/// <param name="customerNo">The customer no.</param>
		/// <returns>Task&lt;List&lt;Billogram&gt;&gt;.</returns>
		public async Task<List<BillogramStructure>> GetBillogramListByCustomerNo(int customerNo)
		{
			Exception catchedException = null;
			var billograms = new List<BillogramStructure>();

			var query = HttpUtility.ParseQueryString(string.Empty);
			query["page"] = "1";
			query["page_size"] = "50";
			query["filter_type"] = "field";
			query["filter_field"] = "customer:customer_no";
			query["filter_value"] = customerNo.ToString();
			string queryString = query.ToString();

			try
			{
				HttpResponseMessage response = await _client.GetAsync(_baseUrl + "billogram/" + "?" + queryString);
				response.EnsureSuccessStatusCode();

				var responseBody = await response.Content.ReadAsStringAsync();
				JObject jObject = JObject.Parse(responseBody);

				foreach (var jToken in jObject["data"])
				{
					JObject element = (JObject)jToken;
					BillogramStructure output = element.ToObject<BillogramStructure>();
					billograms.Add(output);
				}
			}
			catch (Exception e)
			{
				catchedException = e;
			}

			if (catchedException == null)
				return billograms;
			throw catchedException;
		}



		/// <summary>
		/// Get specific invoice as a PDF file content.
		/// </summary>
		/// <param name="billogramId">The billogram identifier.</param>
		/// <returns>Task&lt;dynamic&gt;.</returns>
		public async Task<dynamic> GetInvoicePdfFile(string billogramId)
		{
			HttpResponseMessage response = await _client.GetAsync(_baseUrl + "billogram/" + billogramId + ".pdf");

			dynamic value = null;
			if (response.IsSuccessStatusCode)
			{
				response.EnsureSuccessStatusCode();

				var responseBody = await response.Content.ReadAsStringAsync();
				JObject jo = JObject.Parse(responseBody);

				IDictionary<string, JToken> jObject = (JObject)jo["data"];

				Dictionary<string, dynamic> dictionary = jObject.ToDictionary(pair => pair.Key, pair => (dynamic)pair.Value);

				bool getValue = dictionary.TryGetValue("content", out value);
				if (getValue == false)
					return null;
			}
			else
			{
				Console.WriteLine("Unable to load invoice pdf");
			}
			return value;
		}



		/// <summary>
		/// Create billogram
		/// </summary>
		/// <param name="billogramHelper"></param>
		/// <returns>BillogramStructure instance</returns>
		public async Task<BillogramStructure> CreateBillogram(BillogramHelper billogramHelper)
		{
			Exception catchedException = null;
			var data = new
			{
				customer = new
				{
					customer_no = billogramHelper.CustomerStructure.CustomerNo
				},
				items = new[]
				{
					 new {
						 count = billogramHelper.Subscriptions.Count,
						 discount = billogramHelper.Subscriptions.Discount,
						 item_no = billogramHelper.Subscriptions.ItemNo
					 }
				}
			};
			try
			{
				HttpResponseMessage response = await _client.PostAsJsonAsync(_baseUrl + "billogram/", data);
				if (!response.IsSuccessStatusCode)
					return null;
				response.EnsureSuccessStatusCode();
				var responseBody = await response.Content.ReadAsStringAsync();

				JObject jObject = JObject.Parse(responseBody);
				JToken billogramData = jObject["data"];

				_billogram = billogramData.ToObject<BillogramStructure>();
			}
			catch (Exception e)
			{
				catchedException = e;
			}

			if (catchedException == null)
				return _billogram;
			throw catchedException;
		}



		/// <summary>
		/// Send the billogram to responsible customer's email.
		/// </summary>
		/// <param name="unattestedBillogramId">The unattested billogram identifier.</param>
		/// <returns>Task&lt;Billogram&gt;.</returns>
		public async Task SendBillogram(string unattestedBillogramId)
		{
			BillogramStructure billogramInfo = await GetBillogramAsync(unattestedBillogramId);

			dynamic value = billogramInfo.State;

			if (value == "Unattested")
			{
				var data = new
				{
					method = "Email"
				};

				var queryString = unattestedBillogramId + "/command/send/";

				try
				{
					HttpResponseMessage response = await _client.PostAsJsonAsync(_baseUrl + "billogram/" + queryString, data);
					if (response.IsSuccessStatusCode)
					{
						response.EnsureSuccessStatusCode();
					}
				}
				catch (Exception e)
				{
					Console.WriteLine("Unable to send billogram");
				}
			}
		}



		/// <summary>
		/// Get an existing customer 
		/// </summary>
		/// <param name="customerId"></param>
		/// <returns></returns>
		public async Task<CustomerStructure> GetCustomerInfo(int customerId)
		{
			HttpResponseMessage response = await _client.GetAsync(_baseUrl + "customer/" + customerId);

			if (!response.IsSuccessStatusCode)
				return _customer;
			response.EnsureSuccessStatusCode();
			string responseBody = await response.Content.ReadAsStringAsync();
			JObject jObject = JObject.Parse(responseBody);
			JToken customerData = jObject["data"];

			_customer = customerData.ToObject<CustomerStructure>();

			return _customer;
		}



		/// <summary>
		/// Create a customer for specific company
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<CustomerStructure> CreateCustomer(CustomerStructure customer)
		{
			var data = new
			{
				customer_no = customer.CustomerNo,

				name = customer.CustomerName ?? string.Empty,
				company_type = customer.CustomerCompanyType ?? "individual",
				org_no = customer.CustomerOrganizationNo ?? string.Empty,
				contact = new
				{
					name = customer.CustomerContact.CustomerContactName ?? string.Empty,
					email = customer.CustomerContact.CustomerContactEmail ?? string.Empty,
					phone = customer.CustomerContact.CustomerContactPhone ?? string.Empty
				},
				address = new
				{
					street_address = customer.CustomerPrimary.CustomerPrimaryStreetAddress ?? string.Empty,
					zipcode = customer.CustomerPrimary.CustomerPrimaryZipCode ?? customer.CustomerDelivery.CustomerDeliveryZipCode,
					city = customer.CustomerPrimary.CustomerPrimaryCity ?? string.Empty,
					country = customer.CustomerPrimary.CustomerPrimaryCountry ?? string.Empty
				},
				delivery_address = new
				{
					name = customer.CustomerDelivery.CustomerDeliveryName ?? string.Empty,
					street_address = customer.CustomerDelivery.CustomerDeliveryStreetAddress ?? string.Empty,
					careof = customer.CustomerDelivery.CustomerDeliveryCareOf ?? string.Empty,
					zipcode = customer.CustomerDelivery.CustomerDeliveryZipCode ?? customer.CustomerPrimary.CustomerPrimaryZipCode,
					city = customer.CustomerDelivery.CustomerDeliveryCity ?? string.Empty,
					country = customer.CustomerDelivery.CustomerDeliveryCountry ?? string.Empty
				}
			};

			HttpResponseMessage response = await _client.PostAsJsonAsync(_baseUrl + "customer/", data);
			response.EnsureSuccessStatusCode();
			var responseBody = await response.Content.ReadAsStringAsync();

			JObject json = JObject.Parse(responseBody);
			JToken customerData = json["data"];
			_customer = customerData.ToObject<CustomerStructure>();
			return _customer;
		}


		/// <summary>
		/// Update existing customer information
		/// </summary>
		/// <param name="customer"></param>
		/// <returns></returns>
		public async Task<CustomerStructure> UpdateCustomerAsync(CustomerStructure customer)
		{
			//try
			//{
			var data = new
			{
				customer_no = customer.CustomerNo,

				name = customer.CustomerName ?? string.Empty,
				company_type = customer.CustomerCompanyType ?? "individual",
				org_no = customer.CustomerOrganizationNo ?? string.Empty,
				//contact = new
				//{
				//	name = customer.CustomerContact.CustomerContactName ?? string.Empty,
				//	email = customer.CustomerContact.CustomerContactEmail ?? string.Empty,
				//	phone = customer.CustomerContact.CustomerContactPhone ?? string.Empty
				//},
				//address = new
				//{
				//	street_address = customer.CustomerPrimary.CustomerPrimaryStreetAddress ?? string.Empty,
				//	zipcode = customer.CustomerPrimary.CustomerPrimaryZipCode ?? customer.CustomerDelivery.CustomerDeliveryZipCode,
				//	city = customer.CustomerPrimary.CustomerPrimaryCity ?? string.Empty,
				//	country = customer.CustomerPrimary.CustomerPrimaryCountry ?? string.Empty
				//},
				//delivery_address = new
				//{
				//	name = customer.CustomerDelivery.CustomerDeliveryName ?? string.Empty,
				//	street_address = customer.CustomerDelivery.CustomerDeliveryStreetAddress ?? string.Empty,
				//	careof = customer.CustomerDelivery.CustomerDeliveryCareOf ?? string.Empty,
				//	zipcode = customer.CustomerDelivery.CustomerDeliveryZipCode ?? customer.CustomerPrimary.CustomerPrimaryZipCode,
				//	city = customer.CustomerDelivery.CustomerDeliveryCity ?? string.Empty,
				//	country = customer.CustomerDelivery.CustomerDeliveryCountry ?? string.Empty
				//}
			};

			HttpResponseMessage response = await _client.PutAsJsonAsync(_baseUrl + "customer/" + customer.CustomerNo, data);

			try
			{
				if (response.IsSuccessStatusCode)
				{
					response.EnsureSuccessStatusCode();

					var responseBody = await response.Content.ReadAsStringAsync();
					JObject jObject = JObject.Parse(responseBody);
					JToken customerData = jObject["data"];
					_customer = customerData.ToObject<CustomerStructure>();
				}
				else
				{
					Console.WriteLine("Unable to update data");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Customer info update error message " + e.Message);
			}

			//}
			//catch (Exception e)
			//{
			//	Console.WriteLine("Zipcode required if street_address is specified");
			//}
			return _customer;
		}
	}
}
