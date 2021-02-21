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
        public string AuthorName { get; set; }

        [Required]
        public string PublisherName { get; set; }

        public DateTime BookPublishDate { get; set; }

        [Required]
        public string BookPrice { get; set; }

    }
}
