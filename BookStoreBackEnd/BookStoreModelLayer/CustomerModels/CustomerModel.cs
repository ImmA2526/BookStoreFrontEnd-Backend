using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookStoreModelLayer.CustomerModels
{
    public class CustomerModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [MaxLength(10)]
        public long PhoneNumber { get; set; }

        [Required]
        [ForeignKey("AddressTypeModel")]
        public int AddressTypeId { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
