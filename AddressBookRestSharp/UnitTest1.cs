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

        [TestMethod]
        public void ReturnAddressbookList()
        {
            IRestResponse response = AddressbookList();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            List<AddressBook> addressbookList = JsonConvert.DeserializeObject<List<AddressBook>>(response.Content);
            Assert.AreEqual(10, addressbookList.Count);
            foreach (AddressBook address in addressbookList)
            {
                Console.WriteLine("id: " + address.id + "\t" + "Firstname: " + address.FirstName + "\t" + "LastName: " + address.LastName + "\t" + "Address:" + address.Address + "\t" + "City:" + address.City + "\t" + "State:" + address.State + "\t" + "ZipCode:" + address.ZipCode + "\t" + "PhoneNumber:" + address.PhoneNumber + "\t" + "Email:" + address.Email);
            }
        }
    }
}
  