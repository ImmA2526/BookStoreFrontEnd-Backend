using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStoreModelLayer
{
    public class CartBookResponse
    {
        [Key]
        public int BookId { get; set; }

        public string BookName { get; set; }

        public string AuthorName { get; set; }

        public string BookImage { get; set; }

        public int BookCount { get; set; }

        public string PublisherName { get; set; }

        public int PublishedYear { get; set; }

        public int BookPrice { get; set; }

        public int CartId { get; set; }

        public int UserId { get; set; }

    }
}
