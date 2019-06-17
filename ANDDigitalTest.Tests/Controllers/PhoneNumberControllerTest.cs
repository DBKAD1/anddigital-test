using ANDDigitalTest.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ANDDigitalTest.Tests.Controllers
{
    [TestClass]
    public class PhoneNumberControllerTest
    {
        [TestMethod]
        public async System.Threading.Tasks.Task GetPhoneNumber_ShouldReturnListAsync()
        {
            var controller = new PhoneNumbersController();

            var result = await controller.GetAsync();
            Assert.IsNotNull(result);
            Assert.AreEqual(true, result.Count() > 0);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task GetPhoneNumberForCustomer_ShouldReturnListAsync()
        {
            var controller = new PhoneNumbersController();

            var result = await controller.GetAsync(@"robert_96@example.com");
            Assert.IsNotNull(result);
            Assert.AreEqual(true, result.Count() > 0);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task ActivatePhoneNumberShouldWork_ShouldReturnListAsync()
        {
            var controller = new PhoneNumbersController();

            var result = await controller.PutAsync(@"(959) 743 7639", "d3h8j822w34");
            Assert.IsNotNull(result);
            Assert.AreEqual(true, result=="Activation Success" || result == "Number is active");
        }
        [TestMethod]
        public async System.Threading.Tasks.Task ActivatePhoneNumberShouldFailWrongCode_ShouldReturnListAsync()
        {
            var controller = new PhoneNumbersController();

            var result = await controller.PutAsync(@"(959) 743 7639", "d3h8j82wesf");
            Assert.IsNotNull(result);
            Assert.AreEqual("Activation code in correct", result);
        }
    }
}