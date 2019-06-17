using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANDDigitalTest.Models
{
    public class PhoneNumber
    {
        public int UserId { get; set; }
        public string Number { get; set; }
        public string ActivationCode { get; set; }
        public bool IsActivated { get; set; }
    }
}