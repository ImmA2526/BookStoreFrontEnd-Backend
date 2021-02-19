using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreModelLayer
{
    public class LoginModel
    {
       
        public string Email { get; set; }
        
        public string Password { get; set; }

    }
}
