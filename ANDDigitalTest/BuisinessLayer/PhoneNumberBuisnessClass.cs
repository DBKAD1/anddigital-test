using ANDDigitalTest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace ANDDigitalTest.BuisinessLayer
{
    public class PhoneNumberBuisnessClass
    {

        public async System.Threading.Tasks.Task<Tuple<List<PhoneNumber>,string,HttpStatusCode>> GetAllNumbersAsync()
        {
            List<PhoneNumber> phoneNumbers = new List<PhoneNumber>();
            string message = string.Empty;
            HttpStatusCode httpCode = HttpStatusCode.OK;
            try
            {
                DataAccessHelper dataAccessHelper = new DataAccessHelper();
                var jsonString = await dataAccessHelper.GetJsonStringAsync();
                var users = JsonConvert.DeserializeObject<List<Customer>>(jsonString);
                if(users!=null&&users.Count>0)
                {
                    phoneNumbers= users.SelectMany(us=>us.PhoneNumbers).ToList();
                    if (phoneNumbers.Count == 0)
                    {
                        message = "No phone numbers found";
                    }
                }
                else
                {
                    message = "No customer records found";
                }
                
               
            }
            catch(Exception ex)
            {
                httpCode = HttpStatusCode.InternalServerError;
                message = "Sorry we are experiencing technical difficulties";
            }
            return new Tuple<List<PhoneNumber>, string,HttpStatusCode>(phoneNumbers, message,httpCode);
        }
        public async System.Threading.Tasks.Task<Tuple<List<PhoneNumber>, string,HttpStatusCode>> GetCustomerNumbersAsync(string email)
        {
            List<PhoneNumber> phoneNumbers = new List<PhoneNumber>();
            string errorMessage = string.Empty;
            HttpStatusCode httpCode = HttpStatusCode.OK;
            try
            {
                if(string.IsNullOrEmpty(email))
                {
                    errorMessage = "Please provide an email address";
                    httpCode = HttpStatusCode.BadRequest;
                }
                else
                    {
                    DataAccessHelper dataAccessHelper = new DataAccessHelper();
                    var jsonString = await dataAccessHelper.GetJsonStringAsync();
                    var users = JsonConvert.DeserializeObject<List<Customer>>(jsonString).FirstOrDefault(u => u.email.ToLower().Trim() == email.ToLower().Trim());
                    if (users != null)
                    {
                        phoneNumbers = users.PhoneNumbers;
                        if (phoneNumbers.Count == 0)
                        {
                            errorMessage = "No phone numbers found";
                        }
                    }
                    else
                    {
                        errorMessage = "No customer records found";
                    }
                }
                


            }
            catch (Exception ex)
            {
                httpCode = HttpStatusCode.InternalServerError;
                errorMessage = "Sorry we are experiencing technical difficulties";
            }
            return new Tuple<List<PhoneNumber>, string, HttpStatusCode>(phoneNumbers, errorMessage, httpCode);
        }
        public async System.Threading.Tasks.Task<Tuple< string, HttpStatusCode>> ActivatePhoneAsycn(string number,string code)
        {
            string status = string.Empty;
            HttpStatusCode httpCode = HttpStatusCode.OK;
            try
            {
                if (string.IsNullOrEmpty(number))
                {
                    status = "Please provide a phone number";
                    httpCode = HttpStatusCode.BadRequest;
                }
                else if (string.IsNullOrEmpty(code))
                {
                    status = "Please provide a phone number";
                    httpCode = HttpStatusCode.BadRequest;
                }
                else
                {
                    DataAccessHelper dataAccessHelper = new DataAccessHelper();
                    var jsonString = await dataAccessHelper.GetJsonStringAsync();
                    var users = JsonConvert.DeserializeObject<List<Customer>>(jsonString);
                    if (users != null && users.Count > 0)
                    {
                        var phoneNumber = users.SelectMany(us => us.PhoneNumbers).FirstOrDefault(ph => ph.Number.ToLower().Trim() == number.ToLower().Trim());
                        if (phoneNumber == null)
                        {
                            status = "No phone numbers found";
                        }
                        else if (phoneNumber.ActivationCode != code)
                        {
                            status = "Activation code in correct";
                        }
                        else if (!phoneNumber.IsActivated)
                        {
                            phoneNumber.IsActivated = true;
                            status = "Activation Success";
                            httpCode = HttpStatusCode.OK;
                            var jsonToSave = JsonConvert.SerializeObject(users);
                            await dataAccessHelper.SaveJsonStringAsync(jsonToSave);
                        }
                        else
                        {
                            status = "Number is active";
                        }
                    }
                    else
                    {
                        status = "No customer records found";
                    }
                }
               


            }
            catch (Exception ex)
            {
                httpCode = HttpStatusCode.InternalServerError;
                status = "Sorry we are experiencing technical difficulties";
            }
            return new Tuple<string, HttpStatusCode>(status, httpCode);
        }
    }
}