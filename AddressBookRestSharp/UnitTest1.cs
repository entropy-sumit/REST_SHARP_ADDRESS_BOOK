using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace AddressBookRestSharp
{
    public class AddressBook
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }

    [TestClass]
    public class UnitTest1
    {
        RestClient client;

        [TestInitialize]
        public void SetUp()
        {
            client = new RestClient(" http://localhost:3000");
        }
        private IRestResponse AddressbookList()
        {
            RestRequest request = new RestRequest("AddressBookJson", Method.GET);

            IRestResponse response = client.Execute(request);
            return response;
        }

        //[TestMethod]
        //public void ReturnAddressbookList()
        //{
        //    IRestResponse response = AddressbookList();
        //    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        //    List<AddressBook> addressbookList = JsonConvert.DeserializeObject<List<AddressBook>>(response.Content);
        //    Assert.AreEqual(10, addressbookList.Count);
        //    foreach (AddressBook address in addressbookList)
        //    {
        //        Console.WriteLine("id: " + address.id + "\t" + "Firstname: " + address.FirstName + "\t" + "LastName: " + address.LastName + "\t" + "Address:" + address.Address + "\t" + "City:" + address.City + "\t" + "State:" + address.State + "\t" + "ZipCode:" + address.ZipCode + "\t" + "PhoneNumber:" + address.PhoneNumber + "\t" + "Email:" + address.Email);
        //    }
        //}
        //[TestMethod]
        //public void OnCallingPostAPIForAddressBookListWithMultipleAdrress_ReturnAddressBookObject()
        //{
        //    List<AddressBook> addressbookList = new List<AddressBook>();
        //    addressbookList.Add(new AddressBook { FirstName = "dipu", LastName = "rawat", Address = "lakhesra", City = "gorakhpur", State = "uttar pradesh", ZipCode = "956588", PhoneNumber = "98555228988", Email = "dipuraw@gamil.com" });

        //    foreach (var address in addressbookList)
        //    {

        //        RestRequest request = new RestRequest("/AddressBookJson", Method.POST);
        //        JsonObject jsonObj = new JsonObject();
        //        jsonObj.Add("FirstName", address.FirstName);
        //        jsonObj.Add("LastName", address.LastName);
        //        jsonObj.Add("Addresss", address.Address);
        //        jsonObj.Add("City", address.City);
        //        jsonObj.Add("State", address.State);
        //        jsonObj.Add("ZipCode", address.ZipCode);
        //        jsonObj.Add("PhoneNumber", address.PhoneNumber);
        //        jsonObj.Add("Email", address.Email);


        //        request.AddParameter("application/json", jsonObj, ParameterType.RequestBody);
        //        IRestResponse response = client.Execute(request);

        //        Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        //        AddressBook addressBook = JsonConvert.DeserializeObject<AddressBook>(response.Content);
        //        Assert.AreEqual(address.FirstName, addressBook.FirstName);
        //        Assert.AreEqual(address.LastName, addressBook.LastName);


        //        Console.WriteLine(response.Content);
        //    }
        //}
        //[TestMethod]
        //public void OnCallingPutAPI_ReturnEmployeeObject()
        //{
        //    RestRequest request = new RestRequest("/AddressBookJson/7", Method.PUT);
        //    JsonObject jsonObj = new JsonObject();
        //    jsonObj.Add("FirstName", "shivam");

        //    request.AddParameter("application/json", jsonObj, ParameterType.RequestBody);

        //    IRestResponse response = client.Execute(request);

        //    Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        //    AddressBook addressBook = JsonConvert.DeserializeObject<AddressBook>(response.Content);
        //    Assert.AreEqual("FirstName", addressBook.FirstName);

        //    Console.WriteLine(response.Content);
        //}
        [TestMethod]
        public void OnCallingDeleteAPI_ReturnSuccessStatus()
        {
            RestRequest request = new RestRequest("/AddressBookJson/9", Method.DELETE);

            IRestResponse response = client.Execute(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Console.WriteLine(response.Content);
        }
    }
}
  