using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStoreModelLayer
{
   public  class AddressResponse
    {
        [Key]

        public int CustomerId { get; set; }

        public string FullName { get; set; }

        public long PhoneNumber { get; set; }

        public long PinCode { get; set; }
        public string Locality { get; set; }

        public string City { get; set; }
        public string Address { get; set; }

        public string AddressType { get; set; }

        public int UserId { get; set; }

    }
}
