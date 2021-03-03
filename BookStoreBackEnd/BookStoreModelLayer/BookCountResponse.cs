using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStoreModelLayer
{
    public class BookCountResponse
    {
        [Key]

        public int BookId { get; set; }

       public int BookCount { get; set; }
    }
}
