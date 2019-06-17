using ANDDigitalTest.BuisinessLayer;
using ANDDigitalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ANDDigitalTest.Controllers
{
    public class PhoneNumbersController : ApiController
    {
        // GET: api/PhoneNumbers
        /// <summary>
        /// This action takes no input and will return a list of all the Phone Numbers in the API
        /// </summary>
        /// <returns>A list of Phone Number or an error message</returns>
        public async System.Threading.Tasks.Task<IEnumerable<PhoneNumber>> GetAsync()
        {
            var phoneNumberHelper= new PhoneNumberBuisnessClass();
            var phoneNumber = await phoneNumberHelper.GetAllNumbersAsync();
            if(phoneNumber.Item3==HttpStatusCode.OK)
            {
                return phoneNumber.Item1;

            }
            else
            {
                HttpResponseMessage response =
    this.Request.CreateErrorResponse(phoneNumber.Item3, phoneNumber.Item2);
                throw new HttpResponseException(response);
            }
        }

        // GET: api/PhoneNumbers/5
        /// <summary>
        /// This Action takes the email address of the user and returns all the phone numbers for that user
        /// </summary>
        /// <param name="email">The email of the user, append a forward slash (/) at the end of this input in the url</param>
        /// <returns>A list of Phone Number or an error message</returns>
         [Route("api/PhoneNumbers/{email}")]
        public async System.Threading.Tasks.Task<IEnumerable<PhoneNumber>> GetAsync(string email)
        {
            var phoneNumberHelper = new PhoneNumberBuisnessClass();
            var phoneNumber = await phoneNumberHelper.GetCustomerNumbersAsync(email);
            if (phoneNumber.Item3==HttpStatusCode.OK)
            {
                return phoneNumber.Item1;

            }
            else
            {
                HttpResponseMessage response =
    this.Request.CreateErrorResponse(phoneNumber.Item3, phoneNumber.Item2);
                throw new HttpResponseException(response);
            }
        }



        // PUT: api/PhoneNumbers/5
        /// <summary>
        /// This action takes the phone number and activation code as an input and tries to activate the number
        /// </summary>
        /// <param name="number">The phone number you want to activated</param>
        /// <param name="code">A unique activation code</param>
        /// <returns>Message</returns>
        [HttpPut]
        [Route("api/PhoneNumbers/{number}/{code}")]
        public async System.Threading.Tasks.Task<string> PutAsync(string number, [FromUri]string code)
        {
            var phoneNumberHelper = new PhoneNumberBuisnessClass();
           var phoneNumber= await phoneNumberHelper.ActivatePhoneAsycn(number, code);
            if (phoneNumber.Item2 != HttpStatusCode.OK)
            {
                HttpResponseMessage response =
                 this.Request.CreateErrorResponse(phoneNumber.Item2, phoneNumber.Item1);
                throw new HttpResponseException(response);
            }
            else
            {
                return phoneNumber.Item1;
            }
        }

      
    }
}
