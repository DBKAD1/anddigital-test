using System;
using System.Net;
using ANDDigitalTest.BuisinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ANDDigitalTest.Tests.BuisinessLayer
{
    [TestClass]
    public class PhoneNumberBuisnessClassTests
    {
        [TestMethod]
        public async System.Threading.Tasks.Task GetAllNumbersAsyncMustComplteSuccessFullyAsync()
        {
            PhoneNumberBuisnessClass phoneNumberBuisness = new PhoneNumberBuisnessClass();
            var number =  await phoneNumberBuisness.GetAllNumbersAsync();
            Assert.AreEqual(HttpStatusCode.OK, number.Item3);
        }
        [TestMethod]
        public async System.Threading.Tasks.Task GetCustomerNumbersAsyncSuccessFullyAsync()
        {
            PhoneNumberBuisnessClass phoneNumberBuisness = new PhoneNumberBuisnessClass();
            var number = await phoneNumberBuisness.GetCustomerNumbersAsync("angela_97@example.com");
            Assert.AreEqual(HttpStatusCode.OK, number.Item3);
        }
        [TestMethod]
        public async System.Threading.Tasks.Task ActivatePhoneAsycn()
        {
            PhoneNumberBuisnessClass phoneNumberBuisness = new PhoneNumberBuisnessClass();
            var number = await phoneNumberBuisness.ActivatePhoneAsycn("(959) 743 7639", "d3h8j822w34"); 
            Assert.AreEqual(HttpStatusCode.OK, number.Item2);
        }
    }


}
