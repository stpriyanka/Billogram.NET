# Billogram .NET

A simple .net wrapper for Billogram API.

##Installation

To install Billogram, run the following command in the Package Manager Console

```
   PM> Install-Package Billogram 
               OR
   PM> Install-Package BillogramPackage
```
For more details about the package should be found [here](https://www.nuget.org/packages/BillogramPackage/). 

## Usage

To start with configure the client in you constructor.

```c#
	var appSettings = ConfigurationManager.AppSettings;
	_clientSecretUser = appSettings["Billogram.AuthUser"];
	_clientSecretKey = appSettings["Billogram.AuthKey"];
```

add client Id and secrect key in your App.Config blocked with <appsetting>.

By default the url is set to production environment .But incase you want to pass the base url (might be production/ sandbox environment) to the constructor then use the other contructor that takes the base url as parameter.

```c#
     public BillogramUtility(string authUser, string authKey, string baseUrl)
     {    ............
	  _baseUrl = baseUrl;
	 ......
     }
```


## Dependencies

To run this  library locally install these packages 

``` 
   PM> Install-Package Newtonsoft.Json -Version 8.0.3
   PM> Install-Package Microsoft.Net.Http
   PM> Install-Package JWT 1.3.4
```


## Resources

However , 8 endpoints have been implemented here.  

##### To refer any endpoint all is needed is to instantiate 'BillogramUtility.cs' class and continue the one is needed. (For ex. CreateBillogram, SendBillogram, GetCustomerInfo, GetBillogramsByState, ........) 

```c#

     var utility = new BillogramUtility(_clientSecretUser, _clientSecretKey); 
     List<Billogram> output = utility.GetBillogramListByCustomerNo(CustomerNo).Result;
     .........
```
#####NOTE: For sandbox environment use the other constructor to instantiate and pass the url as parameter

For more details [click here](https://billogram.com/api/documentation#easy_to_get_started)


## Contributing

Interested in contributing to Leap day? Would love your help. It is an open source project.

Pull requests or submitting any broken issues are welcome to share.


## License

Anyone can pull/modify under the terms of the [MIT License](http://opensource.org/licenses/MIT). You can refer the github link in your source.
