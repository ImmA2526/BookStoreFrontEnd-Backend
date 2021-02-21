using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookStoreModelLayer.BooksModels
{
    public class OrderModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [Required]
        [ForeignKey("CustomerModel")]
        public int CustomerId { get; set; }

        [Required]
        [ForeignKey("UserModel")]
        public int UserId { get; set; }

        [Required]
        [ForeignKey("BookModel")]
        public int BookId { get; set; }

        [Required]
        [ForeignKey("AddressTypeModel")]
        public int AddressTypeId { get; set; }

    }
}
