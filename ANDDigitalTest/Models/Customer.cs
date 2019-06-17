using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANDDigitalTest.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
}
}