using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookStoreModelLayer.BooksModels
{
    public class WishlistModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WishlitID { get; set; }

        [Required]
        [ForeignKey("UserModel")]
        public int UserId { get; set; }

        [Required]
        [ForeignKey("BookModel")]
        public int BookId { get; set; }
    }
}
