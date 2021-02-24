using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookStoreModelLayer.BooksModels
{
    public class BookModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [Required]
        public string BookName { get; set; }

        [Required]
        public string BookDescription { get; set; }

        [Required]
        public string BookImage { get; set; }

        [Required]
        public int BookCount { get; set; }

        [Required]
        public string AuthorName { get; set; }

        [Required]
        public int BookPrice { get; set; }

    }
}
